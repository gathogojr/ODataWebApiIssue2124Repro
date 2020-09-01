using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NS.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Collection<Task> Tasks { get; set; }
    }
}
