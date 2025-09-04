namespace ERMS_Project.DTOs
{
    public class CountryDTO
    {
        public int? CountryId { get; set; }
        public string? CountryName { get; set; }
        public string? Region { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }

        public int? CreatedById { get; set; }
        public int? ModifiedById { get; set; }
        public string? CreatedByName { get; set; }
        public string? ModifiedByName { get; set; }
        public List<int>? Ids { get; set; }
    }
}
