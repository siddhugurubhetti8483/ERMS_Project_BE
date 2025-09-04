namespace ERMS_Project.DTOs
{
    public class AllocationDTO
    {
        public int? ProjectId { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? ProjectName { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? AllocationStatus { get; set; }
        public int? AllocationPercentage { get; set; }
        public bool? IsBillable { get; set; }
        public bool? IsUtilized { get; set; }
        public int? AllocationId { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedOn { get; set; }
        public string? ModifiedOn { get; set; }
        public List<int>? Ids { get; set; }
    }
}
