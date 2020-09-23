//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Internship_Section2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Degree
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Degree()
        {
            this.BACourses = new HashSet<BACourse>();
            this.BSCourses = new HashSet<BSCourse>();
        }
    
        public int DegreeID { get; set; }
        [DisplayName("Duration")]
        public Nullable<int> DurationInMonths { get; set; }
        [DisplayName("Degree")]
        public string Degree1 { get; set; }
        public int LecturerID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BACourse> BACourses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSCourse> BSCourses { get; set; }
        public virtual Lecturer Lecturer { get; set; }
    }

    public enum WhatDegree
    {
        BachelorOfArts,
        BachelorOfScience,
        Masters
    }
}
