
namespace Internship_Section1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class UserDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserDetail()
        {
            this.Degrees = new HashSet<Degree>();
        }
    
       
        public int UserID { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [DisplayName("Date Of Birth")]
        public string DateOfBirth { get; set; }
        [DisplayName("First Name")]
        public string FirstnameBasedOnForename { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        [DisplayName("List of Degrees")]
        public string ListOfDegree { get; set; }
        [DisplayName("Degree")]
        public string LinkOfDegree { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Degree> Degrees { get; set; }
    }

    public class ViewLoginModel
    {
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
    }

    public enum WhatPosition
    {
        Student,
        Lecturer
    }

    public enum WhatDegrees
    {
        
        BachelorOfArts,
        BachelorOfScience
    }

   

}
