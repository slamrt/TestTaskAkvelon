namespace TestTaskAkvelon.Models.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        public void AddProject(Project project)
        {
            using (var dbContext = new DataBaseContext())
            {
                dbContext.Add(project);
                dbContext.SaveChanges();
            }
        }

        public void DeleteProjectById(int id)
        {
            using (var dbContext = new DataBaseContext())
            {
                dbContext.Projects.Remove(GetProjectById(id));
                dbContext.SaveChanges();
            }
        }

        public List<Project> GetAllProjects()
        {
            using (var dbContext = new DataBaseContext())
            {
                return dbContext.Projects.ToList();
            }
        }

        public Project GetProjectById(int id)
        {
            using (var dbContext = new DataBaseContext())
            {
                return dbContext.Projects.FirstOrDefault(t => t.Id == id);
            }
        }

        public void UpdateProject(Project project)
        {
            using (var dbContext = new DataBaseContext())
            {
                dbContext.Projects.Update(project);
                dbContext.SaveChanges();
            }
        }
    }
}
