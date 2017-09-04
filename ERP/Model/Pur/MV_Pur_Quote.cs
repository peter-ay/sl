using ERP.Utility;
using ERP.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using ERP.Common;
using System.Linq;

namespace ERP.Web.Entity
{
    partial class V_Pur_Quote
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
            this.BType = "CGQJ";
            this.SpCode = "";
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
            this.SpName = "";
            this.Maker = USysInfo.UserCode;
        }

        partial void OnSpCodeChanged()
        {
            if (this.EditState != 1) return;
            this.SpName = "";
            var item = (from c in ComHelpSpCode.UHV_B_Supplier
                        where c.SpCode.MyStr() == this.SpCode.MyStr()
                        select c).FirstOrDefault();
            if (item != null)
            {
                this.SpName = item.SpName;
            }
            ComHelpLensCode.LoadSpLensCodeSmartQupte(this.SpCode);
        }

        partial void OnLensCodeChanged()
        {
            if (EditState != 1) return;
            this.LensName = "";
            var rs = ComHelpLensCode.UHV_B_SpLensCodeSmartQuote.Where(it => it.LensCode.MyStr() == this.LensCode.MyStr()).FirstOrDefault();
            if (rs == null) return;
            this.LensName = rs.LensName;
            Messenger.Default.Send(rs.LensType == "RX", USysMessages.QuoteProcessUpdate);
        }
    }
}
