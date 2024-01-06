using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class WebAppContext : DbContext
    {
        public WebAppContext (DbContextOptions<WebAppContext> options)
            : base(options)
        {
        }

        public DbSet<WebApp.Models.Course> Course { get; set; } = default!;

        public DbSet<WebApp.Models.Enrollment>? Enrollment { get; set; }

        public DbSet<WebApp.Models.Grade>? Grade { get; set; }

        public DbSet<WebApp.Models.Professor>? Professor { get; set; }

        public DbSet<WebApp.Models.Student>? Student { get; set; }
    }
}
