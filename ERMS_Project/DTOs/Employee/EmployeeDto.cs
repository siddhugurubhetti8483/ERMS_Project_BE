using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ERMS_Project.DTOs.Employee
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        [StringLength(10)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? MiddleName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        public DateTime? DateofJoining { get; set; }
        [StringLength(50)]
        public string? EmployeeCode { get; set; }
        [StringLength(50)]
        public string? OfficeEmailAddress { get; set; }
        public int? EmployeeTypeId { get; set; }
        public int? RevisedLocationId { get; set; }
        [StringLength(50)]
        public string? Designation { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? TotalExperience { get; set; }
        public int? L1ManagerId { get; set; }
        public string? L1ManagerName { get; set; }
        public bool? EmploymentStatus { get; set; }
        public int? SubPracticeId { get; set; }
        public bool? IsEngineering { get; set; }
        public bool? IsNextAssignmentIdentified { get; set; }
        [StringLength(50)]
        public string? NextAssignmentName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NextAssignmentStartDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedById { get; set; }
        public int? ModifiedById { get; set; }
        public List<int>? Ids { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LastWorkingDate { get; set; }
    }
}
