using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.Models.Entities
{
    public class EmployeeAllocations
    {
        [Key]
        public int AllocationId { get; set; }
        public int? ProjectId { get; set; }
        public int? EmployeeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [StringLength(20)]
        public string? AllocationStatus { get; set; }
        public bool? IsBillable { get; set; }
        public bool? IsUtilized { get; set; }
        public int? AllocationPercentage { get; set; }
        public int? BillablePercentage { get; set; }
        [StringLength(200)]
        public string? Remarks { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("EmployeeAllocations")]
        public virtual Employees? Employee { get; set; }
        [ForeignKey("ProjectId")]
        [InverseProperty("EmployeeAllocations")]
        public virtual Projects? Project { get; set; }
    }
}
