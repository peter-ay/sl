
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
namespace ERP.View
{
    public partial class Sale_ContractBill_ChooseByNew : ChildWindowErp
    {
        public Sale_ContractBill_ChooseByNew()
        {
            InitializeComponent();
        }

        private List<string> rs = new List<string>();
        string cusType = "";
        string cType = "";

        protected override void OnChildWindowClosed(bool msg)
        {
            try
            {
                cusType = this.DataContext.GetType().GetProperty("CustType").GetValue(this.DataContext, null).ToString();
                cType = this.DataContext.GetType().GetProperty("CType").GetValue(this.DataContext, null).ToString();
            }
            catch
            {
                cusType = ""; cType = "XSCA";
            }
            this.DialogResult = msg;
            rs.Clear();
            rs.Add(msg.ToString());
            rs.Add(cusType);
            rs.Add(cType);
            Messenger.Default.Send<List<string>>(rs, this.GetType().Name + "_Return");
        }
    }
}

