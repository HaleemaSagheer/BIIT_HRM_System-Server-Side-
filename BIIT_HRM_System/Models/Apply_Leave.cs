//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIIT_HRM_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Apply_Leave
    {
        public int Leave_id { get; set; }
        public Nullable<int> Emp_id { get; set; }
        public string Leave_type { get; set; }
        public System.DateTime Start_date { get; set; }
        public System.DateTime End_date { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
    }
}
