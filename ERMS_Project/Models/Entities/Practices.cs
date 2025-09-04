using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.Models.Entities
{
    public partial class Practices
    {
        public Practices()
        {
            Projects = new HashSet<Projects>();
            SkillSets = new HashSet<SkillSets>();
            SubPractices = new HashSet<SubPractices>();
        }

        [Key]
        public int PracticeId { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        [StringLength(100)]
        public string? PracticeHead { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }

        [InverseProperty("Practice")]
        public virtual ICollection<Projects> Projects { get; set; }
        [InverseProperty("Practice")]
        public virtual ICollection<SkillSets> SkillSets { get; set; }
        [InverseProperty("Practice")]
        public virtual ICollection<SubPractices> SubPractices { get; set; }
    }
}
