using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.Models.Entities
{
    public partial class Employees
    {
        public Employees()
        {
            EmployeeAllocations = new HashSet<EmployeeAllocations>();
            Projects = new HashSet<Projects>();
        }

        [Key]
        public int EmployeeId { get; set; }
        [StringLength(10)]
        public string? Title { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string? MiddleName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime? DateofBirth { get; set; }
        [StringLength(50)]
        public string? CountryofBirth { get; set; }
        [StringLength(20)]
        public string? Gender { get; set; }
        [StringLength(20)]
        public string? MaritalStatus { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateofMarriage { get; set; }
        [StringLength(50)]
        public string? PersonalEmail { get; set; }
        [StringLength(10)]
        public string? ContactNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateofJoining { get; set; }
        [StringLength(50)]
        public string? EmployeeCode { get; set; }
        [StringLength(50)]
        public string? OfficialEmail { get; set; }
        public int EmployeeTypeId { get; set; }
        public int? RevisedLocationId { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Designation { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? OverallExperience { get; set; }
        public int Skill_Id { get; set; }
        public string? SkillName { get; set; }
        public int? ReportingManagerId { get; set; }
        [StringLength(100)]
        public string? HighestEducation { get; set; }
        public bool? EmploymentStatus { get; set; }
        [Column(TypeName = "date")]
        public DateTime? RelievingDate { get; set; }
        public int? SubPracticeId { get; set; }
        public string FullName => FirstName + " " + MiddleName + " " + LastName;
        public bool? IsEngineering { get; set; }
        public bool? IsNextAssignmentIdentified { get; set; }
        [StringLength(50)]
        public string? NextAssignmentName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NextAssignmentStartDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey("EmployeeTypeId")]
        [InverseProperty("Employees")]
        public virtual EmployeeType? EmployeeType { get; set; }
        [ForeignKey("RevisedLocationId")]
        [InverseProperty("Employees")]
        public virtual Locations? RevisedLocation { get; set; }
        [ForeignKey("Skill_Id")]
        [InverseProperty("Employees")]
        public virtual SkillSets? Skill { get; set; }
        [ForeignKey("SubPracticeId")]
        [InverseProperty("Employees")]
        public virtual SubPractices? SubPractice { get; set; }


        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeAllocations> EmployeeAllocations { get; set; }
        [InverseProperty("ProjectManager")]
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
