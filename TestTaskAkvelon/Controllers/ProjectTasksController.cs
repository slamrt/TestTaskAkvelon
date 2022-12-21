using Microsoft.AspNetCore.Mvc;
using TestTaskAkvelon.Models;
using TestTaskAkvelon.Models.Repositories;

namespace TestTaskAkvelon.Controllers
{
    [Route("/api[controller]")]
    public class ProjectTasksController : Controller
    {
        private IProjectTasksRepository _projectTasksRepository;//creating an intermediate
                                                                //repository to help perform CRUD operations
        private int NextTaskId => _projectTasksRepository.GetAllTasks().Count == 0 ?
            1 : _projectTasksRepository.GetAllTasks().Max(t => t.Id) + 1; // find the id
                                                                     // of the next task 

        public ProjectTasksController(IProjectTasksRepository projectTasksRepository)
        {
            this._projectTasksRepository = projectTasksRepository;
        }

        [HttpGet]
        public List<ProjectTask> GetAllTasks()//getting all taskss
        {
            List<ProjectTask>? tasks = _projectTasksRepository.GetAllTasks();
            List<ProjectTask> result = tasks
                .Select(t => new ProjectTask() {
                Id = t.Id,
                Name = t.Name,
                ProjectId = t.ProjectId,
                Description = t.Description
            }).ToList();
            return result;
        }
        [HttpGet("GetAllTasksByProjectId")]

        public List<ProjectTask> GetAllTasksByProjectId(int projectId)
        {
            List<ProjectTask>? tasks = _projectTasksRepository.GetAllTasksByProjectId(projectId).ToList();
            return tasks;
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)//getting a task by its id
        {
            var task = _projectTasksRepository.GetTaskById(id);
            if(task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)//removing a task
        {
            _projectTasksRepository.DeleteTaskById(id);
            return Ok();
        }

        [HttpGet("GetNextTaskId")]
        public int GetNextTaskId()//will come in handy when adding a task
        {
            return  this.NextTaskId;
        }


        [HttpPost]
        public IActionResult AddTask(ProjectTask projectTask)//adding a task
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            projectTask.Id = this.NextTaskId;
            _projectTasksRepository.AddTask(projectTask);
            return CreatedAtAction(nameof(GetTaskById), new { id = projectTask.Id }, projectTask);
        }

        [HttpPost("AddProjectTask")]
        public IActionResult PostBody([FromBody] ProjectTask projectTask) => AddTask(projectTask);


        [HttpPut]
        public IActionResult UpdateTask(ProjectTask projectTask)
        {

            if(projectTask == null)
            {
                return BadRequest(ModelState);
            }

            _projectTasksRepository.UpdateTask(projectTask);
            return Ok();
        }
    }
}
