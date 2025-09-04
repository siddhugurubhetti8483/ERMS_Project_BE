using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.Models.Entities
{
    public partial class SubPractices
    {
        public SubPractices()
        {
            Employees = new HashSet<Employees>();
        }

        [Key]
        public int SubPracticeId { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        public int? PracticeId { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey("PracticeId")]
        [InverseProperty("SubPractices")]
        public virtual Practices? Practice { get; set; }
        [InverseProperty("SubPractice")]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
