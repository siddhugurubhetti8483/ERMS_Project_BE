using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.DTOs
{
    public class GetProjectsDTO
    {
        public int ProjectId { get; set; }
        public string? Account { get; set; }
        [StringLength(100)]
        public string? ProjectName { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        [Column(TypeName = "date")]
        public string? StartDate { get; set; }
        [Column(TypeName = "date")]
        public string? EndDate { get; set; }
        public string? Status { get; set; }
        public string? ProjectCostingType { get; set; }
        public string? ManagerName { get; set; }
        public string? Practices { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public string? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public string? ModifiedOn { get; set; }
    }
}
