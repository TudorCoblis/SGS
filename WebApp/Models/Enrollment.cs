using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        [Display(Name = "Data inscrierii")]
        public DateTime EnrollmentDate { get; set; }
        public int? StudentID { get; set; }
        public Student? Student { get; set; }
        public int? CourseID { get; set; }
        public Course? Course { get; set; }
        public ICollection<Grade>? Grades { get; set; }
    }
}
