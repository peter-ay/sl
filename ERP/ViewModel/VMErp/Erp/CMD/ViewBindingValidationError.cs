using System;
using System.Collections.Generic;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;

namespace ERP.ViewModel
{
    public partial class VMErp
    {
        private RelayCommand<ValidationErrorEventArgs> _CmdViewBindingValidationError;

        /// <summary>
        /// Gets the CmdViewBindingValidationError.
        /// </summary>
        public RelayCommand<ValidationErrorEventArgs> CmdViewBindingValidationError
        {
            get
            {
                return _CmdViewBindingValidationError ?? (_CmdViewBindingValidationError = new RelayCommand<ValidationErrorEventArgs>(ExecuteCmdViewBindingValidationError));
            }
        }

        protected Lazy<List<string>> ViewErrList
        {
            get;
            set;
        }

        protected virtual void ExecuteCmdViewBindingValidationError(ValidationErrorEventArgs parameter)
        {
            ViewErrList = ViewErrList ?? new Lazy<List<string>>();

            if (parameter.Action == ValidationErrorEventAction.Added)
            {
                this.ViewErrList.Value.Add(parameter.OriginalSource.ToString());
            }
            else
            {
                this.ViewErrList.Value.Remove(parameter.OriginalSource.ToString());
            }
        }

    }
}
