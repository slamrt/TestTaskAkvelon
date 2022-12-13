namespace TestTaskAkvelon.Models.Repositories
{
    public interface IProjectTasksRepository
    {
        List<ProjectTask> GetAll();
        ProjectTask Get(int id);

        void Delete(int id);

        void Add(ProjectTask projectTask);  
    }
}
