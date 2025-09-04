using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.Models.Entities
{
    public partial class ProjectStatus
    {
        public ProjectStatus()
        {
            Projects = new HashSet<Projects>();
        }

        [Key]
        public int StatusId { get; set; }
        [StringLength(50)]
        public string? Status { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }

        [InverseProperty("ProjectStatus")]
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
