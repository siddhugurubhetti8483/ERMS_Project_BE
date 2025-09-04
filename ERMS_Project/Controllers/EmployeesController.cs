using ERMS_Project.DTOs.Employee;
using ERMS_Project.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERMS_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeesController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeRepo.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                //log error code 500
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "EmployeeById")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeRepo.GetEmployee(id);
                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetManagers")]
        public async Task<IActionResult> GetManagers()
        {
            try
            {
                var emp = await _employeeRepo.GetManagers();
                return Ok(emp);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpGet("GetLastSequence")]
        //public async Task<IActionResult> GetEmployeeCode()
        //{
        //    try
        //    {
        //        var emp = await _employeeRepo.GetEmployeeCode();
        //        return Ok(emp);
        //    }
        //    catch (Exception ex)
        //    {
        //        //log error
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        [HttpGet]
        [Route("EmployeeCount")]
        public async Task<IActionResult> GetEmployeeCount()
        {
            try
            {
                var employee_count = await _employeeRepo.GetEmployeeCount();
                return Ok(employee_count);
            }
            catch (Exception)
            {
                //log error
                return BadRequest();
            }
        }

        [HttpGet("GetDesignations")]
        public async Task<IActionResult> GetDesignations()
        {
            try
            {
                var designation = await _employeeRepo.GetDesignations();
                return Ok(designation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ByEmployeeId/{id}")]
        public async Task<IActionResult> GetEmployeeForEmployee(int id)
        {
            try
            {
                var employee = await _employeeRepo.GetEmployeeByEmployeeId(id);
                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[action]/{Name}", Name = "EmployeeByname")]
        public async Task<IActionResult> GetEmployeeswithFilter(string Name)
        {
            try
            {
                var ResponseData = await _employeeRepo.GetEmployeeswithFilter(Name);
                if (ResponseData == null)
                {
                    return BadRequest(new { ResponseData });
                }
                return Ok(ResponseData);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDto employeeDTO)
        {
            try
            {
                if (employeeDTO == null)
                {
                    return BadRequest(employeeDTO);
                }
                var createdEmployee = await _employeeRepo.CreateEmployee(employeeDTO);
                if (createdEmployee != 0 && createdEmployee != -1)
                {
                    return Ok(new
                    {
                        Success = true,
                        Message = "Employee created Successfully with EmployeeId = " + createdEmployee
                    });
                }
                else if (createdEmployee == -1)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Employee already exists."
                    });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation"))
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "EmployeeCode already exists."
                    });
                }
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDto employee)
        {
            try
            {
                var dbEmployee = await _employeeRepo.GetEmployee(id);
                if (dbEmployee == null)
                    return NotFound();


                var employeeId = await _employeeRepo.UpdateEmployee(id, employee);
                if (employeeId != 0 && employeeId == id)
                {
                    return Ok(new
                    {
                        Success = true,
                        Message = "Employee updated Successfully with EmployeeId = " + employeeId
                    });
                }
                else if (employeeId == -1)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Employee already exists."
                    });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{EmployeeId}")]
        public async Task<IActionResult> DeleteEmployee(int EmployeeId)
        {
            try
            {
                var ResponseData = await _employeeRepo.DeleteEmployeeById(EmployeeId);
                if (ResponseData == null)
                {
                    return BadRequest(new { ResponseData });
                }
                return Ok(ResponseData);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to Delete this Employee");
            }
        }

        [HttpDelete("DeleteEmployeesById")]
        public async Task<IActionResult> DeleteEmployeesById([FromBody] EmployeeDto employee)
        {
            try
            {
                var ResponseData = await _employeeRepo.DeleteEmployeesById(employee);
                return Ok(ResponseData);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
