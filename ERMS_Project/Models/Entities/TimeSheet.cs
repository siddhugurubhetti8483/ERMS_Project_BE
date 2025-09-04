using System.ComponentModel.DataAnnotations;

namespace ERMS_Project.Models.Entities
{
    public class TimeSheet
    {
        [Key]
        public int TimeSheetId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public bool ApprovedByManager { get; set; }
        public bool ApprovedByClient { get; set; }
        public bool Rejected { get; set; }
        public string Remarks { get; set; }
        public string StatusHistory { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime SubmmittedDate { get; set; }
    }
}
