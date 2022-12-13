using Microsoft.EntityFrameworkCore;
using TestTaskAkvelon.Models;

namespace TestTaskAkvelon
{
    public class DataBaseContext: DbContext
    {
       
        public DataBaseContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjectsTasksDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
        }

    }
}
