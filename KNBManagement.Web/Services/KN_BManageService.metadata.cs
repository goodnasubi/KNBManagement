
namespace KNBManagement.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using KNBManagement.Web.Resources;


    // The MetadataTypeAttribute identifies BusinessTypeMetadata as the class
    // that carries additional metadata for the BusinessType class.
    [MetadataTypeAttribute(typeof(BusinessType.BusinessTypeMetadata))]
    public partial class BusinessType
    {

        // This class allows you to attach custom attributes to properties
        // of the BusinessType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class BusinessTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private BusinessTypeMetadata()
            {
            }

            public EntityCollection<Company> Companies { get; set; }

            public EntityCollection<JournalItemBiz> JournalItemBizs { get; set; }

            [Display(Order = 1, Name = "BusinessTypeIDLabel", ShortName = "BusinessTypeIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid BusinessTypeID { get; set; }

            [Display(Order = 2, Name = "BusinessTypeNameLabel", ShortName = "BusinessTypeNameCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public string Name { get; set; }

            public byte[] TS { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies CompanyMetadata as the class
    // that carries additional metadata for the Company class.
    [MetadataTypeAttribute(typeof(Company.CompanyMetadata))]
    public partial class Company
    {

        // This class allows you to attach custom attributes to properties
        // of the Company class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CompanyMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private CompanyMetadata()
            {
            }

            public BusinessType BusinessType { get; set; }

            [Include]
            public EntityCollection<Employee> Employees { get; set; }

            [Include]
            public EntityCollection<Journal> Journal { get; set; }

            [Include]
            public EntityCollection<JournalDetail> JournalDetails { get; set; }

            [Include]
            public EntityCollection<JournalItemComp> JournalItemComps { get; set; }

            [Include]
            public EntityCollection<Slip> Slips { get; set; }

            [Display(Order = 4, Name = "BusinessTypeIDLabel", ShortName = "BusinessTypeIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid BusinessTypeID { get; set; }

            [Display(Order = 1, Name = "CompanyIDLabel", ShortName = "CompanyIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid CompanyID { get; set; }

            [Display(Order = 3, Name = "CompanyKeyLabel", ShortName = "CompanyKeyCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public string CompanyKey { get; set; }

            [Display(Order = 2, Name = "CompanyNameLabel", ShortName = "CompanyNameCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public string CompanyName { get; set; }

            public byte[] TS { get; set; }

        }
    }

    // The MetadataTypeAttribute identifies EmployeeMetadata as the class
    // that carries additional metadata for the Employee class.
    [MetadataTypeAttribute(typeof(Employee.EmployeeMetadata))]
    public partial class Employee
    {

        // This class allows you to attach custom attributes to properties
        // of the Employee class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class EmployeeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private EmployeeMetadata()
            {
            }

            public Company Company { get; set; }

            [Display(Order = 1, Name = "CompanyIDLabel", ShortName = "CompanyIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid CompanyID { get; set; }

            [Display(Order = 2, Name = "EmployeeIDLabel", ShortName = "EmployeeIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid EmployeeID { get; set; }

            [Display(Order = 3, Name = "EmployeeNameLabel", ShortName = "EmployeeNameCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public string EmployeeName { get; set; }

            [Display(Order = 4, Name = "LoginIDLabel", ShortName = "LoginIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public string LoginID { get; set; }

            [Display(Order = 4, Name = "PasswordLabel", ShortName = "PasswordCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public string Password { get; set; }

            public byte[] TS { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies JournalMetadata as the class
    // that carries additional metadata for the Journal class.
    [MetadataTypeAttribute(typeof(Journal.JournalMetadata))]
    public partial class Journal
    {

        // This class allows you to attach custom attributes to properties
        // of the Journal class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class JournalMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private JournalMetadata()
            {
            }

            public Company Company { get; set; }

            [Display(Order = 1, Name = "CompanyIDLabel", ShortName = "CompanyIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid CompanyID { get; set; }

            public Guid EmployeeID { get; set; }

            public EntityCollection<JournalDetail> JournalDetails { get; set; }

            public Guid JournalID { get; set; }

            public string Remarks { get; set; }

            public DateTime TradingDate { get; set; }

            public byte[] TS { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies JournalDetailMetadata as the class
    // that carries additional metadata for the JournalDetail class.
    [MetadataTypeAttribute(typeof(JournalDetail.JournalDetailMetadata))]
    public partial class JournalDetail
    {

        // This class allows you to attach custom attributes to properties
        // of the JournalDetail class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class JournalDetailMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private JournalDetailMetadata()
            {
            }

            public Company Company { get; set; }

            [Display(Order = 1, Name = "CompanyIDLabel", ShortName = "CompanyIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid CompanyID { get; set; }

            public Guid CreditItemID { get; set; }

            public decimal CreditMoney { get; set; }

            public Guid DebitItemID { get; set; }

            public decimal DebitMoney { get; set; }

            public int JournalDetailID { get; set; }

            public Journal Journal { get; set; }

            public Guid JournalID { get; set; }

            public byte[] TS { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies JournalItemBizMetadata as the class
    // that carries additional metadata for the JournalItemBiz class.
    [MetadataTypeAttribute(typeof(JournalItemBiz.JournalItemBizMetadata))]
    public partial class JournalItemBiz
    {

        // This class allows you to attach custom attributes to properties
        // of the JournalItemBiz class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class JournalItemBizMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private JournalItemBizMetadata()
            {
            }

            public BusinessType BusinessType { get; set; }

            public Guid BusinessTypeID { get; set; }

            public string JournalGroup { get; set; }

            public Guid JournalItemID { get; set; }

            public string JournalName { get; set; }

            public string Keyword { get; set; }

            public byte[] TS { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies JournalItemCompMetadata as the class
    // that carries additional metadata for the JournalItemComp class.
    [MetadataTypeAttribute(typeof(JournalItemComp.JournalItemCompMetadata))]
    public partial class JournalItemComp
    {

        // This class allows you to attach custom attributes to properties
        // of the JournalItemComp class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class JournalItemCompMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private JournalItemCompMetadata()
            {
            }

            public Company Company { get; set; }

            [Display(Order = 1, Name = "CompanyIDLabel", ShortName = "CompanyIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid CompanyID { get; set; }

            public string JournalGroup { get; set; }

            public Guid JournalItemID { get; set; }

            public string JournalName { get; set; }

            public string Keyword { get; set; }

            public byte[] TS { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SlipMetadata as the class
    // that carries additional metadata for the Slip class.
    [MetadataTypeAttribute(typeof(Slip.SlipMetadata))]
    public partial class Slip
    {

        // This class allows you to attach custom attributes to properties
        // of the Slip class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SlipMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SlipMetadata()
            {
            }

            [Include]
            public EntityCollection<SlipDetail> SlipDetails { get; set; }

            public Company Company { get; set; }

            public SlipType SlipType { get; set; }


            [Display(Order = 1, Name = "CompanyIDLabel", ShortName = "CompanyIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid CompanyID { get; set; }

            [Display(Order = 4, Name = "JournalItemIDLabel", ShortName = "JournalDetailIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid JournalItemID { get; set; }

            [Display(Order = 5, Name = "RemarksLabel", ShortName = "RemarksCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            [StringLength(50)]
            public string Remarks { get; set; }

            [Display(Order = 2, Name = "SlipIDLabel", ShortName = "SlipIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid SlipID { get; set; }

            [Display(Order = 3, Name = "SlipTypeIDLabel", ShortName = "SlipTypeIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public int SlipTypeID { get; set; }

            [Display(Order = 3, Name = "TradingDateLabel", ShortName = "TradingDateCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public DateTime TradingDate { get; set; }

            public byte[] TS { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SlipDetailMetadata as the class
    // that carries additional metadata for the SlipDetail class.
    [MetadataTypeAttribute(typeof(SlipDetail.SlipDetailMetadata))]
    public partial class SlipDetail
    {

        // This class allows you to attach custom attributes to properties
        // of the SlipDetail class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SlipDetailMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SlipDetailMetadata()
            {
            }

            public Slip Slip { get; set; }

            [Display(Order = 1, Name = "CompanyIDLabel", ShortName = "CompanyIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid CompanyID { get; set; }

            [Display(Order = 4, Name = "JournalItemIDLabel", ShortName = "JournalDetailIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required(ErrorMessage="仕訳項目は必須です")]
            public Guid JournalItemID { get; set; }

            [Display(Order = 5, Name = "JournalMoneyLabel", ShortName = "JournalMoneyCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public decimal JournalMoney { get; set; }

            [Display(Order = 3, Name = "SlipDetailIDLabel", ShortName = "SlipDetailIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid SlipDetailID { get; set; }

            [Display(Order = 2, Name = "SlipIDLabel", ShortName = "SlipIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public Guid SlipID { get; set; }

            [Display(Order = 6, Name = "SlipDetailOrderLabel", ShortName = "SlipDetailOrderCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public int DetailOrder { get; set; }

            
            public byte[] TS { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SlipTypeMetadata as the class
    // that carries additional metadata for the SlipType class.
    [MetadataTypeAttribute(typeof(SlipType.SlipTypeMetadata))]
    public partial class SlipType
    {

        // This class allows you to attach custom attributes to properties
        // of the SlipType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SlipTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SlipTypeMetadata()
            {
            }

            [Display(Order = 2, Name = "SlipNameLabel", ShortName = "SlipNameCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public string Name { get; set; }

            [Include]
            public EntityCollection<Slip> Slips { get; set; }

            [Display(Order = 1, Name = "SlipTypeIDLabel", ShortName = "SlipTypeIDCol", ResourceType = typeof(KNBManageDataResources))]
            [Required()]
            public int SlipTypeID { get; set; }

            public byte[] TS { get; set; }
        }
    }

    //[MetadataTypeAttribute(typeof(JournalItem.JournalItemMetadata))]
    //public partial class JournalItem
    //{
    //    internal sealed class JournalItemMetadata
    //    {
    //        private JournalItemMetadata()
    //        {
    //        }

    //        public Guid JournalItemID { get; set; }

    //        public string JournalName { get; set; }

    //        public string JournalGroup { get; set; }

    //        public string Keyword { get; set; }

    //    }
    //}
}
