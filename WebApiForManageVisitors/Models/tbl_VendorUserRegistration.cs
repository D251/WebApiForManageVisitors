//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiForWorkPermitSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_VendorUserRegistration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_VendorUserRegistration()
        {
            this.tbl_RequestProcess = new HashSet<tbl_RequestProcess>();
        }
    
        public long VendorSrNo { get; set; }
        public string VendorUserID { get; set; }
        public string DeviceTokenId { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public string VendorContactNo { get; set; }
        public string VendorEmailID { get; set; }
        public string VendorNatureOfWork { get; set; }
        public Nullable<long> VendorContractorSrNo { get; set; }
        public string VendorContractorCoNo { get; set; }
        public string VendorPassword { get; set; }
        public Nullable<System.DateTime> VendorRegistrationDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_RequestProcess> tbl_RequestProcess { get; set; }
    }
}
