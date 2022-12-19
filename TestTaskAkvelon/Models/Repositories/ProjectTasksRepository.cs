namespace TestTaskAkvelon.Models.Repositories
{
    public class ProjectTasksRepository : IProjectTasksRepository
    {
        public void AddTask(ProjectTask projectTask)
        {
            using (var dbContext = new DataBaseContext())
            {
                dbContext.Add(projectTask); 
                dbContext.SaveChanges();
            }
        }

        public void DeleteTaskById(int id)
        {
            using (var dbContext = new DataBaseContext())
            {
                dbContext.ProjectTasks.Remove(GetTaskById(id));
                dbContext.SaveChanges();
            }
        }

        public ProjectTask GetTaskById(int id)
        {
            using(var dbContext = new DataBaseContext())
            {
                return dbContext.ProjectTasks.FirstOrDefault(t => t.Id == id);
            }
        }

        public List<ProjectTask> GetAllTasks()
        {
            using (var dbContext = new DataBaseContext())
            {
                return dbContext.ProjectTasks.ToList();
            }
        }


        public void UpdateTask(ProjectTask projectTask)
        {
            using (var dbContext = new DataBaseContext())
            {
                dbContext.ProjectTasks.Update(projectTask);
                dbContext.SaveChanges();
            }
        }

        public List<ProjectTask> GetAllTasksByProjectId(int projectId)
        {
            using (var dbContext = new DataBaseContext())
            {
                List<ProjectTask> result = dbContext.ProjectTasks.Where(t => t.Id == projectId).ToList();
                return result;
            }
        }
    }
}
