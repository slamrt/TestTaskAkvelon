namespace TestTaskAkvelon.Models.Repositories
{
    public interface IProjectTasksRepository
    {
        List<ProjectTask> GetAllTasks();
        ProjectTask GetTaskById(int id);

        void DeleteTaskById(int id);

        void AddTask(ProjectTask projectTask);
        public void UpdateTask(ProjectTask projectTask);

        List<ProjectTask> GetAllTasksByProjectId(int projectId);

    }
}
