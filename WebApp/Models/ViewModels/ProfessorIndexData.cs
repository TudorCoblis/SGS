using WebApp.Models;

namespace WebApp.Models.ViewModels
{
    public class ProfessorIndexData
    {
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Professor> Professors { get; set; }
    }
}
