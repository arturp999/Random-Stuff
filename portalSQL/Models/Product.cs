//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace portalSQL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public decimal id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> ThemeID { get; set; }
        public Nullable<int> Order { get; set; }
    }
}
