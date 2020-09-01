using System.ComponentModel.DataAnnotations;

namespace NS.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
