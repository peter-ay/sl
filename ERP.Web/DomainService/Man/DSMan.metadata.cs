
namespace ERP.Web.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies V_S_DataBaseMetadata as the class
    // that carries additional metadata for the V_S_DataBase class.
    [MetadataTypeAttribute(typeof(V_S_DataBase.V_S_DataBaseMetadata))]
    public partial class V_S_DataBase
    {

        // This class allows you to attach custom attributes to properties
        // of the V_S_DataBase class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_S_DataBaseMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_S_DataBaseMetadata()
            {
            }

            public string DBCode { get; set; }

            public string DBName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies V_U_ProcessClassMetadata as the class
    // that carries additional metadata for the V_U_ProcessClass class.
    [MetadataTypeAttribute(typeof(V_U_ProcessClass.V_U_ProcessClassMetadata))]
    public partial class V_U_ProcessClass
    {

        // This class allows you to attach custom attributes to properties
        // of the V_U_ProcessClass class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class V_U_ProcessClassMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private V_U_ProcessClassMetadata()
            {
            }

            public string KeyCode { get; set; }

            public string KeyName { get; set; }
        }
    }
}
