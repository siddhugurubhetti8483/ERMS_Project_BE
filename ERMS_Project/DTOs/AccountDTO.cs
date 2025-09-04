using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.DTOs
{
    public class AccountDTO
    {
        //public AccountDTO()
        //{
        //    Projects = new HashSet<Projects>();
        //}


        [Key]
        public int AccountId { get; set; }
        [StringLength(150)]
        public string? Name { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        [StringLength(10000)]
        public string? AccountLocation { get; set; }

        [StringLength(150)]
        public string? POCName { get; set; }
        [StringLength(100)]
        public string? POCEmail { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        [StringLength(20)]
        public string? PocMobileNumber { get; set; }
        public string? CountryName { get; set; }
        public int? CountryId { get; set; }
        [StringLength(20)]
        public string? GstNumber { get; set; }
        public int? PaymentTermsDuration { get; set; }
        public List<int>? Ids { get; set; }
        public int? CreatedById { get; set; }
        public int? ModifiedById { get; set; }

        //[InverseProperty("Account")]
        //public virtual ICollection<Projects> Projects { get; set; }

    }
}
