using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERMS_Project.Models.Entities
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employees>();
        }

        [Key]
        public int EmployeeTypeId { get; set; }
        [StringLength(100)]
        public string? Type { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }

        [InverseProperty("EmployeeType")]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
