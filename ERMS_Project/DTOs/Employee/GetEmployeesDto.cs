using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ERMS_Project.DTOs.Employee
{
    public class GetEmployeesDto
    {
        public int EmployeeId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string? MiddleName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [Column(TypeName = "date")]
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
        //public int? Skill_Id { get; set; }
        //public string? SkillName { get; set; }
        public int? L1ManagerId { get; set; }
        //[StringLength(100)]
        //public string? HighestEducation { get; set; }
        public bool? EmploymentStatus { get; set; }
        //[Column(TypeName = "date")]
        //public DateTime? RelievingDate { get; set; }
        public int? SubPracticeId { get; set; }
        public string? SubPracticeName { get; set; }
        //public string FullName => FirstName + " " + MiddleName + " " + LastName;
        public bool? IsEngineering { get; set; }
        public bool? IsNextAssignmentIdentified { get; set; }
        [StringLength(50)]
        public string? NextAssignmentName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NextAssignmentStartDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? L1ManagerName { get; set; }
        public string? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public string? EmployeeType { get; set; }
        public string? RevisedLocation { get; set; }
        // public string? Skill { get; set; }
        public string? SubPractice { get; set; }

        [InverseProperty("Employee")]
        //public virtual ICollection<EmployeeAllocations> EmployeeAllocations { get; set; }
        //[InverseProperty("ProjectManager")]
        //public virtual ICollection<Projects> Projects { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastWorkingDate { get; set; }
        public string OfficelEmailAddress { get; set; }

    }
}
