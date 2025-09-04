using System.Data;
using Dapper;
using ERMS_Project.Constants;
using ERMS_Project.DTOs;
using ERMS_Project.DTOs.Employee;
using ERMS_Project.Interfaces;

namespace ERMS_Project.Repositories
{
    public class EmployeeAllocationRepository : IEmployeeAllocationRepository
    {
        private readonly IDapperContext _context;

        public EmployeeAllocationRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllocationDTO>> GetEmployeeAllocation()
        {
            var parameters = new DynamicParameters();
            parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_GET);
            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<AllocationDTO>(APIConstants.EMPLOYEEALLOCATION_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                return employees.ToList();
            }
        }
        
        public async Task<EmployeeAllocationDTO> GetEmployeeAllocationById(int allocationId)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add(APIConstants.PARAM_NAME_ALLOCATIONID, allocationId, DbType.Int32);
                parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARAM_MODE_GET_EMPLOYEE_ALLOCATION_BY_ALLOCATION_ID, DbType.String);

                var employee = await connection.QuerySingleOrDefaultAsync<EmployeeAllocationDTO>(APIConstants.EMPLOYEE_ALLOCATION_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                return employee;
            }
        }
        
        public async Task<CountOfEmployeeAllocationsDTO> GetEmployeeCountAllocations()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var EmployeeCount = await connection.QuerySingleAsync<CountOfEmployeeAllocationsDTO>(APIConstants.EMPLOYEE_COUNTALLOCATIONS_SP_NAME, commandType: CommandType.StoredProcedure);
                    return await Task.Run(() => EmployeeCount);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public async Task<string> AddEmployeeAllocation(EmployeeAllocationDTO employeeAllocation)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add(APIConstants.PARAM_NAME_PROJECTID, employeeAllocation.ProjectId, DbType.Int32);
                parameters.Add(APIConstants.PARM_NAME_EMPID, employeeAllocation.EmployeeId, DbType.Int32);
                parameters.Add(APIConstants.PARAM_NAME_STARTDATE, employeeAllocation.StartDate, DbType.DateTime);
                parameters.Add(APIConstants.PARAM_NAME_ENDDATE, employeeAllocation.EndDate, DbType.DateTime);
                parameters.Add(APIConstants.PARAM_NAME_ALLOCATION_STATUS, employeeAllocation.AllocationStatus, DbType.String);
                parameters.Add(APIConstants.PARAM_NAME_ISBILLABLE, employeeAllocation.IsBillable, DbType.Boolean);
                parameters.Add(APIConstants.PARAM_NAME_ISUTILIZED, employeeAllocation.IsUtilized, DbType.Boolean);
                parameters.Add(APIConstants.PARAM_NAME_ALLOCATION_PERCENTAGE, employeeAllocation.AllocationPercentage, DbType.Int32);
                parameters.Add(APIConstants.PARAM_NAME_BILLABLE_PERCENTAGE, employeeAllocation.BillablePercentage, DbType.Int32);
                parameters.Add(APIConstants.PARAM_NAME_REMARKS, employeeAllocation.Remarks, DbType.String);
                parameters.Add(APIConstants.PARAM_NAME_CREATEDBY, employeeAllocation.CreatedBy, DbType.Int32);

                parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARAM_MODE_ALLOCATE_EMPLOYEE, DbType.String);
                try
                {
                    var allocationId = await connection.QuerySingleAsync<int>(APIConstants.EMPLOYEE_ALLOCATION_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                }
                catch (InvalidOperationException)
                {
                    return "EMPLOYEE ALLOCATION DETAILS ALREADY EXISTS!";
                }

                return "EMPLOYEE ALLOCATION DETAILS ADDED SUCCESSFULLY!";
            }

        }

        public async Task<EmployeeAllocationDTO> UpdateEmployeeAllocation(EmployeeAllocationDTO updateEmployeeAllocation)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add(APIConstants.PARAM_NAME_ALLOCATIONID, updateEmployeeAllocation.AllocationId, DbType.Int32);
                parameters.Add(APIConstants.PARAM_NAME_PROJECTID, updateEmployeeAllocation.ProjectId, DbType.Int32);
                parameters.Add(APIConstants.PARM_NAME_EMPID, updateEmployeeAllocation.EmployeeId, DbType.Int32);
                parameters.Add(APIConstants.PARAM_NAME_STARTDATE, updateEmployeeAllocation.StartDate, DbType.DateTime);
                parameters.Add(APIConstants.PARAM_NAME_ENDDATE, updateEmployeeAllocation.EndDate, DbType.DateTime);
                parameters.Add(APIConstants.PARAM_NAME_ALLOCATION_STATUS, updateEmployeeAllocation.AllocationStatus, DbType.String);
                parameters.Add(APIConstants.PARAM_NAME_ISBILLABLE, updateEmployeeAllocation.IsBillable, DbType.Boolean);
                parameters.Add(APIConstants.PARAM_NAME_ISUTILIZED, updateEmployeeAllocation.IsUtilized, DbType.Boolean);
                parameters.Add(APIConstants.PARAM_NAME_ALLOCATION_PERCENTAGE, updateEmployeeAllocation.AllocationPercentage, DbType.Int32);
                parameters.Add(APIConstants.PARAM_NAME_BILLABLE_PERCENTAGE, updateEmployeeAllocation.BillablePercentage, DbType.Int32);
                parameters.Add(APIConstants.PARAM_NAME_REMARKS, updateEmployeeAllocation.Remarks, DbType.String);
                parameters.Add(APIConstants.PARAM_NAME_MODIFIEDBY, updateEmployeeAllocation.ModifiedBy, DbType.Int32);

                parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_UPDATE, DbType.String);

                var id = await connection.QuerySingleAsync<int>(APIConstants.EMPLOYEE_ALLOCATION_SP_NAME, parameters, commandType: CommandType.StoredProcedure);

                var update = new EmployeeAllocationDTO
                {
                    AllocationId = id,
                    ProjectId = updateEmployeeAllocation.ProjectId,
                    EmployeeId = updateEmployeeAllocation.EmployeeId,
                    StartDate = updateEmployeeAllocation.StartDate,
                    EndDate = updateEmployeeAllocation.EndDate,
                    AllocationStatus = updateEmployeeAllocation.AllocationStatus,
                    AllocationPercentage = updateEmployeeAllocation.AllocationPercentage,
                    BillablePercentage = updateEmployeeAllocation.BillablePercentage,
                    Remarks = updateEmployeeAllocation.Remarks,
                    ModifiedBy = updateEmployeeAllocation.ModifiedBy,
                    IsBillable = updateEmployeeAllocation.IsBillable,
                    IsUtilized = updateEmployeeAllocation.IsUtilized,
                };
                return update;
            }
        }
       
        public async Task<ResponseClass> DeleteEmployeeAllocation(AllocationDTO allocation)
        {
            var response = new ResponseClass();
            if (allocation.Ids is null || allocation.Ids.Count == 0)
            {
                response.message = "No AllocationId Found To Delete.";
                response.statusCode = System.Net.HttpStatusCode.NotFound;
            }
            else
            {
                var deleted = new List<int>();
                var notDeleted = new List<int>();
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_DELETE, DbType.String);

                    foreach (var id in allocation.Ids)
                    {
                        parameters.Add(APIConstants.PARAM_NAME_ALLOCATIONID, id, DbType.Int16);
                        try
                        {
                            var responseId = await connection.QueryFirstOrDefaultAsync<int>(APIConstants.EMPLOYEEALLOCATION_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
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
                    response.message = (deleted.Count() == 0) ? "Employee Allocation Can't Delete." : "Employee Allocation Deleted Successfully.";
                }
            }
            return response;
        }

    }
}
