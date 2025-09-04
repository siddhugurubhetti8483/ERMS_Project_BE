using System.ComponentModel.DataAnnotations;

namespace ERMS_Project.Models.Entities
{
    public class TimeSheetEntries
    {
        TimeSheetEntries()
        { }
        [Key]
        public int TimeSheetEntryId { get; set; }
        public int TimeSheetId { get; set; }
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public decimal? HoursWorked { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? WeekNo { get; set; }
        public DateTime? WorkingDate { get; set; }
        public bool Isdeleted { get; set; }
        public bool IsBillable { get; set; }
    }
}
