using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NS.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        [ForeignKey("Supervisor")]
        public int? SupervisorId { get; set; }
        public Employee Supervisor { get; set; }
    }
}
