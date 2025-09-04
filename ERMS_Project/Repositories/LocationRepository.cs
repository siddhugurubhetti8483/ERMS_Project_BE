using System.Data;
using System.Net;
using Dapper;
using ERMS_Project.Constants;
using ERMS_Project.DTOs;
using ERMS_Project.DTOs.Employee;
using ERMS_Project.Interfaces;

namespace ERMS_Project.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IDapperContext _context;

        public LocationRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<ResponseClass> GetLocations()
        {
            var response = new ResponseClass();
            var parameters = new DynamicParameters();
            parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_GET);
            using (var connection = _context.CreateConnection())
            {
                var location = await connection.QueryAsync<LocationDTO>(APIConstants.USP_LOCATION_NAME, parameters, commandType: CommandType.StoredProcedure);
                if (location.Count() == 0)
                {
                    response.statusCode = HttpStatusCode.NotFound;
                    response.message = "No Record Found!";
                }
                else
                {
                    response.statusCode = HttpStatusCode.OK;
                    response.message = "Data Fetched Successfully";
                    response.data = location.ToList();
                }
            }
            return response;
        }
    }
}
