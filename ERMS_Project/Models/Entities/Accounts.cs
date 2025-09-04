using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.Models.Entities
{
    public partial class Accounts
    {
        public Accounts()
        {
            Projects = new HashSet<Projects>();
        }

        [Key]
        public int AccountId { get; set; }
        [StringLength(150)]
        public string? Name { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        [StringLength(50)]
        public string? AccountLocation { get; set; }
        [StringLength(150)]
        public string? POCName { get; set; }
        [StringLength(100)]
        public string? POCEmail { get; set; }
        [StringLength(20)]
        public string? PocMobileNumber { get; set; }

        public int? CountryId { get; set; }
        [StringLength(20)]
        public string? GstNumber { get; set; }
        public int? PaymentTermsDuration { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey("CountryId")]
        [InverseProperty("Accounts")]
        public virtual Accounts? Country { get; set; }
        [InverseProperty("Accounts")]
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
