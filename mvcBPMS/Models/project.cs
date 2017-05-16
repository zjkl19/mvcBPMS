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
    
    public partial class project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public project()
        {
            this.project_money_flow = new HashSet<project_money_flow>();
            this.r_project_staff = new HashSet<r_project_staff>();
        }
    
        public string id { get; set; }
        public string contact_id { get; set; }
        public string project_name { get; set; }
        public Nullable<decimal> standard_product_value { get; set; }
        public Nullable<System.DateTime> enter_date { get; set; }
        public Nullable<System.DateTime> exit_date { get; set; }
        public bool is_approved { get; set; }
        public bool approved_datatime { get; set; }
    
        public virtual contact contact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project_money_flow> project_money_flow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<r_project_staff> r_project_staff { get; set; }
    }
}