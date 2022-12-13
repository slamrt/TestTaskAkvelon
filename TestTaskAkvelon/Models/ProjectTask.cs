using System.ComponentModel.DataAnnotations;

namespace TestTaskAkvelon.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        public int ProjectId { get; set; }
    }
}
