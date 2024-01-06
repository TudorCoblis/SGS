using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Prenume")]
        public string? FirstName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Nume")]
        public string? LastName { get; set; }
        [Display(Name = "Gen")]
        public string? Gender { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data nasterii")]
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^0\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123' si sa inceapa obligatoriu cu '0'")]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
        [Display(Name = "Nume Student")]
        public string FullName2
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}
