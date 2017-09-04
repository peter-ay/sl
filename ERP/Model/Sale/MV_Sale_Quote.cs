using ERP.Utility;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using ERP.Common;
using System.Linq;

namespace ERP.Web.Entity
{
    partial class V_Sale_Quote
    {
        private int _EditState = 0;
        public int EditState
        {
            get { return _EditState; }
            set
            {
                _EditState = value;
                this.RaisePropertyChanged("EditState");
            }
        }

        partial void OnCreated()
        {
            this.EditState = 1;
            this.BType = "SDQJ";
            this.CusCode = "";
            this.Dia = 0;
            this.LensCode = "";
            this.SPH = 0;
            this.CYL = 0;
            this.Axis = 0;
            this.X_ADD = 0;
            this.Qty = 1;
            this.BASE = "";
            this.CT = "";
            this.DB = false;
            this.D1 = "";
            this.D2 = "";
            this.D3 = "";
            this.D4 = "";
            this.P1 = "";
            this.P2 = "";
            this.P3 = "";
            this.P4 = "";
            this.Price = 0;
            this.PriceJM = 0;
            this.ProCost = 0;
            this.InvTitle = "";
            this.BCodePC = "";
            this.ProReport = "";
            this.ProCostReport = "";
            this.JY = false;
            this.UV = false;
            this.JS = "";
            this.RS = "";
            this.RSName = "";
            this.CS = "";
            this.SY = "";
            this.CB = "";
            this.ChB = "";
            this.KK = "";
            this.ZK = "";
            this.PiH = "";
            this.PG = "";
            this.JJ = "";
            this.OP = "";
            this.CusName = "";
            this.Maker = USysInfo.UserCode;
        }

        partial void OnCusCodeChanged()
        {
            if (this.EditState != 1) return;
            this.CusName = "";
            var item = (from c in ComHelpCusCode.UHV_B_Customer
                        where c.CusCode.MyStr() == this.CusCode.MyStr()
                        select c).FirstOrDefault();
            if (item != null)
            {
                this.CusName = item.CusName;
            }
            ComHelpLensCode.LoadCusLensCodeSmartQupte(this.CusCode);
        }

        partial void OnLensCodeChanged()
        {
            if (EditState != 1) return;
            this.LensName = "";
            var rs = ComHelpLensCode.UHV_B_CusLensCodeSmartQuote.Where(it => it.LensCode.MyStr() == this.LensCode.MyStr()).FirstOrDefault();
            if (rs == null) return;
            this.LensName = rs.LensName;
            Messenger.Default.Send(rs.LensType == "RX", USysMessages.QuoteProcessUpdate);
        }
    }
}
