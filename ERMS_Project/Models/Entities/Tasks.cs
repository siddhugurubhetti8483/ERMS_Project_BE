using System.ComponentModel.DataAnnotations;

namespace ERMS_Project.Models.Entities
{
    public class Tasks
    {
        public Tasks() { }

        [Key]
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        [StringLength(255)]
        public string? Name { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
    }
}
