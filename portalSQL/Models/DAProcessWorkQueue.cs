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
    
    public partial class DAProcessWorkQueue
    {
        public long DAProcessSeqNbr { get; set; }
        public string WorkQueueCode { get; set; }
        public string AssignDate { get; set; }
        public string AssignTime { get; set; }
        public Nullable<int> Delay { get; set; }
        public string Priority { get; set; }
    
        public virtual DAProcess DAProcess { get; set; }
    }
}
