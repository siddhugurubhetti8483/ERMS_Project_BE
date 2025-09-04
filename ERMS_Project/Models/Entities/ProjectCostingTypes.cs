using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.Models.Entities
{
    public partial class ProjectCostingTypes
    {
        public ProjectCostingTypes()
        {
            Projects = new HashSet<Projects>();
        }

        [Key]
        public int ProjectCostingTypeId { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }

        [InverseProperty("ProjectCostingType")]
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
