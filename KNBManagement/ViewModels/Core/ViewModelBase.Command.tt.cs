namespace KNBManagement.ViewModels.Core
{
	using KNBManagement.ViewModels.Core;
	
    public abstract partial class ViewModelBase
    {
		
        #region Add Command

		private DelegateCommand _AddCommand;
        public DelegateCommand AddCommand
        {
            get
            {
                return this._AddCommand = this._AddCommand ??
					new DelegateCommand(this.RaiseAddExecute, this.RaiseAddCanExecute);
            }
        }
        protected virtual void RaiseAddExecute()
		{
		}
		protected virtual bool RaiseAddCanExecute()
		{
			return false;
		}

		#endregion

        #region Reg Command

		private DelegateCommand _RegCommand;
        public DelegateCommand RegCommand
        {
            get
            {
                return this._RegCommand = this._RegCommand ??
					new DelegateCommand(this.RaiseRegExecute, this.RaiseRegCanExecute);
            }
        }
        protected virtual void RaiseRegExecute()
		{
		}
		protected virtual bool RaiseRegCanExecute()
		{
			return false;
		}

		#endregion

        #region Edit Command

		private DelegateCommand _EditCommand;
        public DelegateCommand EditCommand
        {
            get
            {
                return this._EditCommand = this._EditCommand ??
					new DelegateCommand(this.RaiseEditExecute, this.RaiseEditCanExecute);
            }
        }
        protected virtual void RaiseEditExecute()
		{
		}
		protected virtual bool RaiseEditCanExecute()
		{
			return false;
		}

		#endregion

        #region Update Command

		private DelegateCommand _UpdateCommand;
        public DelegateCommand UpdateCommand
        {
            get
            {
                return this._UpdateCommand = this._UpdateCommand ??
					new DelegateCommand(this.RaiseUpdateExecute, this.RaiseUpdateCanExecute);
            }
        }
        protected virtual void RaiseUpdateExecute()
		{
		}
		protected virtual bool RaiseUpdateCanExecute()
		{
			return false;
		}

		#endregion

        #region Cancel Command

		private DelegateCommand _CancelCommand;
        public DelegateCommand CancelCommand
        {
            get
            {
                return this._CancelCommand = this._CancelCommand ??
					new DelegateCommand(this.RaiseCancelExecute, this.RaiseCancelCanExecute);
            }
        }
        protected virtual void RaiseCancelExecute()
		{
		}
		protected virtual bool RaiseCancelCanExecute()
		{
			return false;
		}

		#endregion

    }
}