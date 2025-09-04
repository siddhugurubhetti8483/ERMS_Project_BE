using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.DTOs
{
    public class ProjectDTO
    {
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
        public List<int>? Ids { get; set; }
        public string? ForeGroundColor { get; set; }
        public string? BackGroundColor { get; set; }
    }
}
