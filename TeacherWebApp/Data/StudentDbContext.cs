using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeacherWebApp.Models;

namespace TeacherWebApp.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext (DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        public DbSet<TeacherWebApp.Models.Teach> Teach { get; set; } = default!;
    }
}
