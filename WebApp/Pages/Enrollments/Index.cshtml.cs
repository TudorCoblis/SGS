using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Enrollments
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;

        public IndexModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        public IList<Enrollment> Enrollment { get;set; } = default!;

        public string StudentNameFilter { get; set; }

        public async Task OnGetAsync(string searchString, string sortOrder)
        {
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (!String.IsNullOrEmpty(searchString))
            {
                StudentNameFilter = searchString;

                Enrollment = await _context.Enrollment
                    .Include(g => g.Student)
                    .Where(g =>
                        (g.Student.FirstName + " " + g.Student.LastName).Contains(searchString) ||
                        g.Student.FirstName.Contains(searchString) ||
                        g.Student.LastName.Contains(searchString)
                    )
                    .ToListAsync();
            }
            else
            {
                Enrollment = await _context.Enrollment
                    .Include(g => g.Student)
                    .OrderBy(g => g.Student.LastName)
                    .ToListAsync();
            }

            if (sortOrder == "id_desc")
            {
                Enrollment.Reverse();
            }
        }
    }
}