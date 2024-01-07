using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Grades
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;

        public IndexModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        public IList<Grade> Grade { get; set; } = default!;
        public string StudentIDFilter { get; set; }

        public async Task OnGetAsync(string searchString, string sortOrder)
        {
            ViewData["IDSortParam"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

            if (!String.IsNullOrEmpty(searchString))
            {
                StudentIDFilter = searchString;

                Grade = await _context.Grade
                    .Include(g => g.Enrollment)
                    .Where(g => g.Enrollment.StudentID.HasValue && g.Enrollment.StudentID.Value.ToString().Contains(searchString))
                    .ToListAsync();
            }
            else
            {
                Grade = await _context.Grade
                    .Include(g => g.Enrollment)
                    .OrderBy(g => g.Enrollment.StudentID)
                    .ToListAsync();
            }

            if (sortOrder == "id_desc")
            {
                Grade.Reverse();
            }
        }
    }
}
