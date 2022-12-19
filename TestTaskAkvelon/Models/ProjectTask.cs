using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskAkvelon.Models
{
    public class ProjectTask
    {
        [Key]

        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        public int ProjectId { get; set; }
    }
}
