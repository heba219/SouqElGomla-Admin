//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SouqElGomalAdmin
{
    using System;
    using System.Collections.Generic;
    
    public partial class RetailerReviewProduct
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public Nullable<int> Rate { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
