namespace TestTaskAkvelon.Models.Repositories
{
    public class ProjectTasksRepository : IProjectTasksRepository
    {
        public void Add(ProjectTask projectTask)
        {
            using (var dbContext = new DataBaseContext())
            {
                dbContext.Add(projectTask); 
                dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var dbContext = new DataBaseContext())
            {
                dbContext.ProjectTasks.Remove(Get(id));
                dbContext.SaveChanges();
            }
        }

        public ProjectTask Get(int id)
        {
            using(var dbContext = new DataBaseContext())
            {
                return dbContext.ProjectTasks.FirstOrDefault(t => t.Id == id);
            }
        }

        public List<ProjectTask> GetAll()
        {
            using (var dbContext = new DataBaseContext())
            {
                return dbContext.ProjectTasks.ToList();
            }
        }
    }
}
