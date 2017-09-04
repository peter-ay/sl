
namespace ERP.View
{
    #region DeliveryNum

    //DeliveryNum
    public class TBDeliveryNumRO : TextBoxErp
    {
        public TBDeliveryNumRO()
            : base("DContextMain.DeliveryNum")
        {
            this.ReSetRO();
        }
    }
    //DN
    public class TBDNRO : TextBoxErp
    {
        public TBDNRO()
            : base("DContextMain.DN")
        {
            this.ReSetRO();
        }
    }
    //DeliveryNumList
    public class TBDeliveryNumList : TextBoxErp
    {
        public TBDeliveryNumList()
            : base("DeliveryNum")
        {
            this.MaxLength = 30;
        }
    }
    //DNList
    public class TBDNList : TextBoxErp
    {
        public TBDNList()
            : base("DN")
        {
            this.MaxLength = 30;
        }
    }
    //DeliveryNum1List
    public class TBDeliveryNumList1 : TextBoxErp
    {
        public TBDeliveryNumList1()
            : base("DeliveryNum1")
        {
            this.MaxLength = 30;
        }
    }
    //DeliveryNum2
    public class TBDeliveryNumList2 : TextBoxErp
    {
        public TBDeliveryNumList2()
            : base("DeliveryNum2")
        {
            this.MaxLength = 30;
        }
    }
    //DN
    public class TBDN : TextBoxErp
    {
        public TBDN()
            : base("DContextMain.DN")
        {
            this.MaxLength = 30;
        }
    }
    //UpdateDN
    public class TBUpdateDN : TextBoxErp
    {
        public TBUpdateDN()
            : base("DContextMain.UpdateDN")
        {
            this.MaxLength = 30;
        }
    }

    #endregion

    #region DeliveryDate

    //DeliveryDate
    public class TBDeliveryDateRO : TextBoxErp
    {
        public TBDeliveryDateRO()
            : base("DContextMain.DeliveryDate", convertToDateshort: true)
        {
            this.ReSetRO();
        }
    }

    #endregion

    #region DeliveryAddress

    //DeliveryAddress
    public class TBDeliveryAddress : TextBoxErp
    {
        public TBDeliveryAddress()
            : base("DContextMain.DeliveryAddress")
        {
            this.MaxLength = 100;
        }
    }
    //DeliveryAddressRO
    public class TBDeliveryAddressRO : TextBoxErp
    {
        public TBDeliveryAddressRO()
            : base("DContextMain.DeliveryAddress")
        {
            this.ReSetRO();
        }
    }

    #endregion
}

