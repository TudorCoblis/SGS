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
namespace WebApp.Pages.Professors
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;

        public IndexModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        public IList<Professor> Professor { get;set; } = default!;

        public ProfessorIndexData ProfessorData { get; set; }
        public int ProfessorID { get; set; }
        public int CourseID { get; set; }
        public async Task OnGetAsync(int? id, int? CourseID)
        {
            ProfessorData = new ProfessorIndexData();
            ProfessorData.Professors = await _context.Professor
            .Include(i => i.Courses)
            .OrderBy(i => i.LastName)
            .ToListAsync();
            if (id != null)
            {
                ProfessorID = id.Value;
                Professor Professor = ProfessorData.Professors
                .Where(i => i.ProfessorID == id.Value).Single();
                ProfessorData.Courses = Professor.Courses;
            }
        }
    }
}
