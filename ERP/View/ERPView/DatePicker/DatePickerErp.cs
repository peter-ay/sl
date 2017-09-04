using ERP.Converters;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ERP.View
{
    public class DatePickerErp : DatePicker
    {
        public DatePickerErp(string bingPath)
            : this()
        {
            var binding = new Binding(bingPath)
            {
                Mode = BindingMode.TwoWay,
                ValidatesOnNotifyDataErrors = false,
                Converter = new ToShortDataString()
            };
            this.SetBinding(DatePicker.TextProperty, binding);
        }

        public DatePickerErp()
            : base()
        {
            this.FontFamily = new FontFamily("Verdana");
            this.FontSize = 12;
            this.Height = 22;
        }

        public void SetIsEnabled(string bingcode = "TB_Falg_RO")
        {
            var binding = new Binding("IsReadOnly")
            {
                Converter = new ReadOnlyToEnable(),
                ElementName = bingcode
            };
            this.SetBinding(DatePicker.IsEnabledProperty, binding);
        }

        public void SetIsShow(string isShowName = "IsShowDP")
        {
            var bindingis = new Binding(isShowName);
            this.SetBinding(DatePicker.VisibilityProperty, bindingis);
        }
    }

    public class DatePickerD1 : DatePickerErp
    {
        public DatePickerD1() :
            base("D1")
        { }
    }

    public class DatePickerD2 : DatePickerErp
    {
        public DatePickerD2() :
            base("D2")
        { }
    }


    public class DatePickerBillDate : DatePickerErp
    {
        public DatePickerBillDate() :
            base("DContextMain.BillDate")
        {
            base.SetIsEnabled();
            base.SetIsShow();
        }
    }

    public class DatePickerCsDate : DatePickerErp
    {
        public DatePickerCsDate() :
            base("DContextMain.CsDate")
        {
            base.SetIsEnabled();
            base.SetIsShow();
        }
    }

    public class DatePickerBegDate : DatePickerErp
    {
        public DatePickerBegDate() :
            base("DContextMain.BegDate")
        {
            base.SetIsEnabled();
            base.SetIsShow();
        }
    }

    public class DatePickerBeginDate : DatePickerErp
    {
        public DatePickerBeginDate() :
            base("DContextMain.BeginDate")
        {
            base.SetIsEnabled();
        }
    }

    public class DatePickerEndDate : DatePickerErp
    {
        public DatePickerEndDate() :
            base("DContextMain.EndDate")
        {
            base.SetIsEnabled();
            base.SetIsShow();
        }
    }








}
