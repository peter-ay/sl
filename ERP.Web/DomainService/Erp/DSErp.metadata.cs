
namespace ERP.Web.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies V_B_AreaMetadata as the class
    // that carries additional metadata for the V_B_Area class.
    [MetadataTypeAttribute(typeof(V_B_Area.V_B_AreaMetadata))]
    public partial class V_B_Area
    {

        // This class allows you to attach custom attributes to properties
        // of the V_B_Area class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_B_AreaMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_B_AreaMetadata()
            {
            }

            public string AreaCode { get; set; }

            public string AreaName { get; set; }

            public string PCode { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_B_CustomerMetadata as the class
    // that carries additional metadata for the V_B_Customer class.
    [MetadataTypeAttribute(typeof(V_B_Customer.V_B_CustomerMetadata))]
    public partial class V_B_Customer
    {

        // This class allows you to attach custom attributes to properties
        // of the V_B_Customer class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_B_CustomerMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_B_CustomerMetadata()
            {
            }

            public string AreaCode { get; set; }

            public string AreaName { get; set; }

            public string BarCode { get; set; }

            public string BrowseRight { get; set; }

            public string ContactPerson { get; set; }

            public string CusAddress { get; set; }

            public string CusCode { get; set; }

            public string CusName { get; set; }

            public string DAddress { get; set; }

            public string DpCode { get; set; }

            public string DpCodeCX { get; set; }

            public string DpName { get; set; }

            public string DpNameCX { get; set; }

            public string Email { get; set; }

            public Nullable<bool> F_NoticeRepeatOBill { get; set; }

            public Nullable<bool> F_Stop { get; set; }

            public string Fax { get; set; }

            public string PCode { get; set; }

            public string PersonCode { get; set; }

            public string PersonName { get; set; }

            public string PrintCode { get; set; }

            public Nullable<byte> PrintShowPriceType { get; set; }

            public string Remark { get; set; }

            public string Tel { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_B_Customer_AccMetadata as the class
    // that carries additional metadata for the V_B_Customer_Acc class.
    [MetadataTypeAttribute(typeof(V_B_Customer_Acc.V_B_Customer_AccMetadata))]
    public partial class V_B_Customer_Acc
    {

        // This class allows you to attach custom attributes to properties
        // of the V_B_Customer_Acc class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_B_Customer_AccMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_B_Customer_AccMetadata()
            {
            }

            public string AccCusCode { get; set; }

            public string AccCusName { get; set; }

            public int AccEndDate { get; set; }

            public Nullable<decimal> AccLimit { get; set; }

            public string PCode { get; set; }

            public Nullable<int> SumCusCode { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_B_Customer_MainMetadata as the class
    // that carries additional metadata for the V_B_Customer_Main class.
    [MetadataTypeAttribute(typeof(V_B_Customer_Main.V_B_Customer_MainMetadata))]
    public partial class V_B_Customer_Main
    {

        // This class allows you to attach custom attributes to properties
        // of the V_B_Customer_Main class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_B_Customer_MainMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_B_Customer_MainMetadata()
            {
            }

            public string MainCusCode { get; set; }

            public string MainCusName { get; set; }

            public Nullable<int> SumAccCusCode { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_B_Material_FrameMetadata as the class
    // that carries additional metadata for the V_B_Material_Frame class.
    [MetadataTypeAttribute(typeof(V_B_Material_Frame.V_B_Material_FrameMetadata))]
    public partial class V_B_Material_Frame
    {

        // This class allows you to attach custom attributes to properties
        // of the V_B_Material_Frame class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_B_Material_FrameMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_B_Material_FrameMetadata()
            {
            }

            public string Brand { get; set; }

            public Nullable<decimal> Bridge { get; set; }

            public string Colour { get; set; }

            public string Family { get; set; }

            public string FrameCode { get; set; }

            public string FrameName { get; set; }

            public Nullable<decimal> Heigh { get; set; }

            public Nullable<decimal> Leg_Length { get; set; }

            public string Material { get; set; }

            public string Origin { get; set; }

            public Nullable<decimal> Width { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_B_Material_LensClass_DefaultCoatingMetadata as the class
    // that carries additional metadata for the V_B_Material_LensClass_DefaultCoating class.
    [MetadataTypeAttribute(typeof(V_B_Material_LensClass_DefaultCoating.V_B_Material_LensClass_DefaultCoatingMetadata))]
    public partial class V_B_Material_LensClass_DefaultCoating
    {

        // This class allows you to attach custom attributes to properties
        // of the V_B_Material_LensClass_DefaultCoating class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_B_Material_LensClass_DefaultCoatingMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_B_Material_LensClass_DefaultCoatingMetadata()
            {
            }

            public string KeyCode { get; set; }

            public string KeyName { get; set; }

            public Nullable<int> SN { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_B_Material_LensSmartMetadata as the class
    // that carries additional metadata for the V_B_Material_LensSmart class.
    [MetadataTypeAttribute(typeof(V_B_Material_LensSmart.V_B_Material_LensSmartMetadata))]
    public partial class V_B_Material_LensSmart
    {

        // This class allows you to attach custom attributes to properties
        // of the V_B_Material_LensSmart class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_B_Material_LensSmartMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_B_Material_LensSmartMetadata()
            {
            }

            public Nullable<int> CYL1 { get; set; }

            public Nullable<int> CYL2 { get; set; }

            public Nullable<bool> F_CA { get; set; }

            public Nullable<bool> F_LR { get; set; }

            public Nullable<bool> F_Pur { get; set; }

            public Nullable<bool> F_Stop { get; set; }

            public Nullable<bool> F_StopSale { get; set; }

            public string LensCode { get; set; }

            public Nullable<byte> LensLevel { get; set; }

            public string LensName { get; set; }

            public string LensType { get; set; }

            public Nullable<int> SPH1 { get; set; }

            public Nullable<int> SPH2 { get; set; }

            public Nullable<int> X_ADD1 { get; set; }

            public Nullable<int> X_ADD2 { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_B_Material_ProcessMetadata as the class
    // that carries additional metadata for the V_B_Material_Process class.
    [MetadataTypeAttribute(typeof(V_B_Material_Process.V_B_Material_ProcessMetadata))]
    public partial class V_B_Material_Process
    {

        // This class allows you to attach custom attributes to properties
        // of the V_B_Material_Process class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_B_Material_ProcessMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_B_Material_ProcessMetadata()
            {
            }

            public Nullable<bool> F_RX { get; set; }

            public Nullable<bool> F_ST { get; set; }

            public string ProClass { get; set; }

            public string ProClassName { get; set; }

            public string ProCode { get; set; }

            public string ProName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_B_PersonMetadata as the class
    // that carries additional metadata for the V_B_Person class.
    [MetadataTypeAttribute(typeof(V_B_Person.V_B_PersonMetadata))]
    public partial class V_B_Person
    {

        // This class allows you to attach custom attributes to properties
        // of the V_B_Person class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_B_PersonMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_B_PersonMetadata()
            {
            }

            public string DpCode { get; set; }

            public string DpName { get; set; }

            public string PersonCode { get; set; }

            public string PersonName { get; set; }

            public string PersonProperty { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_B_SupplierMetadata as the class
    // that carries additional metadata for the V_B_Supplier class.
    [MetadataTypeAttribute(typeof(V_B_Supplier.V_B_SupplierMetadata))]
    public partial class V_B_Supplier
    {

        // This class allows you to attach custom attributes to properties
        // of the V_B_Supplier class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_B_SupplierMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_B_SupplierMetadata()
            {
            }

            public string AreaCode { get; set; }

            public string AreaName { get; set; }

            public string BrowseRight { get; set; }

            public string ContactPerson { get; set; }

            public Nullable<int> Default_Priority { get; set; }

            public string Email { get; set; }

            public Nullable<bool> F_Comprehensive { get; set; }

            public Nullable<bool> F_Cutting_Type { get; set; }

            public Nullable<bool> F_Garages { get; set; }

            public Nullable<bool> F_Semifinished { get; set; }

            public Nullable<bool> F_Stock { get; set; }

            public Nullable<bool> F_Stop { get; set; }

            public string Fax { get; set; }

            public string Phone { get; set; }

            public string SpAddress { get; set; }

            public string SpCode { get; set; }

            public string SpName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_B_Supplier_DefaultMetadata as the class
    // that carries additional metadata for the V_B_Supplier_Default class.
    [MetadataTypeAttribute(typeof(V_B_Supplier_Default.V_B_Supplier_DefaultMetadata))]
    public partial class V_B_Supplier_Default
    {

        // This class allows you to attach custom attributes to properties
        // of the V_B_Supplier_Default class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_B_Supplier_DefaultMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_B_Supplier_DefaultMetadata()
            {
            }

            public string SpCode { get; set; }

            public string SpName { get; set; }

            public Nullable<int> SumCusCode { get; set; }

            public Nullable<int> SumLensCode { get; set; }

            public Nullable<int> SumProCode { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_B_Supplier_Default_LensMetadata as the class
    // that carries additional metadata for the V_B_Supplier_Default_Lens class.
    [MetadataTypeAttribute(typeof(V_B_Supplier_Default_Lens.V_B_Supplier_Default_LensMetadata))]
    public partial class V_B_Supplier_Default_Lens
    {

        // This class allows you to attach custom attributes to properties
        // of the V_B_Supplier_Default_Lens class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_B_Supplier_Default_LensMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_B_Supplier_Default_LensMetadata()
            {
            }

            public string LensCode { get; set; }

            public string SpCode { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_B_Supplier_Default_ProCodeMetadata as the class
    // that carries additional metadata for the V_B_Supplier_Default_ProCode class.
    [MetadataTypeAttribute(typeof(V_B_Supplier_Default_ProCode.V_B_Supplier_Default_ProCodeMetadata))]
    public partial class V_B_Supplier_Default_ProCode
    {

        // This class allows you to attach custom attributes to properties
        // of the V_B_Supplier_Default_ProCode class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_B_Supplier_Default_ProCodeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_B_Supplier_Default_ProCodeMetadata()
            {
            }

            public string ProCode { get; set; }

            public string SpCode { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Pur_Order_LensMetadata as the class
    // that carries additional metadata for the V_Pur_Order_Lens class.
    [MetadataTypeAttribute(typeof(V_Pur_Order_Lens.V_Pur_Order_LensMetadata))]
    public partial class V_Pur_Order_Lens
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Pur_Order_Lens class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Pur_Order_LensMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Pur_Order_LensMetadata()
            {
            }

            public string BCode { get; set; }

            public string BCodeSale { get; set; }

            public Nullable<DateTime> BDate { get; set; }

            public Nullable<DateTime> BDateSale { get; set; }

            public string BrowseRight { get; set; }

            public string BType { get; set; }

            public Nullable<DateTime> ChDate { get; set; }

            public string Checker { get; set; }

            public string ChName { get; set; }

            public string CusCodeSale { get; set; }

            public string CusNameSale { get; set; }

            public Nullable<int> CYLL { get; set; }

            public Nullable<int> CYLR { get; set; }

            public Nullable<DateTime> DelDate { get; set; }

            public string Deler { get; set; }

            public string DelName { get; set; }

            public string DpCode { get; set; }

            public Nullable<bool> F_Del { get; set; }

            public string FBCode { get; set; }

            public string ID { get; set; }

            public string LensCodeL { get; set; }

            public string LensCodeR { get; set; }

            public string LensNameL { get; set; }

            public string LensNameR { get; set; }

            public string Maker { get; set; }

            public Nullable<DateTime> MDate { get; set; }

            public string MName { get; set; }

            public string OBCodeSale { get; set; }

            public string PCID { get; set; }

            public Nullable<DateTime> RecDate { get; set; }

            public string Remark { get; set; }

            public string SpCode { get; set; }

            public Nullable<int> SPHL { get; set; }

            public Nullable<int> SPHR { get; set; }

            public string SpName { get; set; }

            public string StCode { get; set; }

            public Nullable<int> SumQty { get; set; }

            public Nullable<int> X_ADDL { get; set; }

            public Nullable<int> X_ADDR { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_Base_NoteMetadata as the class
    // that carries additional metadata for the V_Sale_Base_Note class.
    [MetadataTypeAttribute(typeof(V_Sale_Base_Note.V_Sale_Base_NoteMetadata))]
    public partial class V_Sale_Base_Note
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_Base_Note class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_Base_NoteMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_Base_NoteMetadata()
            {
            }

            public string KeyCode { get; set; }

            public string KeyName { get; set; }

            public Nullable<int> SN { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_Base_ReOrderReasonMetadata as the class
    // that carries additional metadata for the V_Sale_Base_ReOrderReason class.
    [MetadataTypeAttribute(typeof(V_Sale_Base_ReOrderReason.V_Sale_Base_ReOrderReasonMetadata))]
    public partial class V_Sale_Base_ReOrderReason
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_Base_ReOrderReason class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_Base_ReOrderReasonMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_Base_ReOrderReasonMetadata()
            {
            }

            public string KeyCode { get; set; }

            public string KeyName { get; set; }

            public Nullable<int> SN { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_Order_FDMetadata as the class
    // that carries additional metadata for the V_Sale_Order_FD class.
    [MetadataTypeAttribute(typeof(V_Sale_Order_FD.V_Sale_Order_FDMetadata))]
    public partial class V_Sale_Order_FD
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_Order_FD class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_Order_FDMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_Order_FDMetadata()
            {
            }

            public string BCode { get; set; }

            public Nullable<DateTime> BDate { get; set; }

            public string BrowseRight { get; set; }

            public string BType { get; set; }

            public Nullable<DateTime> ChDate { get; set; }

            public string Checker { get; set; }

            public string ChName { get; set; }

            public Nullable<DateTime> CsDate { get; set; }

            public string CusCode { get; set; }

            public string CusName { get; set; }

            public string FBCode { get; set; }

            public string FrameCode1 { get; set; }

            public string FrameCode10 { get; set; }

            public string FrameCode2 { get; set; }

            public string FrameCode3 { get; set; }

            public string FrameCode4 { get; set; }

            public string FrameCode5 { get; set; }

            public string FrameCode6 { get; set; }

            public string FrameCode7 { get; set; }

            public string FrameCode8 { get; set; }

            public string FrameCode9 { get; set; }

            public string FrameName1 { get; set; }

            public string FrameName10 { get; set; }

            public string FrameName2 { get; set; }

            public string FrameName3 { get; set; }

            public string FrameName4 { get; set; }

            public string FrameName5 { get; set; }

            public string FrameName6 { get; set; }

            public string FrameName7 { get; set; }

            public string FrameName8 { get; set; }

            public string FrameName9 { get; set; }

            public Nullable<decimal> Freight { get; set; }

            public string ID { get; set; }

            public string Maker { get; set; }

            public Nullable<DateTime> MDate { get; set; }

            public string MName { get; set; }

            public string Notes { get; set; }

            public string OBCode { get; set; }

            public Nullable<byte> OGType { get; set; }

            public int Qty1 { get; set; }

            public int Qty10 { get; set; }

            public int Qty2 { get; set; }

            public int Qty3 { get; set; }

            public int Qty4 { get; set; }

            public int Qty5 { get; set; }

            public int Qty6 { get; set; }

            public int Qty7 { get; set; }

            public int Qty8 { get; set; }

            public int Qty9 { get; set; }

            public int QtyCs1 { get; set; }

            public int QtyCs10 { get; set; }

            public int QtyCs2 { get; set; }

            public int QtyCs3 { get; set; }

            public int QtyCs4 { get; set; }

            public int QtyCs5 { get; set; }

            public int QtyCs6 { get; set; }

            public int QtyCs7 { get; set; }

            public int QtyCs8 { get; set; }

            public int QtyCs9 { get; set; }

            public int QtyRt1 { get; set; }

            public int QtyRt10 { get; set; }

            public int QtyRt2 { get; set; }

            public int QtyRt3 { get; set; }

            public int QtyRt4 { get; set; }

            public int QtyRt5 { get; set; }

            public int QtyRt6 { get; set; }

            public int QtyRt7 { get; set; }

            public int QtyRt8 { get; set; }

            public int QtyRt9 { get; set; }

            public string Remark { get; set; }

            public string SpCode { get; set; }

            public string StCode { get; set; }

            public string StName { get; set; }

            public string TypeName { get; set; }

            public Nullable<byte> UD { get; set; }

            public string WhCode { get; set; }

            public string WhName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_Order_FrameMetadata as the class
    // that carries additional metadata for the V_Sale_Order_Frame class.
    [MetadataTypeAttribute(typeof(V_Sale_Order_Frame.V_Sale_Order_FrameMetadata))]
    public partial class V_Sale_Order_Frame
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_Order_Frame class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_Order_FrameMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_Order_FrameMetadata()
            {
            }

            public string BCode { get; set; }

            public Nullable<DateTime> BDate { get; set; }

            public string BrowseRight { get; set; }

            public string BType { get; set; }

            public string Checker { get; set; }

            public Nullable<DateTime> CsDate { get; set; }

            public string CusCode { get; set; }

            public string CusName { get; set; }

            public Nullable<DateTime> DDate { get; set; }

            public string DN { get; set; }

            public string FBCode { get; set; }

            public string FrameCode { get; set; }

            public string ID { get; set; }

            public string Maker { get; set; }

            public string Notes { get; set; }

            public string OBCode { get; set; }

            public string Remark { get; set; }

            public string SpCode { get; set; }

            public string SpName { get; set; }

            public string StCode { get; set; }

            public string StName { get; set; }

            public Nullable<int> SumQty { get; set; }

            public Nullable<int> SumQtyCs { get; set; }

            public Nullable<int> SumQtyPur { get; set; }

            public Nullable<int> SumQtyRt { get; set; }

            public Nullable<byte> UD { get; set; }

            public string UDName { get; set; }

            public string WhCode { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_Order_LensMetadata as the class
    // that carries additional metadata for the V_Sale_Order_Lens class.
    [MetadataTypeAttribute(typeof(V_Sale_Order_Lens.V_Sale_Order_LensMetadata))]
    public partial class V_Sale_Order_Lens
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_Order_Lens class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_Order_LensMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_Order_LensMetadata()
            {
            }

            public string BarCodePre { get; set; }

            public string BCode { get; set; }

            public Nullable<DateTime> BDate { get; set; }

            public string BrowseRight { get; set; }

            public string BType { get; set; }

            public string BTypeName { get; set; }

            public string Checker { get; set; }

            public Nullable<DateTime> CsDate { get; set; }

            public string CusCode { get; set; }

            public string CusName { get; set; }

            public Nullable<int> CYLL { get; set; }

            public Nullable<int> CYLR { get; set; }

            public string FBCode { get; set; }

            public string ID { get; set; }

            public string LensCodeL { get; set; }

            public string LensCodeLList { get; set; }

            public string LensCodeR { get; set; }

            public string LensCodeRList { get; set; }

            public string LensNameL { get; set; }

            public string LensNameR { get; set; }

            public string LensType { get; set; }

            public string Maker { get; set; }

            public string Notes { get; set; }

            public string OBCode { get; set; }

            public Nullable<byte> OGType { get; set; }

            public Nullable<decimal> PriceL { get; set; }

            public Nullable<decimal> PriceR { get; set; }

            public Nullable<decimal> ProCostL { get; set; }

            public Nullable<decimal> ProCostR { get; set; }

            public Nullable<int> QtyL { get; set; }

            public Nullable<int> QtyR { get; set; }

            public string Remark { get; set; }

            public string Rt5 { get; set; }

            public string SN { get; set; }

            public string SpCode { get; set; }

            public Nullable<int> SPHL { get; set; }

            public Nullable<int> SPHR { get; set; }

            public string SpName { get; set; }

            public string StCode { get; set; }

            public string StName { get; set; }

            public Nullable<decimal> SumMoney { get; set; }

            public Nullable<int> SumQty { get; set; }

            public Nullable<byte> UD { get; set; }

            public string UDName { get; set; }

            public string WhCode { get; set; }

            public Nullable<int> X_ADDL { get; set; }

            public Nullable<int> X_ADDR { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_Order_PDMetadata as the class
    // that carries additional metadata for the V_Sale_Order_PD class.
    [MetadataTypeAttribute(typeof(V_Sale_Order_PD.V_Sale_Order_PDMetadata))]
    public partial class V_Sale_Order_PD
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_Order_PD class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_Order_PDMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_Order_PDMetadata()
            {
            }

            public string BCode { get; set; }

            public Nullable<DateTime> BDate { get; set; }

            public string BrowseRight { get; set; }

            public string BType { get; set; }

            public Nullable<DateTime> ChDate { get; set; }

            public string Checker { get; set; }

            public string ChName { get; set; }

            public Nullable<DateTime> CsDate { get; set; }

            public string CusCode { get; set; }

            public string CusName { get; set; }

            public string DpCodeWG { get; set; }

            public string F_LR { get; set; }

            public string FBCode { get; set; }

            public Nullable<decimal> Freight { get; set; }

            public string ID { get; set; }

            public string LensCode { get; set; }

            public string LensCodeR { get; set; }

            public string LensName { get; set; }

            public string LensNameR { get; set; }

            public string Maker { get; set; }

            public Nullable<DateTime> MDate { get; set; }

            public string MName { get; set; }

            public string Notes { get; set; }

            public string OBCode { get; set; }

            public Nullable<byte> OGType { get; set; }

            public string Remark { get; set; }

            public string SN { get; set; }

            public string SpCode { get; set; }

            public string SpName { get; set; }

            public string StCode { get; set; }

            public string StName { get; set; }

            public string TypeName { get; set; }

            public Nullable<byte> UD { get; set; }

            public string WhCode { get; set; }

            public string WhName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_Order_PD_DetailMetadata as the class
    // that carries additional metadata for the V_Sale_Order_PD_Detail class.
    [MetadataTypeAttribute(typeof(V_Sale_Order_PD_Detail.V_Sale_Order_PD_DetailMetadata))]
    public partial class V_Sale_Order_PD_Detail
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_Order_PD_Detail class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_Order_PD_DetailMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_Order_PD_DetailMetadata()
            {
            }

            public Nullable<int> CYL { get; set; }

            public string ID { get; set; }

            public Nullable<decimal> Price { get; set; }

            public Nullable<int> Qty { get; set; }

            public Nullable<int> QtyCs { get; set; }

            public Nullable<int> QtyPur { get; set; }

            public Nullable<int> QtyRec { get; set; }

            public Nullable<int> QtyRt { get; set; }

            public Nullable<int> QtySO { get; set; }

            public Nullable<int> QtyUnCs { get; set; }

            public Nullable<int> QtyUnSO { get; set; }

            public Nullable<int> SPH { get; set; }

            public int SubID { get; set; }

            public Nullable<int> X_ADD { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_Order_SDMetadata as the class
    // that carries additional metadata for the V_Sale_Order_SD class.
    [MetadataTypeAttribute(typeof(V_Sale_Order_SD.V_Sale_Order_SDMetadata))]
    public partial class V_Sale_Order_SD
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_Order_SD class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_Order_SDMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_Order_SDMetadata()
            {
            }

            public Nullable<int> AxisL { get; set; }

            public Nullable<int> AxisR { get; set; }

            public string BarCodePre { get; set; }

            public string BASEL { get; set; }

            public string BASER { get; set; }

            public string BCode { get; set; }

            public Nullable<DateTime> BDate { get; set; }

            public string BrowseRight { get; set; }

            public string BType { get; set; }

            public string CB { get; set; }

            public string ChB { get; set; }

            public Nullable<DateTime> ChDate { get; set; }

            public string Checker { get; set; }

            public string ChName { get; set; }

            public string CS { get; set; }

            public Nullable<DateTime> CsDate { get; set; }

            public string CTL { get; set; }

            public string CTR { get; set; }

            public string CusCode { get; set; }

            public string CusName { get; set; }

            public Nullable<byte> CXType { get; set; }

            public Nullable<int> CYLL { get; set; }

            public Nullable<int> CYLR { get; set; }

            public string D1L { get; set; }

            public string D1R { get; set; }

            public string D2L { get; set; }

            public string D2R { get; set; }

            public string D3L { get; set; }

            public string D3R { get; set; }

            public string D4L { get; set; }

            public string D4R { get; set; }

            public bool DBL { get; set; }

            public bool DBR { get; set; }

            public Nullable<DateTime> DDate { get; set; }

            public Nullable<int> DiaL { get; set; }

            public Nullable<int> DiaR { get; set; }

            public string DN { get; set; }

            public string DpCodeJG { get; set; }

            public string DpCodeWG { get; set; }

            public string DpNameJG { get; set; }

            public string DpNameWG { get; set; }

            public Nullable<bool> F_CusLens { get; set; }

            public string FBCode { get; set; }

            public Nullable<decimal> Freight { get; set; }

            public string ID { get; set; }

            public string JJ { get; set; }

            public string JS { get; set; }

            public bool JY { get; set; }

            public string KK { get; set; }

            public string LensCodeL { get; set; }

            public string LensCodeR { get; set; }

            public string LensCodeRL { get; set; }

            public string LensCodeRR { get; set; }

            public string LensNameL { get; set; }

            public string LensNameR { get; set; }

            public string LensNameRL { get; set; }

            public string LensNameRR { get; set; }

            public string Maker { get; set; }

            public Nullable<DateTime> MDate { get; set; }

            public string MName { get; set; }

            public string Notes { get; set; }

            public string OBCode { get; set; }

            public Nullable<byte> OGType { get; set; }

            public string OP { get; set; }

            public string P1L { get; set; }

            public string P1R { get; set; }

            public string P2L { get; set; }

            public string P2R { get; set; }

            public string P3L { get; set; }

            public string P3R { get; set; }

            public string P4L { get; set; }

            public string P4R { get; set; }

            public string PD { get; set; }

            public string PG { get; set; }

            public string PH { get; set; }

            public string PiH { get; set; }

            public Nullable<int> QtyL { get; set; }

            public Nullable<int> QtyR { get; set; }

            public string Remark { get; set; }

            public string RS { get; set; }

            public string RSName { get; set; }

            public string SN { get; set; }

            public string SpCode { get; set; }

            public Nullable<int> SPHL { get; set; }

            public Nullable<int> SPHR { get; set; }

            public string SpName { get; set; }

            public string StCode { get; set; }

            public string StName { get; set; }

            public string SY { get; set; }

            public string TypeName { get; set; }

            public Nullable<byte> UD { get; set; }

            public bool UV { get; set; }

            public string WhCode { get; set; }

            public string WhName { get; set; }

            public Nullable<int> X_ADDL { get; set; }

            public Nullable<int> X_ADDR { get; set; }

            public string ZK { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_PriceContract_FrameMetadata as the class
    // that carries additional metadata for the V_Sale_PriceContract_Frame class.
    [MetadataTypeAttribute(typeof(V_Sale_PriceContract_Frame.V_Sale_PriceContract_FrameMetadata))]
    public partial class V_Sale_PriceContract_Frame
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_PriceContract_Frame class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_PriceContract_FrameMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_PriceContract_FrameMetadata()
            {
            }

            public string BID { get; set; }

            public string FrameCode { get; set; }

            public string ID { get; set; }

            public string InvTitle { get; set; }

            public Nullable<decimal> Price { get; set; }

            public Nullable<decimal> PriceJM { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_PriceContract_FrameSetMetadata as the class
    // that carries additional metadata for the V_Sale_PriceContract_FrameSet class.
    [MetadataTypeAttribute(typeof(V_Sale_PriceContract_FrameSet.V_Sale_PriceContract_FrameSetMetadata))]
    public partial class V_Sale_PriceContract_FrameSet
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_PriceContract_FrameSet class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_PriceContract_FrameSetMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_PriceContract_FrameSetMetadata()
            {
            }

            public string BID { get; set; }

            public Nullable<int> FQty { get; set; }

            public string FrameCode { get; set; }

            public string ID { get; set; }

            public string InvTitle { get; set; }

            public string LensCode { get; set; }

            public Nullable<int> LQty { get; set; }

            public Nullable<decimal> Price { get; set; }

            public Nullable<decimal> Price_ProCost { get; set; }

            public Nullable<decimal> Price_ProCostJM { get; set; }

            public Nullable<decimal> PriceJM { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_PriceContract_Lens_ProCostMetadata as the class
    // that carries additional metadata for the V_Sale_PriceContract_Lens_ProCost class.
    [MetadataTypeAttribute(typeof(V_Sale_PriceContract_Lens_ProCost.V_Sale_PriceContract_Lens_ProCostMetadata))]
    public partial class V_Sale_PriceContract_Lens_ProCost
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_PriceContract_Lens_ProCost class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_PriceContract_Lens_ProCostMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_PriceContract_Lens_ProCostMetadata()
            {
            }

            public string BID { get; set; }

            public string CB { get; set; }

            public string ChB { get; set; }

            public string CS { get; set; }

            public Nullable<bool> F_Set { get; set; }

            public string ID { get; set; }

            public string InvTitle { get; set; }

            public string JJ { get; set; }

            public string JS { get; set; }

            public Nullable<bool> JY { get; set; }

            public string KK { get; set; }

            public string LensCode { get; set; }

            public string OP { get; set; }

            public Nullable<decimal> P1 { get; set; }

            public Nullable<decimal> P1JM { get; set; }

            public Nullable<decimal> P2 { get; set; }

            public Nullable<decimal> P2JM { get; set; }

            public string PG { get; set; }

            public string PiH { get; set; }

            public string RS { get; set; }

            public string SY { get; set; }

            public Nullable<bool> UV { get; set; }

            public string ZK { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_QuoteMetadata as the class
    // that carries additional metadata for the V_Sale_Quote class.
    [MetadataTypeAttribute(typeof(V_Sale_Quote.V_Sale_QuoteMetadata))]
    public partial class V_Sale_Quote
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_Quote class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_QuoteMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_QuoteMetadata()
            {
            }

            public Nullable<int> Axis { get; set; }

            public string BASE { get; set; }

            public string BCodePC { get; set; }

            public string BrowseRight { get; set; }

            public string BType { get; set; }

            public string CB { get; set; }

            public string ChB { get; set; }

            public string CS { get; set; }

            public string CT { get; set; }

            public string CusCode { get; set; }

            public string CusName { get; set; }

            public Nullable<int> CYL { get; set; }

            public string D1 { get; set; }

            public string D2 { get; set; }

            public string D3 { get; set; }

            public string D4 { get; set; }

            public Nullable<bool> DB { get; set; }

            public Nullable<int> Dia { get; set; }

            public string ID { get; set; }

            public string InvTitle { get; set; }

            public string JJ { get; set; }

            public string JS { get; set; }

            public Nullable<bool> JY { get; set; }

            public string KK { get; set; }

            public string LensCode { get; set; }

            public string LensName { get; set; }

            public string Maker { get; set; }

            public string MName { get; set; }

            public string OP { get; set; }

            public string P1 { get; set; }

            public string P2 { get; set; }

            public string P3 { get; set; }

            public string P4 { get; set; }

            public string PG { get; set; }

            public string PiH { get; set; }

            public Nullable<decimal> Price { get; set; }

            public Nullable<decimal> PriceJM { get; set; }

            public Nullable<decimal> ProCost { get; set; }

            public string ProCostReport { get; set; }

            public string ProReport { get; set; }

            public Nullable<int> Qty { get; set; }

            public string RS { get; set; }

            public string RSName { get; set; }

            public Nullable<int> SPH { get; set; }

            public string SY { get; set; }

            public Nullable<bool> UV { get; set; }

            public Nullable<int> X_ADD { get; set; }

            public string ZK { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_Report_CGSDMetadata as the class
    // that carries additional metadata for the V_Sale_Report_CGSD class.
    [MetadataTypeAttribute(typeof(V_Sale_Report_CGSD.V_Sale_Report_CGSDMetadata))]
    public partial class V_Sale_Report_CGSD
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_Report_CGSD class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_Report_CGSDMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_Report_CGSDMetadata()
            {
            }

            public string BCode { get; set; }

            public string BCodeBar { get; set; }

            public string BDate { get; set; }

            public string CsDate { get; set; }

            public string CusCode { get; set; }

            public string DpCodeWG { get; set; }

            public string ID { get; set; }

            public string Maker { get; set; }

            public string Notes { get; set; }

            public string OBCode { get; set; }

            public string Rt1 { get; set; }

            public string Rt2 { get; set; }

            public string Rt3 { get; set; }

            public string Rt4 { get; set; }

            public string Rt5 { get; set; }

            public string RtQR1 { get; set; }

            public string RtQR2 { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Sale_Report_LensMetadata as the class
    // that carries additional metadata for the V_Sale_Report_Lens class.
    [MetadataTypeAttribute(typeof(V_Sale_Report_Lens.V_Sale_Report_LensMetadata))]
    public partial class V_Sale_Report_Lens
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Sale_Report_Lens class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Sale_Report_LensMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Sale_Report_LensMetadata()
            {
            }

            public string BCode { get; set; }

            public string BCodeBar { get; set; }

            public string BDate { get; set; }

            public string CsDate { get; set; }

            public string CusCode { get; set; }

            public string CusName { get; set; }

            public string DAddress { get; set; }

            public string DDate { get; set; }

            public string DN { get; set; }

            public string DNBar { get; set; }

            public string DpCodeWG { get; set; }

            public string ID { get; set; }

            public string IDSale { get; set; }

            public string Maker { get; set; }

            public string Notes { get; set; }

            public string OBCode { get; set; }

            public string Rt1 { get; set; }

            public string Rt2 { get; set; }

            public string Rt3 { get; set; }

            public string Rt4 { get; set; }

            public string Rt5 { get; set; }

            public Nullable<decimal> SumMoney { get; set; }

            public string Tel { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Ware_Bill_Count_LensMetadata as the class
    // that carries additional metadata for the V_Ware_Bill_Count_Lens class.
    [MetadataTypeAttribute(typeof(V_Ware_Bill_Count_Lens.V_Ware_Bill_Count_LensMetadata))]
    public partial class V_Ware_Bill_Count_Lens
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Ware_Bill_Count_Lens class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Ware_Bill_Count_LensMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Ware_Bill_Count_LensMetadata()
            {
            }

            public string BCode { get; set; }

            public Nullable<DateTime> BDate { get; set; }

            public string BrowseRight { get; set; }

            public string BType { get; set; }

            public Nullable<DateTime> DelDate { get; set; }

            public string Deler { get; set; }

            public string DelName { get; set; }

            public string Ender { get; set; }

            public string EndName { get; set; }

            public Nullable<DateTime> EndTime { get; set; }

            public Nullable<bool> F_Del { get; set; }

            public string F_LR { get; set; }

            public string FBCode { get; set; }

            public string ID { get; set; }

            public Nullable<int> KJYear { get; set; }

            public string LensCode { get; set; }

            public string LensName { get; set; }

            public string Maker { get; set; }

            public Nullable<DateTime> MDate { get; set; }

            public string MName { get; set; }

            public string MType { get; set; }

            public Nullable<int> Period { get; set; }

            public string Remark { get; set; }

            public string Starter { get; set; }

            public string StartName { get; set; }

            public Nullable<DateTime> StartTime { get; set; }

            public string StCode { get; set; }

            public string StName { get; set; }

            public Nullable<int> SumQty { get; set; }

            public Nullable<int> SumQty1 { get; set; }

            public Nullable<int> SumQty2 { get; set; }

            public string TypeName { get; set; }

            public string WhCode { get; set; }

            public string WhName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Ware_Bill_Count_PDMetadata as the class
    // that carries additional metadata for the V_Ware_Bill_Count_PD class.
    [MetadataTypeAttribute(typeof(V_Ware_Bill_Count_PD.V_Ware_Bill_Count_PDMetadata))]
    public partial class V_Ware_Bill_Count_PD
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Ware_Bill_Count_PD class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Ware_Bill_Count_PDMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Ware_Bill_Count_PDMetadata()
            {
            }

            public string BCode { get; set; }

            public Nullable<DateTime> BDate { get; set; }

            public string BrowseRight { get; set; }

            public string BType { get; set; }

            public Nullable<DateTime> DelDate { get; set; }

            public string Deler { get; set; }

            public string DelName { get; set; }

            public string Ender { get; set; }

            public string EndName { get; set; }

            public Nullable<DateTime> EndTime { get; set; }

            public Nullable<bool> F_Del { get; set; }

            public string F_LR { get; set; }

            public string FBCode { get; set; }

            public string ID { get; set; }

            public Nullable<int> KJYear { get; set; }

            public string LensCode { get; set; }

            public string LensName { get; set; }

            public string Maker { get; set; }

            public Nullable<DateTime> MDate { get; set; }

            public string MName { get; set; }

            public string MType { get; set; }

            public Nullable<int> Period { get; set; }

            public string Remark { get; set; }

            public string Starter { get; set; }

            public string StartName { get; set; }

            public Nullable<DateTime> StartTime { get; set; }

            public string StCode { get; set; }

            public string StName { get; set; }

            public string TypeName { get; set; }

            public string WhCode { get; set; }

            public string WhName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Ware_Bill_Count_PD_DetailMetadata as the class
    // that carries additional metadata for the V_Ware_Bill_Count_PD_Detail class.
    [MetadataTypeAttribute(typeof(V_Ware_Bill_Count_PD_Detail.V_Ware_Bill_Count_PD_DetailMetadata))]
    public partial class V_Ware_Bill_Count_PD_Detail
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Ware_Bill_Count_PD_Detail class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Ware_Bill_Count_PD_DetailMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Ware_Bill_Count_PD_DetailMetadata()
            {
            }

            public Nullable<int> CYL { get; set; }

            public string ID { get; set; }

            public Nullable<int> Qty { get; set; }

            public int Qty1 { get; set; }

            public int Qty2 { get; set; }

            public Nullable<int> SPH { get; set; }

            public long SubID { get; set; }

            public Nullable<int> X_ADD { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Ware_Bill_SO_PDMetadata as the class
    // that carries additional metadata for the V_Ware_Bill_SO_PD class.
    [MetadataTypeAttribute(typeof(V_Ware_Bill_SO_PD.V_Ware_Bill_SO_PDMetadata))]
    public partial class V_Ware_Bill_SO_PD
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Ware_Bill_SO_PD class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Ware_Bill_SO_PDMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Ware_Bill_SO_PDMetadata()
            {
            }

            public string BCode { get; set; }

            public string BCodeSale { get; set; }

            public Nullable<DateTime> BDate { get; set; }

            public Nullable<DateTime> BDateSale { get; set; }

            public string BrowseRight { get; set; }

            public string BType { get; set; }

            public Nullable<DateTime> ChDate { get; set; }

            public string Checker { get; set; }

            public string ChName { get; set; }

            public Nullable<DateTime> CsDateSale { get; set; }

            public string CusCode { get; set; }

            public string CusName { get; set; }

            public Nullable<DateTime> DelDate { get; set; }

            public string Deler { get; set; }

            public string DelName { get; set; }

            public string F_LR { get; set; }

            public string F_LRSale { get; set; }

            public string FBCode { get; set; }

            public string ID { get; set; }

            public string LensCode { get; set; }

            public string LensCodeSale { get; set; }

            public string LensName { get; set; }

            public string LensNameSale { get; set; }

            public string Maker { get; set; }

            public Nullable<DateTime> MDate { get; set; }

            public string MName { get; set; }

            public string NotesSale { get; set; }

            public string OBCodeSale { get; set; }

            public string Remark { get; set; }

            public string RemarkSale { get; set; }

            public string SpCode { get; set; }

            public string SpName { get; set; }

            public string StCode { get; set; }

            public string StName { get; set; }

            public string WhCode { get; set; }

            public string WhName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Ware_Bill_SO_PD_DetailMetadata as the class
    // that carries additional metadata for the V_Ware_Bill_SO_PD_Detail class.
    [MetadataTypeAttribute(typeof(V_Ware_Bill_SO_PD_Detail.V_Ware_Bill_SO_PD_DetailMetadata))]
    public partial class V_Ware_Bill_SO_PD_Detail
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Ware_Bill_SO_PD_Detail class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Ware_Bill_SO_PD_DetailMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Ware_Bill_SO_PD_DetailMetadata()
            {
            }

            public Nullable<int> CYL { get; set; }

            public string ID { get; set; }

            public Nullable<decimal> Price { get; set; }

            public Nullable<int> Qty { get; set; }

            public Nullable<int> QtySale { get; set; }

            public Nullable<int> SPH { get; set; }

            public int SubID { get; set; }

            public Nullable<int> X_ADD { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Ware_Bill_SO_Pending_PDMetadata as the class
    // that carries additional metadata for the V_Ware_Bill_SO_Pending_PD class.
    [MetadataTypeAttribute(typeof(V_Ware_Bill_SO_Pending_PD.V_Ware_Bill_SO_Pending_PDMetadata))]
    public partial class V_Ware_Bill_SO_Pending_PD
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Ware_Bill_SO_Pending_PD class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Ware_Bill_SO_Pending_PDMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Ware_Bill_SO_Pending_PDMetadata()
            {
            }

            public string BCode { get; set; }

            public Nullable<DateTime> BDate { get; set; }

            public string BrowseRight { get; set; }

            public string Checker { get; set; }

            public Nullable<DateTime> CsDate { get; set; }

            public string CusCode { get; set; }

            public string CusName { get; set; }

            public string F_LRSale { get; set; }

            public string FBCode { get; set; }

            public string ID { get; set; }

            public string LensCode { get; set; }

            public string LensCodeR { get; set; }

            public string LensName { get; set; }

            public string LensNameR { get; set; }

            public string Maker { get; set; }

            public string Notes { get; set; }

            public string OBCode { get; set; }

            public Nullable<byte> OGType { get; set; }

            public string Remark { get; set; }

            public Nullable<int> SumQty { get; set; }

            public Nullable<int> SumQtySO { get; set; }

            public Nullable<int> SumQtyUnSO { get; set; }

            public string TypeName { get; set; }

            public Nullable<byte> UD { get; set; }

            public string WhCode { get; set; }

            public string WhName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Ware_Bill_SO_SDMetadata as the class
    // that carries additional metadata for the V_Ware_Bill_SO_SD class.
    [MetadataTypeAttribute(typeof(V_Ware_Bill_SO_SD.V_Ware_Bill_SO_SDMetadata))]
    public partial class V_Ware_Bill_SO_SD
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Ware_Bill_SO_SD class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Ware_Bill_SO_SDMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Ware_Bill_SO_SDMetadata()
            {
            }

            public string BCode { get; set; }

            public string BCodeSale { get; set; }

            public Nullable<DateTime> BDate { get; set; }

            public Nullable<DateTime> BDateSale { get; set; }

            public string BrowseRight { get; set; }

            public string BType { get; set; }

            public Nullable<DateTime> ChDate { get; set; }

            public string Checker { get; set; }

            public string ChName { get; set; }

            public Nullable<DateTime> CsDateSale { get; set; }

            public string CusCode { get; set; }

            public string CusName { get; set; }

            public Nullable<int> CYLL { get; set; }

            public Nullable<int> CYLR { get; set; }

            public Nullable<DateTime> DelDate { get; set; }

            public string Deler { get; set; }

            public string DelName { get; set; }

            public string FBCode { get; set; }

            public string ID { get; set; }

            public string LensCodeL { get; set; }

            public string LensCodeLSale { get; set; }

            public string LensCodeR { get; set; }

            public string LensCodeRSale { get; set; }

            public string LensNameL { get; set; }

            public string LensNameLSale { get; set; }

            public string LensNameR { get; set; }

            public string LensNameRSale { get; set; }

            public string Maker { get; set; }

            public Nullable<DateTime> MDate { get; set; }

            public string MName { get; set; }

            public string NotesSale { get; set; }

            public string OBCodeSale { get; set; }

            public Nullable<decimal> PriceL { get; set; }

            public Nullable<decimal> PriceR { get; set; }

            public Nullable<decimal> ProCostL { get; set; }

            public Nullable<decimal> ProCostR { get; set; }

            public Nullable<int> QtyL { get; set; }

            public Nullable<int> QtyLSale { get; set; }

            public Nullable<int> QtyR { get; set; }

            public Nullable<int> QtyRSale { get; set; }

            public string Remark { get; set; }

            public string RemarkSale { get; set; }

            public string SpCode { get; set; }

            public Nullable<int> SPHL { get; set; }

            public Nullable<int> SPHR { get; set; }

            public string SpName { get; set; }

            public string StCode { get; set; }

            public string StName { get; set; }

            public string WhCode { get; set; }

            public string WhName { get; set; }

            public Nullable<int> X_ADDL { get; set; }

            public Nullable<int> X_ADDR { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Ware_Bill_Transfer_LensMetadata as the class
    // that carries additional metadata for the V_Ware_Bill_Transfer_Lens class.
    [MetadataTypeAttribute(typeof(V_Ware_Bill_Transfer_Lens.V_Ware_Bill_Transfer_LensMetadata))]
    public partial class V_Ware_Bill_Transfer_Lens
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Ware_Bill_Transfer_Lens class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Ware_Bill_Transfer_LensMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Ware_Bill_Transfer_LensMetadata()
            {
            }

            public string BCode { get; set; }

            public Nullable<DateTime> BDate { get; set; }

            public string BrowseRightIn { get; set; }

            public string BrowseRightOut { get; set; }

            public string BType { get; set; }

            public Nullable<DateTime> ChDateIn { get; set; }

            public Nullable<DateTime> ChDateOut { get; set; }

            public string CheckerIn { get; set; }

            public string CheckerOut { get; set; }

            public string ChNameIn { get; set; }

            public string ChNameOut { get; set; }

            public Nullable<DateTime> DelDate { get; set; }

            public string Deler { get; set; }

            public string DelName { get; set; }

            public Nullable<bool> F_Chk { get; set; }

            public Nullable<bool> F_Del { get; set; }

            public string F_LR { get; set; }

            public string FBCode { get; set; }

            public string ID { get; set; }

            public string LensCode { get; set; }

            public string LensName { get; set; }

            public string Maker { get; set; }

            public Nullable<DateTime> MDate { get; set; }

            public string MName { get; set; }

            public string MType { get; set; }

            public string Remark { get; set; }

            public string StCode { get; set; }

            public string StName { get; set; }

            public Nullable<int> SumQty { get; set; }

            public string TypeName { get; set; }

            public string WhCodeIn { get; set; }

            public string WhCodeOut { get; set; }

            public string WhNameIn { get; set; }

            public string WhNameOut { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Ware_Report_Stocks_Lens_XYMetadata as the class
    // that carries additional metadata for the V_Ware_Report_Stocks_Lens_XY class.
    [MetadataTypeAttribute(typeof(V_Ware_Report_Stocks_Lens_XY.V_Ware_Report_Stocks_Lens_XYMetadata))]
    public partial class V_Ware_Report_Stocks_Lens_XY
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Ware_Report_Stocks_Lens_XY class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Ware_Report_Stocks_Lens_XYMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Ware_Report_Stocks_Lens_XYMetadata()
            {
            }

            public string BrowseRight { get; set; }

            public int CodeLevel { get; set; }

            public int F_Lens { get; set; }

            public string F_LR { get; set; }

            public string ID { get; set; }

            public string KeyCode { get; set; }

            public string KeyName { get; set; }

            public string PCode { get; set; }

            public Nullable<int> Qty { get; set; }

            public string WhCode { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Ware_Stocks_Base_LensMetadata as the class
    // that carries additional metadata for the V_Ware_Stocks_Base_Lens class.
    [MetadataTypeAttribute(typeof(V_Ware_Stocks_Base_Lens.V_Ware_Stocks_Base_LensMetadata))]
    public partial class V_Ware_Stocks_Base_Lens
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Ware_Stocks_Base_Lens class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Ware_Stocks_Base_LensMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Ware_Stocks_Base_LensMetadata()
            {
            }

            public string BCode { get; set; }

            public Nullable<DateTime> BDate { get; set; }

            public string BrowseRight { get; set; }

            public string BType { get; set; }

            public Nullable<DateTime> ChDate { get; set; }

            public string Checker { get; set; }

            public string ChName { get; set; }

            public string F_LR { get; set; }

            public string ID { get; set; }

            public string LensCode { get; set; }

            public string LensName { get; set; }

            public string Maker { get; set; }

            public Nullable<DateTime> MDate { get; set; }

            public string MName { get; set; }

            public string Remark { get; set; }

            public string StCode { get; set; }

            public string StName { get; set; }

            public Nullable<int> SumQty { get; set; }

            public string WhCode { get; set; }

            public string WhName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_Ware_Stocks_Base_Lens_DetailMetadata as the class
    // that carries additional metadata for the V_Ware_Stocks_Base_Lens_Detail class.
    [MetadataTypeAttribute(typeof(V_Ware_Stocks_Base_Lens_Detail.V_Ware_Stocks_Base_Lens_DetailMetadata))]
    public partial class V_Ware_Stocks_Base_Lens_Detail
    {

        // This class allows you to attach custom attributes to properties
        // of the V_Ware_Stocks_Base_Lens_Detail class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_Ware_Stocks_Base_Lens_DetailMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_Ware_Stocks_Base_Lens_DetailMetadata()
            {
            }

            public Nullable<int> CYL { get; set; }

            public string ID { get; set; }

            public Nullable<int> Qty { get; set; }

            public Nullable<int> SPH { get; set; }

            public int SubID { get; set; }

            public Nullable<int> X_ADD { get; set; }
        }
    }
}
