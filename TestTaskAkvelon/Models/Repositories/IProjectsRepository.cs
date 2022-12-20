namespace TestTaskAkvelon.Models.Repositories
{
    public interface IProjectsRepository
    {
        List<Project> GetAllProjects();
        Project GetProjectById(int id);

        void DeleteProjectById(int id);

        void AddProject(Project project);
        public void UpdateProject(Project project);

    }
}
