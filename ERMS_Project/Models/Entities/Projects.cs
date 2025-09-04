using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.Models.Entities
{
    public partial class Projects
    {
        public Projects()
        {
            EmployeeAllocations = new HashSet<EmployeeAllocations>();
        }

        [Key]
        public int ProjectId { get; set; }
        public int? AccountId { get; set; }
        [StringLength(100)]
        public string? ProjectName { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        public int? ProjectStatusId { get; set; }
        public int? ProjectCostingTypeId { get; set; }
        public int? ProjectManagerId { get; set; }
        public int? PracticeId { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey("AccountId")]
        [InverseProperty("Projects")]
        public virtual Accounts? Account { get; set; }
        [ForeignKey("PracticeId")]
        [InverseProperty("Projects")]
        public virtual Practices? Practice { get; set; }
        [ForeignKey("ProjectCostingTypeId")]
        [InverseProperty("Projects")]
        public virtual ProjectCostingTypes? ProjectCostingType { get; set; }
        [ForeignKey("ProjectManagerId")]
        [InverseProperty("Projects")]
        public virtual Employees? ProjectManager { get; set; }
        [ForeignKey("ProjectStatusId")]
        [InverseProperty("Projects")]
        public virtual ProjectStatus? ProjectStatus { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<EmployeeAllocations> EmployeeAllocations { get; set; }
    }
}
