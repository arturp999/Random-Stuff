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
    
    public partial class BankCard
    {
        public string HolderTaxIdNum { get; set; }
        public string IBAN { get; set; }
        public string BIC_SWIFT { get; set; }
        public string HolderName { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public string IssuerIdentifyer { get; set; }
        public string IssuerName { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }
        public string BBAN { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
    }
}
