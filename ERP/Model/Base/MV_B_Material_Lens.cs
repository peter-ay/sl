using System;
using ERP.Utility;
using GalaSoft.MvvmLight.Messaging;
using ERP.Common;
using System.Linq;
using System.Windows.Controls;

namespace ERP.Web.Entity
{
    partial class V_B_Material_Lens
    {
        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                this.RaisePropertyChanged("IsSelected");
                Messenger.Default.Send<USelectedBillCodes>(
   new USelectedBillCodes()
   {
       IsAdd = value,
       SelectedBillCode = this.LensCode,
       VMName = this.LensLevel == 1 ? this.GetType().Name.Substring(2) : this.GetType().Name.Substring(2) + "_Sale"
   }, USysMessages.UpdateSelectedCode);
            }
        }

        //private string _LensTypeNameUI;
        //public string LensTypeNameUI
        //{
        //    set
        //    {
        //        this.RaisePropertyChanged("LensTypeNameUI");
        //    }
        //    get
        //    {
        //        return this.LensTypeName.UIStr();
        //    }
        //}

        private string msg;
        public string Msg
        {
            get { return msg; }
            set
            {
                msg = value;
                this.RaisePropertyChanged("Msg");
            }
        }

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
            this.LensCode = "";
            this.LensLevel = 1;
            this.LensName = "";
            this.SPH1 = 0;
            this.SPH2 = 0;
            this.CYL1 = 0;
            this.CYL2 = 0;
            this.X_ADD1 = 0;
            this.X_ADD2 = 0;
            this.Materials = "";
            this.RIndex = "";
            this.Design = "";
            this.DefaultCoating = "";
            this.Usage = "";
            this.Focus = "";
            this.Material = "";
            this.Density = "";
            this.Abbe = 0;
            this.RIndex_Measured = "";
            this.UVCutOff = 0;
            this.PrismAvailability = "";
            this.Colour = "";
            this.Corridor = "";
            this.Fitting = "";
            this.LensType = "";
            this.F_HardCoat = false;
            this.F_Tintage = false;
            this.F_Coating = false;
            this.F_Decenter = false;
            this.F_Prism = false;
            this.F_Base = false;
            this.F_LR = false;
            this.F_CA = false;
            this.F_Pur = false;
            this.F_Stop = false;
            this.Sort1 = "";
            this.Sort2 = "";
            this.Transmistion1 = "";
            this.Transmistion2 = "";
            this.Purpose = "";
            this.Criterion1 = "";
            this.Criterion2 = "";
            this.ReformulatedPower = false;
            this.Ctvalue = false;
            this.Attachment1 = "";
            this.SPHList = "";
            this.CYLList = "";
            this.X_ADDList = "";
            this.DesignName = "";
            this.FocusName = "";
            this.DefaultCoatingName = "";
            this.RIndexName = "";
            this.MaterialsName = "";
            this.UsageName = "";
            this.LensTypeName = "";
            this.PCode = "";
            this.Brand = "";
            this.Modelselect = "";
            this.Bagcode = "";
            this.Guarantee = "";
            this.F_StopSale = false;
            this.Image1 = "";
            this.Image2 = "";
            this.Image3 = "";
            this.Df_SpCode = "";
        }

        partial void OnRIndexChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpLensClass.UHV_B_Material_LensClass_Index
                        where c.KeyCode.MyStr() == this.RIndex.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.RIndexName = "";
            else
                this.RIndexName = item.KeyName;
            this.ResetFinalCode();
        }

        private void ResetFinalCode()
        {
            if (this.LensLevel != 1) return;
            this.LensCode = this.Focus.Trim() + this.RIndex.Trim() + this.Design.Trim() + this.DefaultCoating.Trim() + this.Usage.Trim();
            this.LensName = this.FocusName.Trim() + this.RIndexName.Trim() + this.DesignName.Trim() + this.DefaultCoatingName.Trim() + this.UsageName.Trim();
        }

        partial void OnDesignChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpLensClass.UHV_B_Material_LensClass_Design
                        where c.KeyCode.MyStr() == this.Design.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.DesignName = "";
            else
                this.DesignName = item.KeyName;
            this.ResetFinalCode();
        }

        partial void OnFocusChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpLensClass.UHV_B_Material_LensClass_Focus
                        where c.KeyCode.MyStr() == this.Focus.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.FocusName = "";
            else
                this.FocusName = item.KeyName;
            this.ResetFinalCode();
        }

        partial void OnUsageChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpLensClass.UHV_B_Material_LensClass_Usage
                        where c.KeyCode.MyStr() == this.Usage.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.UsageName = "";
            else
                this.UsageName = item.KeyName;
            this.ResetFinalCode();
        }

        partial void OnMaterialsChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpLensClass.UHV_B_Material_LensClass_Materials
                        where c.KeyCode.MyStr() == this.Materials.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.MaterialsName = "";
            else
                this.MaterialsName = item.KeyName;
        }

        partial void OnDefaultCoatingChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpLensClass.UHV_B_Material_LensClass_DefaultCoating
                        where c.KeyCode.MyStr() == this.DefaultCoating.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.DefaultCoatingName = "";
            else
                this.DefaultCoatingName = item.KeyName;
            this.ResetFinalCode();
        }

        partial void OnBrandChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpLensClass.UHV_B_Material_LensClass_Brand
                        where c.KeyCode.MyStr() == this.Brand.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.BrandName = "";
            else
                this.BrandName = item.KeyName;
        }

        partial void OnDf_SpCodeChanged()
        {
            if (this.EditState != 1) return;
            var item = (from c in ComHelpSpCode.UHV_B_Supplier
                        where c.SpCode.MyStr() == this.Df_SpCode.MyStr()
                        select c).FirstOrDefault();
            if (item == null)
                this.Df_SpName = "";
            else
                this.Df_SpName = item.SpName;
        }

        partial void OnPCodeChanged()
        {
            if (this.EditState != 1) return;
            //V_B_Material_Lens it = null;
            var _DDs = ComDDSFactory.Get(ComDSFactory.Erp, "GetV_B_Material_Lens_GeneralBillQuery", dds_LoadedData, true);
            _DDs.QueryParameters.Add(new Parameter() { ParameterName = "lensCode", Value = this.PCode });
            _DDs.Load();
        }

        private static void dds_LoadedData(object sender, LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                e.MarkErrorAsHandled();
                return;
            }
            if (e.Entities.Count() <= 0)
                return;
            V_B_Material_Lens it = e.Entities.FirstOrDefault() as V_B_Material_Lens;
            Messenger.Default.Send(it, "VMB_Material_Lens_Sale_FillFromPCode");
        }

    }
}
