using ERMS_Project.DTOs;
using ERMS_Project.DTOs.Employee;

namespace ERMS_Project.Interfaces
{
    public interface IEmployeeAllocationRepository
    {
        public Task<string> AddEmployeeAllocation(EmployeeAllocationDTO employeeAllocation);
        public Task<EmployeeAllocationDTO> UpdateEmployeeAllocation(EmployeeAllocationDTO updateEmployeeAllocation);
        public Task<EmployeeAllocationDTO> GetEmployeeAllocationById(int allocationId);
        Task<IEnumerable<AllocationDTO>> GetEmployeeAllocation();
        public Task<ResponseClass> DeleteEmployeeAllocation(AllocationDTO allocation);

        public Task<CountOfEmployeeAllocationsDTO> GetEmployeeCountAllocations();
    }
}
