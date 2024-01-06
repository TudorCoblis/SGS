using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    //blablabla
    public class Course
    {
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
        public ICollection<Enrollment>? Enrollments { get; set; }
        public int? ProfessorID { get; set; }                                    
        public Professor? Professor { get; set; }

    }
}
