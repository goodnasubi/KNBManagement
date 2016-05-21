using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.ServiceModel.DomainServices.Client;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace KNBManagement.ViewModels.Core
{
    public abstract partial class ViewModelBase<TDomainContext> : ViewModelBase, INotifyPropertyChanged, INotifyDataErrorInfo
        where TDomainContext : DomainContext, new()
    {

        #region Contextの実装

        private TDomainContext _context = null;

        protected TDomainContext Context
        {
            get
            {
                if (this._context == null)
                {
                    this._context = new TDomainContext();
                    this._context.PropertyChanged += new PropertyChangedEventHandler(Context_PropertyChanged);
                }
                return this._context;
            }
        }

        protected virtual void Context_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged(e.PropertyName);
        }

        #endregion

        #region 読込状態処理＆管理

        private bool _isLoading = false;
        private int _loadingCounter = 0;

        protected void NowLoading<TEntity>(EntityQuery<TEntity> query, Action<IEnumerable<TEntity>> callback) where TEntity : Entity
        {
            this.IsLoading = true;
            try
            {
                this.Context.Load<TEntity>(query,
                    loadOp =>
                    {
                        callback(loadOp.Entities);
                        this.IsLoading = false;
                    }, null);
            }
            catch(Exception e)
            {
                MessageBox.Show(ApplicationStrings.MsgErrorCommunication + e.Message,
                    ApplicationStrings.MsgBoxCaptionError, MessageBoxButton.OK);
                this.IsLoading = false;
            }
        }

        private void ResetLoadingCounter()
        {
            this._loadingCounter = 0;
            this.IsLoading = false;
        }

        private bool addLoadingCounter()
        {
            if (this._loadingCounter < int.MaxValue)
            {
                this._loadingCounter++;
            }
            return CheckLoadingCounter();
        }

        private bool decLoadingCounter()
        {
            if (this._loadingCounter > 0)
            {
                this._loadingCounter--;
            }
            return CheckLoadingCounter();
        }

        private bool CheckLoadingCounter()
        {
            if (this._loadingCounter > 0)
            {
                this.IsLoading = true;
            }
            else
            {
                this.ResetLoadingCounter();
            }
            return this.IsLoading;
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            internal set
            {
                _isLoading = value;
                NotifyPropertyChanged("IsLoading");
            }
        }

        #endregion

        #region INotifyPropertyChangedの実装

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region INotifyDataErrorInfoの実装

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            var result = new List<ValidationResult>();
            // TryValidatePropertyが適任。プロパティの値を取得するのにリフレクションを
            // 使っている部分が気に入らない
            if (!string.IsNullOrWhiteSpace(propertyName) &&
                Validator.TryValidateProperty(
                GetType().GetProperty(propertyName).GetValue(this, null),
                new ValidationContext(this, null, null) { MemberName = propertyName },
                result))
            {
                return null;
            }
            return result.Select(vr => vr.ErrorMessage);
        }

        public bool HasErrors
        {
            get
            {
                var dummy = new List<ValidationResult>();
                // TryValidateObjectが適任
                return !Validator.TryValidateObject(
                    this,
                    new ValidationContext(this, null, null),
                    dummy);
            }
        }

        #endregion

        #region PropertyChangedイベントを発行

        /// <summary>
        /// PropertyChangedとErrorChangedイベントを発行します。
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            NotifyPropertyChanged(propertyName);
            NotifyErrorChanged(propertyName);

            // HasErrorsプロパティにも変更があったことを通知する
            NotifyPropertyChanged("HasErrors");

            // Button の状態を変更する
            CommandManager.FireRequerySuggested();

        }

        private void NotifyPropertyChanged(string propName)
        {
            var h = PropertyChanged;
            if (h == null) return;
            h(this, new PropertyChangedEventArgs(propName));
        }

        private void NotifyErrorChanged(string propertyName)
        {
            var h = ErrorsChanged;
            if (h == null) return;
            h(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion

        #region モード制御

        #region コマンドとの結び付け

        protected virtual void Submit()
        {
            if (this.Context.HasChanges)
            {
                this.IsLoading = true;
                try
                {
                    this.Context.SubmitChanges(o =>
                    {
                        try
                        {
                            if (o.HasError)
                            {
                                MessageBox.Show(ApplicationStrings.MsgErrorSubmit + o.Error.Message,
                                    ApplicationStrings.MsgBoxCaptionError, MessageBoxButton.OK);
                            }
                            o.Completed += new EventHandler(Submit_Completed);
                            this.OnSubmited(o);
                        }
                        finally
                        {
                            this.IsLoading = false;
                        }
                    }, null);
                }
                catch(Exception e)
                {
                    MessageBox.Show(ApplicationStrings.MsgErrorSubmit + e.Message,
                        ApplicationStrings.MsgBoxCaptionError, MessageBoxButton.OK);
                    this.IsLoading = false;
                }
            }
        }

        protected virtual void Submit_Completed(object sender, EventArgs e)
        {
        }

        protected virtual void OnSubmited(SubmitOperation so)
        {
            this.ResetAddMode();
            this.ResetEditMode();
        }

        protected override bool RaiseAddCanExecute()
        {
            return this.IsReadOnly;
        }
        protected override void RaiseAddExecute()
        {
            base.RaiseAddExecute();
            this.SetAddMode();
        }

        protected override bool RaiseRegCanExecute()
        {
            return this.IsAdd;
        }
        protected override void RaiseRegExecute()
        {
            base.RaiseRegExecute();

            this.Submit();
        }

        protected override bool RaiseEditCanExecute()
        {
            return this.IsReadOnly;
        }
        protected override void RaiseEditExecute()
        {
            base.RaiseEditExecute();
            this.SetEditMode();
        }

        protected override bool RaiseUpdateCanExecute()
        {
            return this.IsEdit;
        }
        protected override void RaiseUpdateExecute()
        {
            base.RaiseUpdateExecute();

            this.Submit();
        }

        protected override bool RaiseCancelCanExecute()
        {
            return this.IsNoReadOnly;
        }

        protected override void RaiseCancelExecute()
        {
            base.RaiseCancelExecute();

            this.Context.RejectChanges();

            this.SetReadOnlyMode();
        }

        #endregion

        private bool _modeChenging = false;

        protected void SetReadOnlyMode()
        {
            this.IsAdd = false;
            this.IsEdit = false;
        }

        protected void SetEditMode()
        {
            this.IsEdit = true;
        }

        protected void SetAddMode()
        {
            this.IsAdd = true;
        }

        protected void ResetEditMode()
        {
            this.IsEdit = false;
        }

        protected void ResetAddMode()
        {
            this.IsAdd = false;
        }

        //private bool _isReadOnly = true;

        private void NotifyReadOnlyChenged()
        {
            OnPropertyChanged("IsReadOnly");
            OnPropertyChanged("IsNoReadOnly");
        }

        public bool IsReadOnly
        {
            get
            {
                //this._isReadOnly = !this.IsAdd && !this.IsEdit;
                //return this._isReadOnly;
                return !this.IsAdd && !this.IsEdit;
            }
        }

        public bool IsNoReadOnly
        {
            get { return !this.IsReadOnly; }
        }

        private bool _isEdit;
        public bool IsEdit
        {
            get { return this._isEdit; }
            private set
            {
                if (this._isEdit != value)
                {
                    this._isEdit = value;
                    OnPropertyChanged("IsEdit");
                    OnPropertyChanged("IsNoEdit");

                    if (!this._modeChenging && this._isEdit)
                    {
                        try
                        {
                            this._modeChenging = true;
                            this.IsAdd = false;
                        }
                        finally
                        {
                            this._modeChenging = false;
                        }
                    }
                    this.NotifyReadOnlyChenged();
                }
            }
        }

        public bool IsNoEdit
        {
            get { return !this._isEdit; }
        }

        private bool _isAdd;
        public bool IsAdd
        {
            get { return this._isAdd; }
            private set
            {
                if (this._isAdd != value)
                {
                    this._isAdd = value;
                    OnPropertyChanged("IsAdd");
                    OnPropertyChanged("IsNoAdd");
                    if (!this._modeChenging && this._isAdd)
                    {
                        try
                        {
                            this._modeChenging = true;
                            this.IsEdit = false;
                        }
                        finally
                        {
                            this._modeChenging = false;
                        }
                    }
                    this.NotifyReadOnlyChenged();
                }
            }
        }

        public bool IsNoAdd
        {
            get { return !this._isAdd; }
        }

        #endregion


    }
}
