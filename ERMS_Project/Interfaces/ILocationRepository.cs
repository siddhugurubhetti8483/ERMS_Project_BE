using ERMS_Project.DTOs.Employee;

namespace ERMS_Project.Interfaces
{
    public interface ILocationRepository
    {
        public Task<ResponseClass> GetLocations();
    }
}
