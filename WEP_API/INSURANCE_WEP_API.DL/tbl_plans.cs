//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INSURANCE_WEP_API.DL
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    public partial class tbl_plans
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public tbl_plans()
        {
            this.tbl_planDetails = new HashSet<tbl_planDetails>();
        }
        
        public long PlanId { get; set; }
        [Required]
        [MaxLength(50)]
        public string PlanCode { get; set; }
        [Required]
        [MaxLength(200)]
        public string PlanName { get; set; }

        public System.DateTime EffectiveFromDate { get; set; }
     

        public System.DateTime EffectiveTillDate { get; set; }


        public System.DateTime CreatedDate { get; set; }

        public System.DateTime ModifiedDate { get; set; }


        public long CreatedUser { get; set; }
        [Required]

        public long ModifiedUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //[JsonIgnore]
        //[IgnoreDataMember]
        public virtual ICollection<tbl_planDetails> tbl_planDetails { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual tbl_users tbl_users { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual tbl_users tbl_users1 { get; set; }
    }
}