using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.Models.Entities
{
    public partial class Country
    {
        public Country()
        {
            Accounts = new HashSet<Accounts>();
        }

        [Key]
        public int CountryId { get; set; }
        [StringLength(50)]
        public string? CountryName { get; set; }
        [StringLength(50)]
        public string? Region { get; set; }
        public int? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedOn { get; set; }

        [InverseProperty("Country")]
        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
