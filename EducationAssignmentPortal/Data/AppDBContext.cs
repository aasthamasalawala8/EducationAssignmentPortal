
using EducationAssignmentPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationAssignmentPortal.Data

{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        //public DbSet<Student> Students { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentGrade> StudentGrades { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}

