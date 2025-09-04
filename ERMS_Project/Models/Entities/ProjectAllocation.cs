using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.Models.Entities
{
    public class ProjectAllocation
    {
        public ProjectAllocation()
        {
            Projects = new HashSet<Projects>();
            Employees = new HashSet<Employees>();
        }
        [Key]
        public int? ProjectAllocationId { get; set; }
        [StringLength(50)]
        public int? ProjectId { get; set; }
        public int? EmployeeId { get; set; }
        public bool? IsBillabe { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? NumberOfEmployee { get; set; }
        public bool? IsBillable { get; set; }
        public string? ProjectStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }



        [InverseProperty("ProjectAllocation")]

        public virtual ICollection<Employees> Employees { get; set; }
        [InverseProperty("ProjectAllocation")]

        public virtual ICollection<Projects> Projects { get; set; }
    }
}
