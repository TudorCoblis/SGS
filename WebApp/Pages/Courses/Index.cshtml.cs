using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.ViewModels;

namespace WebApp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;

        public IndexModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public CourseIndexData CourseData { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public async Task OnGetAsync(int? id, int? studentID)
        {
            CourseData = new CourseIndexData();
            CourseData.Courses = await _context.Course
            .Include(i => i.Enrollments)
            .ThenInclude(e => e.Student)
            .OrderBy(i => i.CourseName)
            .ToListAsync();
            if (id != null)
            {
                CourseID = id.Value;
                CourseData.Enrollments = CourseData.Courses
                    .Where(i => i.CourseID == id.Value)
                    .SelectMany(c => c.Enrollments)
                    .ToList();

                // Opțional: Filtrare după studentID (dacă este furnizat)
                if (studentID != null)
                {
                    CourseData.Enrollments = CourseData.Enrollments
                        .Where(e => e.StudentID == studentID.Value)
                        .ToList();
                }
            }
        }
    }
}
