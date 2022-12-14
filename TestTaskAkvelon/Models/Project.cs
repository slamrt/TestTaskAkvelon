using System.ComponentModel.DataAnnotations;

namespace TestTaskAkvelon.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        List<ProjectTask> Tasks { get; set; }   
    }
}
