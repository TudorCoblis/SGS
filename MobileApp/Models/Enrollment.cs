using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MobileApp.Models
{
    public class Enrollment
    {
        [PrimaryKey, AutoIncrement]
        public int EnrollmentID { get; set; }
        [Display(Name = "Data inscrierii")]
        public DateTime EnrollmentDate { get; set; }
        //public int? StudentID { get; set; }
        //public Student? Student { get; set; }
        //public int? CourseID { get; set; }
        //public Course? Course { get; set; }
        //public ICollection<Grade>? Grades { get; set; }
        public DateTime DateOfExam { get; set;}
        public string Description { get; set; }
    }
}
