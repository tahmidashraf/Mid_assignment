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
    
    public partial class Food_Items
    {
        public int Food_item_id { get; set; }
        public int Request_id { get; set; }
        public string Item_name { get; set; }
        public int Quantity { get; set; }
        public System.DateTime Expiry_date { get; set; }
    
        public virtual Collect_Requests Collect_Requests { get; set; }
    }
}
