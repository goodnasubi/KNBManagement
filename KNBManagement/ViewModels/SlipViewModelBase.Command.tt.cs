namespace KNBManagement.ViewModels
{
	using KNBManagement.ViewModels.Core;
	
    public abstract partial class SlipViewModelBase<TDomainContext> : ViewModelBase<TDomainContext> where TDomainContext : global::System.ServiceModel.DomainServices.Client.DomainContext, new()
    {
		
        #region AddSlipDetailRecord Command

		private DelegateCommand _AddSlipDetailRecordCommand;
        public DelegateCommand AddSlipDetailRecordCommand
        {
            get
            {
                return this._AddSlipDetailRecordCommand = this._AddSlipDetailRecordCommand ??
					new DelegateCommand(this.RaiseAddSlipDetailRecordExecute, this.RaiseAddSlipDetailRecordCanExecute);
            }
        }
        protected virtual void RaiseAddSlipDetailRecordExecute()
		{
		}
		protected virtual bool RaiseAddSlipDetailRecordCanExecute()
		{
			return false;
		}

		#endregion

        #region DelSlipDetailRecord Command

		private DelegateCommand _DelSlipDetailRecordCommand;
        public DelegateCommand DelSlipDetailRecordCommand
        {
            get
            {
                return this._DelSlipDetailRecordCommand = this._DelSlipDetailRecordCommand ??
					new DelegateCommand(this.RaiseDelSlipDetailRecordExecute, this.RaiseDelSlipDetailRecordCanExecute);
            }
        }
        protected virtual void RaiseDelSlipDetailRecordExecute()
		{
		}
		protected virtual bool RaiseDelSlipDetailRecordCanExecute()
		{
			return false;
		}

		#endregion

        #region UpSlipDetailRecord Command

		private DelegateCommand _UpSlipDetailRecordCommand;
        public DelegateCommand UpSlipDetailRecordCommand
        {
            get
            {
                return this._UpSlipDetailRecordCommand = this._UpSlipDetailRecordCommand ??
					new DelegateCommand(this.RaiseUpSlipDetailRecordExecute, this.RaiseUpSlipDetailRecordCanExecute);
            }
        }
        protected virtual void RaiseUpSlipDetailRecordExecute()
		{
		}
		protected virtual bool RaiseUpSlipDetailRecordCanExecute()
		{
			return false;
		}

		#endregion

        #region DownSlipDetailRecord Command

		private DelegateCommand _DownSlipDetailRecordCommand;
        public DelegateCommand DownSlipDetailRecordCommand
        {
            get
            {
                return this._DownSlipDetailRecordCommand = this._DownSlipDetailRecordCommand ??
					new DelegateCommand(this.RaiseDownSlipDetailRecordExecute, this.RaiseDownSlipDetailRecordCanExecute);
            }
        }
        protected virtual void RaiseDownSlipDetailRecordExecute()
		{
		}
		protected virtual bool RaiseDownSlipDetailRecordCanExecute()
		{
			return false;
		}

		#endregion

    }
}