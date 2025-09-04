using ERMS_Project.Constants;
using System.Data;
using ERMS_Project.Contexts;
using ERMS_Project.DTOs.Employee;
using ERMS_Project.Interfaces;
using Dapper;
using ERMS_Project.Models.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net;

namespace ERMS_Project.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }



        public async Task<GetEmployeesDto> GetEmployee(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add(APIConstants.PARM_NAME_EMPID, id, DbType.Int32);
                parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_GET_BYID, DbType.String);
                var employee = await connection.QueryFirstOrDefaultAsync<GetEmployeesDto>(APIConstants.EMP_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                if (employee != null)
                {
                    var experience = DateTime.Now - employee.DateofJoining;
                    string totalExp = $"{Convert.ToString(experience.Value.Days / 365)}.{Convert.ToString((experience.Value.Days % 365) / 30)}";
                    employee.TotalExperience = decimal.Parse(totalExp) + employee.TotalExperience;
                }
                return await Task.Run(() => employee);
            }
        }

        public async Task<IEnumerable<GetEmployeesDto>> GetEmployees()
        {
            var parameters = new DynamicParameters();
            parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_GET);

            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<GetEmployeesDto>(APIConstants.EMP_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                employees.ToList().ForEach(itemEmployee =>
                {
                    var experience = DateTime.Now - itemEmployee.DateofJoining;
                    string totalExp = $"{Convert.ToString(experience.Value.Days / 365)}.{Convert.ToString((experience.Value.Days % 365) / 30)}";
                    itemEmployee.TotalExperience = decimal.Parse(totalExp) + itemEmployee.TotalExperience;

                });
                return (employees);
            }
        }

        public async Task<IEnumerable<GetEmployeesDto>> GetManagers()
        {
            var parameters = new DynamicParameters();
            parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_GET);

            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<GetEmployeesDto>(APIConstants.MANAGERS_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                return employees.ToList();

            }
        }

        //public async Task<int> GetEmployeeCode()
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add(APIConstants.EMP_SEQ, null, DbType.Int32, ParameterDirection.InputOutput);

        //    using (var connection = _context.CreateConnection())
        //    {
        //        int lastSequenceNumber = await connection.QuerySingleAsync<int>(APIConstants.EMPSEQ_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
        //        return lastSequenceNumber;
        //    }
        //}


        public async Task<IEnumerable<GetEmployeeCountDto>> GetEmployeeCount()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var EmployeeCount = await connection.QueryAsync<GetEmployeeCountDto>(APIConstants.EMP_COUNT_SP_NAME, commandType: CommandType.StoredProcedure);
                    return EmployeeCount.ToList();
                }
            }
            catch (Exception)
            {
                return Enumerable.Empty<GetEmployeeCountDto>();
            }
        }

        public async Task<ResponseClass> GetDesignations()
        {
            var response = new ResponseClass();
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_GET);
                var designation = await connection.QueryAsync<GetDesignationDto>(APIConstants.DESIGNATION_SP, parameters, commandType: CommandType.StoredProcedure);
                if (designation.Count() == 0)
                {
                    response.message = "No Record Found!";
                    response.statusCode = HttpStatusCode.NotFound;
                }
                else
                {
                    response.statusCode = HttpStatusCode.OK;
                    response.message = "Data Fetched Successfully";
                    response.data = designation;
                }
            }
            return response;
        }

        public async Task<Employees> GetEmployeeByEmployeeId(int id)
        {
            var procedureName = "ShowEmployeeForProvidedEmployeeId";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryFirstOrDefaultAsync<Employees>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return employee;
            }
        }

        public async Task<ResponseClass> GetEmployeeswithFilter(string Name)
        {
            ResponseClass responseClass = null;
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_NAME_GET_BYNAME);//PARM_VAL_GET);
                    parameters.Add(APIConstants.PARM_NAME_EMP_NAME, Name);
                    var AccountwithFilter = await connection.QueryAsync<dynamic>(APIConstants.EMP_SP_NAME/*EMP_SP_Filter_NAME*/, parameters, commandType: CommandType.StoredProcedure);
                    responseClass = new ResponseClass
                    {
                        statusCode = System.Net.HttpStatusCode.OK,
                        message = "Data Fetch Successfully",
                        data = AccountwithFilter
                    };
                }
            }
            catch (Exception ex)
            {
                responseClass = new ResponseClass
                {
                    statusCode = System.Net.HttpStatusCode.InternalServerError,
                    message = ex.Message,
                };
            }
            return await Task.Run(() => responseClass);
        }

        public async Task<int> CreateEmployee(EmployeeDto employee)
        {
            var employeeId = 0;
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add(APIConstants.PARM_NAME_FNAME, employee.FirstName, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_MNAME, employee.MiddleName, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_LNAME, employee.LastName, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_DATEOFJOINING, employee.DateofJoining, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_EMPCODE, employee.EmployeeCode, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_OFFICIALMALE, employee.OfficeEmailAddress, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_EMPTYPEID, employee.EmployeeTypeId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_REVISEDLOCATIONID, employee.RevisedLocationId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_DESIGNATION, employee.Designation, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_OVERALLEXPERIENCE, employee.TotalExperience, DbType.Decimal, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_REPORTINGMANAGERID, employee.L1ManagerId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_EMPMENTSATUS, employee.EmploymentStatus, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_ISENGINEERING, employee.IsEngineering, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_IsNextAssignmentIdentified, employee.IsNextAssignmentIdentified, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_SUBPRACTICEID, employee.SubPracticeId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_NEXTASSIGNMENTNAME, employee.NextAssignmentName, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_NEXTASSIGNMENTSTARTDATE, employee.NextAssignmentStartDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_CREATEDBY, employee.CreatedById, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_LASTWORKINGDATE, employee.LastWorkingDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_ReportingMANAGERNAME, employee.L1ManagerName, DbType.String, ParameterDirection.Input);


                    parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_CREATE, DbType.String);

                    employeeId = await connection.QuerySingleAsync<int>(APIConstants.EMP_ADDEDIT_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                    return employeeId;
                }
            }
            catch (System.InvalidOperationException)
            {
                return -1;
            }
        }

        public async Task<int> UpdateEmployee(int id, EmployeeDto employee)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var parameters = new DynamicParameters();
                    parameters.Add(APIConstants.PARM_NAME_EMPID, id, DbType.Int32, ParameterDirection.InputOutput);
                    parameters.Add(APIConstants.PARM_NAME_FNAME, employee.FirstName, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_MNAME, employee.MiddleName, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_LNAME, employee.LastName, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_DATEOFJOINING, employee.DateofJoining, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_EMPCODE, employee.EmployeeCode, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_OFFICIALMALE, employee.OfficeEmailAddress, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_EMPTYPEID, employee.EmployeeTypeId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_REVISEDLOCATIONID, employee.RevisedLocationId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_DESIGNATION, employee.Designation, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_OVERALLEXPERIENCE, employee.TotalExperience, DbType.Decimal, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_REPORTINGMANAGERID, employee.L1ManagerId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_EMPMENTSATUS, employee.EmploymentStatus, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_SUBPRACTICEID, employee.SubPracticeId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_ISENGINEERING, employee.IsEngineering, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_IsNextAssignmentIdentified, employee.IsNextAssignmentIdentified, DbType.Boolean, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_NEXTASSIGNMENTNAME, employee.NextAssignmentName, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_NEXTASSIGNMENTSTARTDATE, employee.NextAssignmentStartDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_MODIFYTBY, employee.ModifiedById, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_UPDATE, DbType.String);
                    parameters.Add(APIConstants.PARM_NAME_LASTWORKINGDATE, employee.LastWorkingDate, DbType.DateTime, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARM_NAME_ReportingMANAGERNAME, employee.L1ManagerName, DbType.String, ParameterDirection.Input);



                    var employeeId = await connection.QuerySingleAsync<int>(APIConstants.EMP_ADDEDIT_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                    return employeeId;
                }
            }
            catch (System.InvalidOperationException)
            {
                return -1;
            }
        }

        public async Task<ResponseClass> DeleteEmployeeById(int EmployeeId)
        {
            ResponseClass responseClass = null;
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_DELETE);
                    parameters.Add(APIConstants.PARM_NAME_EMPID, EmployeeId);
                    var DeleteEmployee = await connection.QueryFirstOrDefaultAsync<Employees>(APIConstants.EMP_SP_DELETE_NAME, parameters, commandType: CommandType.StoredProcedure);
                    responseClass = new ResponseClass
                    {
                        statusCode = System.Net.HttpStatusCode.OK,
                        message = "Employee Deleted Successfully",
                        data = DeleteEmployee
                    };
                }
            }
            catch (Exception ex)
            {
                responseClass = new ResponseClass
                {
                    statusCode = System.Net.HttpStatusCode.InternalServerError,
                    message = ex.Message,
                };
            }

            return await Task.Run(() => responseClass);

        }

        public async Task<ResponseClass> DeleteEmployeesById(EmployeeDto employee)
        {
            var response = new ResponseClass();
            if (employee.Ids is null || employee.Ids.Count == 0)
            {
                response.message = "No EmployeeId Found To Delete.";
                response.statusCode = System.Net.HttpStatusCode.NotFound;
            }
            else
            {
                var deleted = new List<int>();
                var notDeleted = new List<int>();
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_DELETE);

                    foreach (var id in employee.Ids)
                    {
                        parameters.Add(APIConstants.PARM_NAME_DELETE_EMP_ID, id, DbType.Int16);
                        try
                        {
                            var responseId = await connection.QueryFirstOrDefaultAsync<int>(APIConstants.EMP_SP_DELETE_NAMES, parameters, commandType: CommandType.StoredProcedure);
                            if (responseId == 200)
                            {
                                deleted.Add(id);
                            }
                            else
                            {
                                notDeleted.Add(id);
                            }
                        }
                        catch (Exception ex)
                        {
                            response.message = ex.Message;
                            response.statusCode = System.Net.HttpStatusCode.NotFound;
                        }
                    }
                    response.data = new { deleted, notDeleted };
                    response.statusCode = System.Net.HttpStatusCode.OK;
                    response.message = (deleted.Count() == 0) ? "Employee Can't Delete." : "Employee Deleted Successfully.";
                }
            }
            return response;
        }
    }
}
