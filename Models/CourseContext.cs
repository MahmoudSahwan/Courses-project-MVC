using Microsoft.EntityFrameworkCore;

namespace CoursesMVC.Models
{
    public class CourseContext : DbContext
    {
        //Db Set For Each Table
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Trainee> Traines { get; set; }
        public DbSet<CrsResult> Results { set; get; }

        //ctor

        public CourseContext():base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
                optionsBuilder.UseSqlServer(
                    "Server=.;Database=CourseDB;Integrated Security=True;Encrypt=False");
                base.OnConfiguring(optionsBuilder);
 
        }
    }
}
