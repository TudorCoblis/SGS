using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;

        public IndexModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public string StudentEmailFilter { get; set; }

        public async Task OnGetAsync(string searchString, string sortOrder)
        {
            ViewData["EmailSortParam"] = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";

            if (!String.IsNullOrEmpty(searchString))
            {
                StudentEmailFilter = searchString;

                Student = await _context.Student
                        .Where(s => s.Email.Contains(searchString))
                        .ToListAsync();
            }
            else
            {
                Student = await _context.Student
                    .OrderBy(s => s.Email)
                    .ToListAsync();
            }

            if (sortOrder == "email_desc")
            {
                Student.Reverse();
            }
        }
    }
}
