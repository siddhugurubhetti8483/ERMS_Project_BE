using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.Models.Entities
{
    public partial class SkillSets
    {
        public SkillSets()
        {
            Employees = new HashSet<Employees>();
        }

        [Key]
        public int Skill_Id { get; set; }
        [StringLength(100)]
        public string? SkillName { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        public int? PracticeId { get; set; }
        public int? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey("PracticeId")]
        [InverseProperty("SkillSets")]
        public virtual Practices? Practice { get; set; }
        [InverseProperty("Skill")]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
