using ERMS_Project.DTOs.Employee;
using ERMS_Project.Models.Entities;

namespace ERMS_Project.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<GetEmployeesDto> GetEmployee(int id);

        public Task<IEnumerable<GetEmployeesDto>> GetEmployees();

        public Task<IEnumerable<GetEmployeesDto>> GetManagers();

        //public Task<int> GetEmployeeCode();
        public Task<IEnumerable<GetEmployeeCountDto>> GetEmployeeCount();
        public Task<ResponseClass> GetDesignations();

        public Task<Employees> GetEmployeeByEmployeeId(int id);
        public Task<ResponseClass> GetEmployeeswithFilter(string Name);
        public Task<int> CreateEmployee(EmployeeDto employee);
        public Task<int> UpdateEmployee(int id, EmployeeDto employee);
        public Task<ResponseClass> DeleteEmployeeById(int EmployeeId);
        public Task<ResponseClass> DeleteEmployeesById(EmployeeDto employee);
    }
}
