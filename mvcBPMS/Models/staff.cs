//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcBPMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public staff()
        {
            this.contact = new HashSet<contact>();
            this.project_money_flow = new HashSet<project_money_flow>();
            this.r_project_staff = new HashSet<r_project_staff>();
        }
    
        public string id { get; set; }
        public decimal staff_no { get; set; }
        public string staff_name { get; set; }
        public bool gender { get; set; }
        public string phone_number { get; set; }
        public string position { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contact> contact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project_money_flow> project_money_flow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<r_project_staff> r_project_staff { get; set; }
    }
}
