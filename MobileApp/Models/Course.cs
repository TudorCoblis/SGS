using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MobileApp.Models
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int CourseID { get; set; }
        [StringLength(70)]
        [Display(Name = "Denumire")]
        public string CourseName { get; set; }
        [Range(1, 6)]
        [Display(Name = "Credite")]
        public int Credits { get; set; }
        [Range(1, 28)]
        [Display(Name = "Numar de ore")]
        public int NoClasses { get; set; }
        [Display(Name = "Descriere")]
        public string? Description { get; set; }
        [OneToMany]
        public List<CourseEnrollment> CourseEnrollments { get; set; }
        //public ICollection<Enrollment>? Enrollments { get; set; }
        //public int? ProfessorID { get; set; }
        //public Professor? Professor { get; set; }

    }
}
