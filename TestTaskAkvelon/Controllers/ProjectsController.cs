using Microsoft.AspNetCore.Mvc;
using TestTaskAkvelon.Models;
using TestTaskAkvelon.Models.Repositories;

namespace TestTaskAkvelon.Controllers
{
    [Route("/api[controller]")]
    public class ProjectsController : Controller
    {
        private IProjectsRepository _projectsRepository;
      //  private IProjectTasksRepository _tasksRepository;

        public ProjectsController(IProjectsRepository projectsRepository/*, IProjectTasksRepository tasksRepository*/)
        {
            this._projectsRepository = projectsRepository;
            //this._tasksRepository = tasksRepository;
        }
        [HttpGet]
        public List<Project> GetAllProjects()//getting all projects from the DB
        {
            List<Project>? projects = _projectsRepository.GetAllProjects();
            List<Project> result = projects
                .Select(p => new Project()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description
                }).ToList();
            return result;
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)//getting a project by its id
        {
            var project = _projectsRepository.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)//removing a project using its id
        {
            _projectsRepository.DeleteProjectById(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddProject(Project project)//adding a project
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _projectsRepository.AddProject(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
        }

        [HttpPost("AddProject")]
        public IActionResult PostBody([FromBody] Project project) => AddProject(project);

        [HttpPut]
        public IActionResult UpdateProject(Project project)
        {

            if (project == null)
            {
                return BadRequest(ModelState);
            }

            _projectsRepository.UpdateProject(project);
            return Ok();
        }
    }
}
