//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Internship_Section3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BACourse
    {
        public int BAID { get; set; }
        public int DegreeID { get; set; }
        public string DegreeName { get; set; }
        public string DurationInYears { get; set; }
        public string Courses { get; set; }
    
        public virtual Degree Degree { get; set; }
    }
    public enum WhatBACourses
    {
        Theater,
        Art,
        English,
        Music
    }
}
