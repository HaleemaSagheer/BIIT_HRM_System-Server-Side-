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
    
    public partial class Education
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Major { get; set; }
        public string Board { get; set; }
        public int Year { get; set; }
        public int ApplicantId { get; set; }
    
        public virtual user user { get; set; }
    }
}
