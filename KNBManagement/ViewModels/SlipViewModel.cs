using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using KNBManagement.Assets.Resources;
using KNBManagement.Web;
using KNBManagement.Web.Resources;
using KNBManagement.Web.Services;

namespace KNBManagement.ViewModels
{
    /// <summary>
    /// 伝票画面を制御するMVVM
    /// </summary>
    /// <remarks>
    /// http://weblogs.asp.net/fredriknormen/archive/2009/11/30/silverlight-4-mvvm-with-commanding-and-wcf-ria-services.aspx
    /// </remarks>
    public class SlipViewModel : SlipViewModelBase<KN_BManageContext>
    {
        #region ローカル変数

        private Company _company;
        private IEnumerable<Company> _companies;

        private BusinessType _businessType;

        private Employee _employee;
        private IEnumerable<Employee> _employees;

        private Slip _slip;
        private IEnumerable<Slip> _slips;

        private SlipDetail _slipDetail;
        private IEnumerable<SlipDetail> _slipDetails;

        private DateTime _slipTradingDate;

        private IEnumerable<DateTime> _slipTradingDates;

        //private IEnumerable<JournalItem> _journalItems;

        private IEnumerable<JournalItemBiz> _journalItemBizs;

        private SlipType _slipType;
        private IEnumerable<SlipType> _slipTypes;

        #endregion

        public SlipViewModel()
        {
            // デザインモードでない場合
            if (!DesignerProperties.IsInDesignTool)
            {
                this._slipTradingDate = DateTime.Now;
                this.GetSlipTypes();
                this.GetCompanies();
            }
        }

        #region データ取得

        /// <summary>
        /// 会社マスタ取得
        /// </summary>
        private void GetCompanies()
        {
            this.NowLoading<Company>(
                this.Context.GetCompaniesQuery(),
                ent => this.Companies = ent
                );
        }

        /// <summary>
        /// 選択された会社の業種を取得
        /// </summary>
        /// <param name="businessTypeID"></param>
        private void GetBusinessType(global::System.Guid businessTypeID)
        {
            this.NowLoading<BusinessType>(
                this.Context.GetBusinessTypesByBusinessTypeIDQuery(businessTypeID),
                ent => this.BusinessType = ent.SingleOrDefault()
                );
        }

        /// <summary>
        /// 選択された会社の社員一覧を取得
        /// </summary>
        /// <param name="companyID"></param>
        private void GetEmployees(global::System.Guid companyID)
        {
            this.NowLoading<Employee>(
                this.Context.GetEmployeesByCompanyIDQuery(companyID),
                ent => this.Employees = ent
                );
        }

        /// <summary>
        /// 伝票情報を取得します
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="tradingDate"></param>
        private void GetSlips(global::System.Guid companyID, DateTime tradingDate)
        {
            this.NowLoading<Slip>(
                this.Context.GetSlipsByCompanyIDTradingMonthryQuery(companyID, tradingDate),
                ent => this.Slips = ent
                );
        }

        /// <summary>
        /// 伝票情報を取得します
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="tradingDate"></param>
        private void GetSlips(global::System.Guid companyID, DateTime tradingDateFrom, DateTime tradingDateTo)
        {
            this.NowLoading<Slip>(
                this.Context.GetSlipsByCompanyIDTradingFromToQuery(companyID, tradingDateFrom, tradingDateTo),
                ent => this.Slips = ent
                );
        }

        /// <summary>
        /// 伝票詳細情報を取得します。
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="slipID"></param>
        private void GetSlipDetails(global::System.Guid companyID, global::System.Guid slipID)
        {
            this.NowLoading<SlipDetail>(
                this.Context.GetSlipDetailsByCompanyIDSlipIDDefaultQuery(companyID, slipID),
                ent => this.SlipDetails = ent
            );
        }

        /// <summary>
        /// リスト表示用の仕訳項目一覧を取得します。
        /// </summary>
        /// <param name="businessTypeID"></param>
        private void GetJournalItemBizs(global::System.Guid businessTypeID)
        {
            this.NowLoading<JournalItemBiz>(
                this.Context.GetJournalItemBizsByBusinessTypeIDForListDisplayQuery(businessTypeID),
                ent => this.JournalItemBizs = ent
            );
        }

        /// <summary>
        /// 伝票種別を取得します。
        /// </summary>
        private void GetSlipTypes()
        {
            this.NowLoading<SlipType>(
                this.Context.GetSlipTypesQuery(),
                ent => this.SlipTypes = ent
                );
        }

        public Slip NewSlip()
        {
            return new Slip() { TradingDate = DateTime.Now };
        }

        private void GetAddSlip(global::System.Guid companyID, DateTime tradingDate)
        {
            //this.NowLoading<Slip>(
            //    this.Context.GetSlipsByCompanyIDTradingDateForAddQuery(companyID, tradingDate),
            //    ent =>
            //    {
            //        this.Slip = ent.FirstOrDefault();
            //        this.Context.Slips.Add(this.Slip);
            //    }
            //);

            this.Slip = Slip.CreateAddNewSlip(companyID, tradingDate);

            this.Context.Slips.Add(this.Slip);
        }

        private void GetAddSlipDetails(global::System.Guid companyID, global::System.Guid slipID)
        {
            //this.NowLoading<SlipDetail>(
            //    this.Context.GetSlipDetailsByCompanyIDSlipIDForAddQuery(companyID, slipID),
            //    ent =>
            //    {
            //        this.SlipDetails = this.SlipDetails.Concat(ent);
            //        this.SlipDetail = ent.FirstOrDefault();

            //        this.Context.SlipDetails.Add(this.SlipDetail);
            //    }
            //);

            var ent = SlipDetail.CreateAddNewSlipDetail(companyID, slipID);
            //var entList = new List <SlipDetail> { ent };
            var entList = new ObservableCollection<SlipDetail> { ent };

            this.SlipDetails = this.SlipDetails.Concat(entList);
            this.SlipDetail = ent;

            this.Context.SlipDetails.Add(this.SlipDetail);
        }

        #endregion

        #region プロパティ

        #region 仕訳票

        private bool _isNoSlipData = false;
        public bool IsExistSlipData
        {
            get { return this._isNoSlipData; }
            set
            {
                if (this._isNoSlipData != value)
                {
                    this._isNoSlipData = value;
                    OnPropertyChanged("IsExistSlipData");
                }
            }
        }


        //[Display(Name = "TradingDateLabel", Order = 3, ResourceType = typeof(KNBManageDataResources), ShortName = "TradingDateCol")]
        //[Required()]
        //public DateTime TradingDate
        //{
        //    get { return this.Slip.TradingDate; }
        //    set
        //    {
        //        if (this.Slip.TradingDate != value)
        //        {
        //            this.Slip.TradingDate = value;
        //            OnPropertyChanged("TradingDate");
        //        }
        //    }

        //}


        [Display(Name = "SlipTypeIDLabel", Order = 3, ResourceType = typeof(KNBManageDataResources), ShortName = "SlipTypeIDCol")]
        [Required()]
        public int SlipTypeID
        {
            get
            {
                return this.Slip.SlipTypeID;
            }
            set
            {
                if ((this.Slip.SlipTypeID != value))
                {
                    this.Slip.SlipTypeID = value;
                    OnPropertyChanged("SlipTypeID");
                }
            }
        }


        //[Display(Name = "JournalItemIDLabel", Order = 4, ResourceType = typeof(KNBManageDataResources), ShortName = "JournalDetailIDCol")]
        //[Required()]
        //public Guid JournalItemID
        //{
        //    get
        //    {
        //        return this.Slip.JournalItemID;
        //    }
        //    set
        //    {
        //        if ((this.Slip.JournalItemID != value))
        //        {
        //            this.Slip.JournalItemID = value;
        //            OnPropertyChanged("JournalItemID");
        //        }
        //    }
        //}

        //[Display(Name = "RemarksLabel", Order = 5, ResourceType = typeof(KNBManageDataResources), ShortName = "RemarksCol")]
        //[Required()]
        //[StringLength(50)]
        //public string Remarks
        //{
        //    get
        //    {
        //        return this.Slip.Remarks;
        //    }
        //    set
        //    {
        //        if ((this.Slip.Remarks != value))
        //        {
        //            this.Slip.Remarks = value;
        //            OnPropertyChanged("Remarks");
        //        }
        //    }
        //}

        #endregion

        public Company Company
        {
            get { return this._company; }
            set
            {
                if (this._company != value)
                {
                    this._company = value;
                    OnPropertyChanged("Company");

                    if (this._company != null)
                    {
                        this.GetBusinessType(this.Company.BusinessTypeID);
                        this.GetEmployees(this.Company.CompanyID);
                        this.GetJournalItemBizs(this._company.BusinessTypeID);
                        this.GetSlips(this.Company.CompanyID, this.SlipTradingDate);
                    }
                    else
                    {
                        this.BusinessType = null;
                        this.Employees = null;
                        this.JournalItemBizs = null;
                        this.Slips = null;
                    }
                }
            }
        }

        public IEnumerable<Company> Companies
        {
            get { return this._companies; }
            set
            {
                if (this._companies != value)
                {
                    this._companies = value;
                    OnPropertyChanged("Companies");

                    if (this._companies != null)
                    {
                        this.Company = this._companies.FirstOrDefault();
                    }
                    else
                    {
                        this.Company = null;
                    }
                }
            }
        }

        public BusinessType BusinessType
        {
            get { return this._businessType; }
            set
            {
                if (this._businessType != value)
                {
                    this._businessType = value;
                    OnPropertyChanged("BusinessType");
                }
            }
        }

        public Employee Employee
        {
            get { return this._employee; }
            set
            {
                if (this._employee != value)
                {
                    this._employee = value;
                    OnPropertyChanged("Employee");
                }
            }
        }

        public IEnumerable<Employee> Employees
        {
            get { return this._employees; }
            set
            {
                if (this._employees != value)
                {
                    this._employees = value;
                    OnPropertyChanged("Employees");
                    if (this._employees != null)
                    {
                        this.Employee = this._employees.FirstOrDefault();
                    }
                    else
                    {
                        this.Employee = null;
                    }
                }
            }
        }

        public Slip Slip
        {
            get
            {
                if (this._slip == null)
                {
                    this._slip = this.NewSlip();
                }
                return this._slip;
            }
            set
            {
                if (this._slip != value)
                {
                    this._slip = value;
                    var isNull = (this._slip == null);

                    OnPropertyChanged("Slip");
                    //OnPropertyChanged("TradingDate");
                    OnPropertyChanged("SlipTypeID");
                    //OnPropertyChanged("JournalItemID");
                    //OnPropertyChanged("Remarks");

                    if (!isNull)
                    {
                        this.IsExistSlipData = true;
                        this.GetSlipDetails(this._slip.CompanyID, this._slip.SlipID);
                    }
                    else
                    {
                        this.IsExistSlipData = false;
                        this.SlipDetails = null;
                    }

                    //this.SetReadOnlyMode();
                }
            }
        }

        public IEnumerable<Slip> Slips
        {
            get { return this._slips; }
            set
            {
                if (this._slips != value)
                {
                    this._slips = value;
                    OnPropertyChanged("Slips");
                    if (this._slips != null && this._slips.Count() > 0)
                    {
                        if (this._hasAddSubmitAfterProc)
                        {
                            try
                            {
                                OnPropertyChanged("Slip");
                            }
                            finally
                            {
                                this._hasAddSubmitAfterProc = false;
                            }
                        }
                        else
                        {
                            this.Slip = this._slips.FirstOrDefault();
                        }
                    }
                    else
                    {
                        this.Slip = null;
                    }
                }
            }
        }

        public SlipDetail SlipDetail
        {
            get { return this._slipDetail; }
            set
            {
                if (this._slipDetail != value)
                {
                    this._slipDetail = value;
                    OnPropertyChanged("SlipDetail");
                }
            }
        }

        public IEnumerable<SlipDetail> SlipDetails
        {
            get { return this._slipDetails; }
            set
            {
                if (this._slipDetails != value)
                {
                    this._slipDetails = value;
                    OnPropertyChanged("SlipDetails");

                    if (this._slipDetails != null)
                    {
                        this.SlipDetail = this._slipDetails.FirstOrDefault();
                    }
                    else
                    {
                        this.SlipDetail = null;
                    }
                }
            }
        }

        public DateTime SlipTradingDate
        {
            get { return this._slipTradingDate; }
            set
            {
                if (this._slipTradingDate != value)
                {
                    var oldDate = this._slipTradingDate;
                    this._slipTradingDate = value;
                    OnPropertyChanged("SlipTradingDate");
                    if(oldDate.Year != this._slipTradingDate.Year || oldDate.Month !=this._slipTradingDate.Month)
                    {
                        this.GetSlips(this.Company.CompanyID, this.SlipTradingDate);
                    }
                }
            }
        }

        public IEnumerable<DateTime> SlipTradingDates
        {
            get { return this._slipTradingDates; }
            set
            {
                if (this._slipTradingDates != value)
                {
                    this._slipTradingDates = value;
                    OnPropertyChanged("SlipTradingDates");

                    var dts = this._slipTradingDates.ToArray();
                    switch (dts.Length)
                    {
                        case 1:
                            this.GetSlips(this.Company.CompanyID, dts[0]);
                            break;
                        case 2:
                            if (dts[0] < dts[1])
                            {
                                this.GetSlips(this.Company.CompanyID, dts[0], dts[1]);
                            }
                            else
                            {
                                this.GetSlips(this.Company.CompanyID, dts[1], dts[0]);
                            }
                            break;

                    }
                }
            }
        }

        //public IEnumerable<JournalItem> JournalItems
        //{

        //}

        public IEnumerable<JournalItemBiz> JournalItemBizs
        {
            get { return this._journalItemBizs; }
            set
            {
                if (this._journalItemBizs != value)
                {
                    this._journalItemBizs = value;
                    OnPropertyChanged("JournalItemBizs");
                }
            }
        }

        public SlipType SlipType
        {
            get { return this._slipType; }
            set
            {
                if (this._slipType != value)
                {
                    this._slipType = value;
                    OnPropertyChanged("SlipType");
                }
            }
        }

        public IEnumerable<SlipType> SlipTypes
        {
            get { return this._slipTypes; }
            set
            {
                if (this._slipTypes != value)
                {
                    this._slipTypes = value;
                    OnPropertyChanged("SlipTypes");

                    if (this._slipTypes != null)
                    {
                        this.SlipType = this._slipTypes.FirstOrDefault();
                    }
                    else
                    {
                        this.SlipType = null;
                    }
                }
            }
        }

        #endregion

        protected override void OnSubmited(System.ServiceModel.DomainServices.Client.SubmitOperation so)
        {
            if(this.IsAdd)
            {
                //追加処理をサブミットした場合の表示制御を行います
                this._hasAddSubmitAfterProc = true;
                //this._addSubmitAfterProc = () =>
                //    {
                //        try
                //        {
                            
                //        }
                //        finally
                //        {
                //            this._addSubmitAfterProc = null;
                //        }
                //    };


                if (this.SlipTradingDate != this.Slip.TradingDate)
                {
                    this.SlipTradingDate = this.Slip.TradingDate;
                }
                else
                {
                    this.GetSlips(this.Company.CompanyID, this.SlipTradingDate);
                }
            }
            base.OnSubmited(so);
            
        }

        //private Action _addSubmitAfterProc = null;

        private bool _hasAddSubmitAfterProc = false;



        #region コマンド

        /// <summary>
        /// 伝票を新規作成します
        /// </summary>
        protected override void RaiseAddExecute()
        {
            base.RaiseAddExecute();
            this.GetAddSlip(this.Company.CompanyID, this.SlipTradingDate);
        }

        /// <summary>
        /// 新規作成した伝票をデータベースに登録します
        /// </summary>
        protected override void RaiseRegExecute()
        {
            base.RaiseRegExecute();

        }

        /// <summary>
        /// 編集ボタンが使用可能かどうかを返します
        /// </summary>
        /// <returns></returns>
        protected override bool RaiseEditCanExecute()
        {
            return base.RaiseEditCanExecute() && this.IsExistSlipData;
        }

        ///// <summary>
        ///// 編集ボタンを実行します
        ///// </summary>
        //protected override void RaiseEditExecute()
        //{
        //    base.RaiseEditExecute();

        //}

        ///// <summary>
        ///// 更新ボタンを実行します
        ///// </summary>
        //protected override void RaiseUpdateExecute()
        //{
        //    base.RaiseUpdateExecute();

        //}

        /// <summary>
        /// キャンセルボタンを実行します
        /// </summary>
        protected override void RaiseCancelExecute()
        {
            if (this.Context.HasChanges
                && MessageBox.Show(
                    SlipViewResources.MsgConfirmCancel,
                    ApplicationStrings.MsgBoxCaptionCancel,
                    MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var backIsAdd = this.IsAdd;
                var backIsEdit = this.IsEdit;

                base.RaiseCancelExecute();

                if (backIsAdd)
                {
                    this.SlipTradingDate = DateTime.Now;
                }
                else if (backIsEdit)
                {
                    this.GetSlipDetails(this.Slip.CompanyID, this.Slip.SlipID);
                }
            }
            else
            {
                base.RaiseCancelExecute();
            }
        }

        /// <summary>
        /// 伝票詳細追加ボタンが使用可能かどうかを返します
        /// </summary>
        /// <returns></returns>
        protected override bool RaiseAddSlipDetailRecordCanExecute()
        {
            return this.IsNoReadOnly;

        }

        /// <summary>
        /// 伝票詳細追加ボタンを実行します
        /// </summary>
        protected override void RaiseAddSlipDetailRecordExecute()
        {
            base.RaiseAddSlipDetailRecordExecute();
            this.GetAddSlipDetails(this.Company.CompanyID, this.Slip.SlipID);
        }

        /// <summary>
        /// 伝票詳細削除ボタンが使用可能かどうかを返します
        /// </summary>
        /// <returns></returns>
        protected override bool RaiseDelSlipDetailRecordCanExecute()
        {
            return this.IsNoReadOnly && (this.SlipDetails != null) && (this.SlipDetails.Count() > 0) && (this.SlipDetail != null);

        }

        /// <summary>
        /// 伝票詳細削除ボタンを実行します
        /// </summary>
        protected override void RaiseDelSlipDetailRecordExecute()
        {
            base.RaiseDelSlipDetailRecordExecute();

            // 削除レコードを設定
            var delEnt = this.SlipDetail;
            // 一覧から削除レコードの前半部を取得
            var entFront = this.SlipDetails.TakeWhile(d => !d.Equals(delEnt));
            // 一覧から削除レコードの後半部を取得
            var entRear = this.SlipDetails.SkipWhile(d => !d.Equals(delEnt));
            entRear = entRear.Count() > 1 ? entRear.Skip(1) : new List<SlipDetail> { };
            // 後半部から新しく選択するレコードを設定
            var selectEnt = entRear.FirstOrDefault();

            this.Context.SlipDetails.Remove(delEnt);

            this.SlipDetails = new ObservableCollection<SlipDetail>(
                    entFront.Concat(entRear)                
                );
            this.SlipDetail = selectEnt;
            this.ReSoartSlipDetailOrder();
        }

        /// <summary>
        /// 伝票詳細上移動ボタンが使用可能かどうかを返します
        /// </summary>
        /// <returns></returns>
        protected override bool RaiseUpSlipDetailRecordCanExecute()
        {
            return this.IsNoReadOnly && (this.SlipDetails != null) && (this.SlipDetails.Count() > 0) && (this.SlipDetail != null)
                && (this.SlipDetails.FirstOrDefault() != this.SlipDetail);
        }

        /// <summary>
        /// 伝票詳細上移動ボタンを実行します
        /// </summary>
        protected override void RaiseUpSlipDetailRecordExecute()
        {
            base.RaiseUpSlipDetailRecordExecute();

            // 上移動対象レコードを設定
            var moveEnt = this.SlipDetail;
            // 一覧から削除レコードの前半部を取得
            var entFront = this.SlipDetails.TakeWhile(d => !d.Equals(moveEnt));
            // 一覧から削除レコードの後半部を取得
            var entRear = this.SlipDetails.SkipWhile(d => !d.Equals(moveEnt));
            entRear = entRear.Count() > 1 ? entRear.Skip(1) : new List<SlipDetail> { };
            // 移動先レコードを設定
            var selectEnt = entFront.LastOrDefault();

            entFront = entFront.TakeWhile(d => !d.Equals(selectEnt));

            this.SlipDetails = new ObservableCollection<SlipDetail>(
                    entFront.Concat(new List<SlipDetail> { moveEnt }).Concat(new List<SlipDetail> { selectEnt }).Concat(entRear)
                );
            this.SlipDetail = moveEnt;
            this.ReSoartSlipDetailOrder();
        }

        /// <summary>
        /// 伝票詳細下移動ボタンが使用可能かどうかを返します
        /// </summary>
        /// <returns></returns>
        protected override bool RaiseDownSlipDetailRecordCanExecute()
        {
            return this.IsNoReadOnly && (this.SlipDetails != null) && (this.SlipDetails.Count() > 0) && (this.SlipDetail != null)
                && (this.SlipDetails.LastOrDefault() != this.SlipDetail);
        }

        /// <summary>
        /// 伝票詳細下移動ボタンを実行します
        /// </summary>
        protected override void RaiseDownSlipDetailRecordExecute()
        {
            base.RaiseDownSlipDetailRecordExecute();

            // 下移動対象レコードを設定
            var moveEnt = this.SlipDetail;
            // 一覧から削除レコードの前半部を取得
            var entFront = this.SlipDetails.TakeWhile(d => !d.Equals(moveEnt));
            // 一覧から削除レコードの後半部を取得
            var entRear = this.SlipDetails.SkipWhile(d => !d.Equals(moveEnt));
            entRear = entRear.Count() > 1 ? entRear.Skip(1) : new List<SlipDetail> { };
            // 移動先レコードを設定
            var selectEnt = entRear.FirstOrDefault();

            entRear = entRear.Skip(1);

            this.SlipDetails = new ObservableCollection<SlipDetail>(
                    entFront.Concat(new List<SlipDetail> { selectEnt }).Concat(new List<SlipDetail> { moveEnt }).Concat(entRear)
                );
            this.SlipDetail = moveEnt;
            this.ReSoartSlipDetailOrder();
        }

        /// <summary>
        /// SlipDetailのDetailOrderを表示順に再設定します
        /// </summary>
        private void ReSoartSlipDetailOrder()
        {
            var idx = 0;

            foreach( var sd in this.SlipDetails )
            {
                sd.DetailOrder = idx++;
            }
        }

        #endregion

    }
}
