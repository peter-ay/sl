
namespace ERP.ViewModel
{
    public class VMB_Supplier : VMBill
    {
        #region property

        private bool _IsEnableInCludeDepartment = false;
        /// <summary>
        /// //////////////////////////////////////////
        /// </summary>
        public bool IsEnableInCludeDepartment
        {
            get { return _IsEnableInCludeDepartment; }
            set
            {
                _IsEnableInCludeDepartment = value;
                RaisePropertyChanged<bool>(() => this.IsEnableInCludeDepartment);
            }
        }

        private bool _IsEnableInCludeMnumber = false;
        /// <summary>
        /// //////////////////////////
        /// </summary>
        public bool IsEnableInCludeMnumber
        {
            get { return _IsEnableInCludeMnumber; }
            set
            {
                _IsEnableInCludeMnumber = value;
                RaisePropertyChanged<bool>(() => this.IsEnableInCludeMnumber);
            }
        }

        private bool _IsEnableExCludeProcess = false;
        /// <summary>
        /// /////////////////////////
        /// </summary>
        public bool IsEnableExCludeProcess
        {
            get { return _IsEnableExCludeProcess; }
            set
            {
                _IsEnableExCludeProcess = value;
                RaisePropertyChanged<bool>(() => this.IsEnableExCludeProcess);
            }
        }

        #endregion

        public VMB_Supplier()
            : base("SpCode", "B_Supplier")
        {
            this.IsChildWindow = true;
        }

        #region methods
           
        protected override void ChangeBillSate(Utility.UBillState uBillState)
        {
            base.ChangeBillSate(uBillState);

            switch (uBillState)
            {
                case Utility.UBillState.New:
                case Utility.UBillState.Drop:
                    this.IsEnableExCludeProcess = false;
                    this.IsEnableInCludeDepartment = false;
                    this.IsEnableInCludeMnumber = false;
                    break;

                default:
                    this.IsEnableExCludeProcess = true;
                    this.IsEnableInCludeDepartment = true;
                    this.IsEnableInCludeMnumber = true;
                    break;
            }
        }

        #endregion 
    }
}
