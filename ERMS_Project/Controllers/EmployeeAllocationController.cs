using ERMS_Project.DTOs;
using ERMS_Project.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeeAllocationController : ControllerBase
    {
        private readonly IEmployeeAllocationRepository _employeeAllocationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;

        public EmployeeAllocationController(IEmployeeAllocationRepository employeeAllocationRepository, IEmployeeRepository employeeRepository, IProjectRepository projectRepository)
        {
            _employeeAllocationRepository = employeeAllocationRepository;
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
        }

        [HttpGet("GetEmployeeAllocation")]
        public async Task<IActionResult> GetEmployeeAllocation()
        {
            try
            {
                var employee = await _employeeAllocationRepository.GetEmployeeAllocation();
                if (employee.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetEmployeesCountsAllocations")]
        public async Task<IActionResult> GetEmployeesCountsAllocations()
        {

            try
            {
                var counts = await _employeeAllocationRepository.GetEmployeeCountAllocations();
                return Ok(new { data = counts, message = "Data fetch successfully" });
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddEmployeeAllocation")]
        public async Task<IActionResult> AddEmployeeAllocation([FromBody] EmployeeAllocationDTO employeeAllocationDTO)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployee((int)employeeAllocationDTO.EmployeeId!);
                if (employee == null) return NotFound("EMPLOYEE NOT EXITS!");

                //var project = await _projectRepository.GetProject((int)employeeAllocationDTO.ProjectId!);
                //if (project.Count == 0) return NotFound("PROJECT NOT EXITS!");

                var project = ((await _projectRepository.GetProjects()).ToList())
                    .FirstOrDefault(project => project.ProjectId == employeeAllocationDTO.ProjectId);
                if (project == null) return NotFound("PROJECT NOT EXITS!");

                var result = await _employeeAllocationRepository.AddEmployeeAllocation(employeeAllocationDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("EditEmployeeAllocation")]
        public async Task<IActionResult> EditEmployeeAllocation([FromBody] EmployeeAllocationDTO editEmployeeAllocationDTO)
        {

            try
            {
                var employeeAllocation = await _employeeAllocationRepository.GetEmployeeAllocationById((int)editEmployeeAllocationDTO.AllocationId);
                if (employeeAllocation == null) return NotFound("AllocationId NOT EXITS!");

                var employee = await _employeeRepository.GetEmployee((int)editEmployeeAllocationDTO.EmployeeId!);
                if (employee == null) return NotFound("EMPLOYEE NOT EXITS!");

                var project = ((await _projectRepository.GetProjects()).ToList())
                    .FirstOrDefault(project => project.ProjectId == editEmployeeAllocationDTO.ProjectId);
                if (project == null) return NotFound("PROJECT NOT EXITS!");

                var updatedEmployeeAllocation = await _employeeAllocationRepository.UpdateEmployeeAllocation(editEmployeeAllocationDTO);

                return Ok(new
                {
                    Success = true,
                    Message = "Employee Allocation Updated Successfully.",
                    Data = updatedEmployeeAllocation
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete("deleteEmployeeAllocationById")]
        public async Task<IActionResult> deleteEmployeeAllocationById([FromBody] AllocationDTO allocation)
        {
            try
            {
                var employee = await _employeeAllocationRepository.DeleteEmployeeAllocation(allocation);
                return Ok(employee);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
