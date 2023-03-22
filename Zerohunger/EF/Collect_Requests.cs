//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zerohunger.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Collect_Requests
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Collect_Requests()
        {
            this.Collection_Logs = new HashSet<Collection_Logs>();
            this.Food_Items = new HashSet<Food_Items>();
        }
    
        public int Request_id { get; set; }
        public int Restaurant_id { get; set; }
        public System.DateTime Maximum_preservation_time { get; set; }
        public Nullable<System.DateTime> Collection_date { get; set; }
        public string Collection_status { get; set; }
    
        public virtual Restaurant Restaurant { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Collection_Logs> Collection_Logs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Food_Items> Food_Items { get; set; }
    }
}
