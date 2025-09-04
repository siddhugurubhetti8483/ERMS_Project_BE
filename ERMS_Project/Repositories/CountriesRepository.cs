using System.Data;
using System.Net;
using Dapper;
using ERMS_Project.Constants;
using ERMS_Project.DTOs;
using ERMS_Project.DTOs.Employee;
using ERMS_Project.Interfaces;

namespace ERMS_Project.Repositories
{
    public class CountriesRepository : ICountryRepository
    {
        private readonly IDapperContext _context;

        public CountriesRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<ResponseClass> GetCountries()
        {
            var response = new ResponseClass();
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_GET);
                var country = await connection.QueryAsync<CountryDTO>(APIConstants.SP_NAME_USP_CountryMaster, parameters, commandType: CommandType.StoredProcedure);
                if (country.Count() == 0)
                {
                    response.message = "No Record Found!";
                    response.statusCode = HttpStatusCode.NotFound;

                }
                else
                {
                    response.statusCode = HttpStatusCode.OK;
                    response.message = "Data Fetched Successfully";
                    response.data = country;
                }
            }
            return response;
        }

        public async Task<ResponseClass> GetCountryById(int Id)
        {
            var response = new ResponseClass();
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_GET_BYID);
                parameters.Add(APIConstants.PARAM_NAME_COUNTRYID, Id, DbType.Int16);
                var country = await connection.QueryFirstOrDefaultAsync<CountryDTO>(APIConstants.SP_NAME_USP_CountryMaster, parameters, commandType: CommandType.StoredProcedure);

                if (country != null)
                {
                    response.statusCode = HttpStatusCode.OK;
                    response.message = "Data Fetched Successfully";
                    response.data = country;
                }
                else
                {
                    response.statusCode = HttpStatusCode.NotFound;
                    response.message = $"Invalid country Id : {Id}";
                }
            }
            return response;
        }

        public async Task<ResponseClass> GetCountryByName(string name)
        {
            var response = new ResponseClass();
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_NAME_GET_BYNAME);
                parameters.Add(APIConstants.PARAM_NAME_COUNTRYNAME, name, DbType.String);
                var country = await connection.QueryAsync<CountryDTO>(APIConstants.SP_NAME_USP_CountryMaster, parameters, commandType: CommandType.StoredProcedure);

                if (country.Any())
                {
                    response.statusCode = HttpStatusCode.OK;
                    response.message = "Data Fetched Successfully";
                    response.data = country;
                }
                else
                {
                    response.statusCode = HttpStatusCode.NotFound;
                    response.message = $"Invalid country Name : {name}";
                }
            }
            return response;
        }

        public async Task<ResponseClass> AddCountry(CountryDTO countryDTO)
        {
            var response = new ResponseClass();

            if (string.IsNullOrWhiteSpace(countryDTO.CountryName))
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.message = "Country name is required!";
                return response;
            }

            var parameters = new DynamicParameters();
            parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARAM_VALUE_CREATE);
            parameters.Add(APIConstants.PARAM_NAME_COUNTRYNAME, countryDTO.CountryName, DbType.String);
            parameters.Add(APIConstants.PARAM_NAME_REGION, countryDTO.Region, DbType.String);
            parameters.Add(APIConstants.PARAM_NAME_CREATEDBY, countryDTO.CreatedById, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var country = await connection.ExecuteScalarAsync<int>(APIConstants.SP_NAME_USP_CountryMaster, parameters, commandType: CommandType.StoredProcedure);

                if (country == 409)
                {
                    response.statusCode = HttpStatusCode.Conflict;
                    response.message = "COUNTRY NAME ALREADY EXISTS!!!";
                }
                else if (country > 0)
                {
                    countryDTO.CountryId = country;
                    response.statusCode = HttpStatusCode.OK;
                    response.message = "COUNTRY ADDED SUCCESSFULLY!!";
                    response.data = countryDTO;
                }
                else
                {
                    response.statusCode = HttpStatusCode.BadRequest;
                    response.message = "Failed to add country.";
                }

            }
            return response;
        }

        public async Task<ResponseClass> UpdateCountry(CountryDTO countryDTO, int Id)
        {
            var response = new ResponseClass();

            var parameters = new DynamicParameters();
            parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_UPDATE);
            parameters.Add(APIConstants.PARAM_NAME_COUNTRYID, Id, DbType.Int32);
            parameters.Add(APIConstants.PARAM_NAME_COUNTRYNAME, countryDTO.CountryName, DbType.String);
            parameters.Add(APIConstants.PARAM_NAME_REGION, countryDTO.Region, DbType.String);
            parameters.Add(APIConstants.PARAM_NAME_MODIFYTBY, countryDTO.ModifiedById, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var country = await connection.QueryFirstOrDefaultAsync<int>(APIConstants.SP_NAME_USP_CountryMaster, parameters, commandType: CommandType.StoredProcedure);

                if (country == 402)
                {
                    response.statusCode = HttpStatusCode.NotFound;
                    response.message = "COUNTRY NAME ALREADY EXISTS!!!";
                }
                else if (country == 200)
                {
                    response.statusCode = HttpStatusCode.OK;
                    response.message = "COUNTRY UPDATED SUCCESSFULLY!!";
                    response.data = countryDTO;                    
                }
                else
                {
                    response.statusCode = HttpStatusCode.NotFound;
                    response.message = "This country id: " + Id.ToString() + " does not exist in database";
                }

            }
            return response;
        }

        public async Task<ResponseClass> DeleteCountries(CountryDTO country)
        {
            var response = new ResponseClass();

            if (country.Ids == null || !country.Ids.Any())
            {
                response.message = "No CountryId Found To Delete.";
                response.statusCode = HttpStatusCode.NotFound;
                return response;
            }

            var deleted = new List<int>();
            var notDeleted = new List<int>();

            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_DELETE);

                foreach (var id in country.Ids)
                {                    
                    parameters.Add(APIConstants.PARAM_NAME_COUNTRYID, id, DbType.Int16);
                    parameters.Add(APIConstants.PARAM_NAME_MODIFYTBY, country.ModifiedById, DbType.String);

                    try
                    {
                        var result = await connection.QueryFirstOrDefaultAsync<int>(
                            APIConstants.SP_NAME_USP_CountryMaster,
                            parameters,
                            commandType: CommandType.StoredProcedure);

                        if (result == 200)
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
                        //notDeleted.Add(id);
                        //Console.WriteLine($"[ERROR] Delete CountryId {id} failed. Reason: {ex.Message}");
                    }
                }
                response.data = new { deleted, notDeleted };
                response.statusCode = deleted.Any() ? HttpStatusCode.OK : HttpStatusCode.NotFound;
                response.message = deleted.Count > 0 ? "Country Deleted Successfully." : "No Country Deleted.";
            }

            return response;
        }


        //public async Task<ResponseClass> DeleteCountries(CountryDTO country)
        //{
        //    var response = new ResponseClass();
        //    if (country.Ids is null || country.Ids.Count == 0)
        //    {
        //        response.message = "No CountryId Found To Delete.";
        //        response.statusCode = HttpStatusCode.NotFound;
        //    }
        //    else
        //    {
        //        var deleted = new List<int>();
        //        var notDeleted = new List<int>();
        //        using (var connection = _context.CreateConnection())
        //        {
        //            var parameters = new DynamicParameters();
        //            parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_DELETE);

        //            foreach (var id in country.Ids)
        //            {
        //                parameters.Add(APIConstants.PARAM_NAME_COUNTRYID, id, DbType.Int16);
        //                try
        //                {
        //                    var responseId = await connection.ExecuteScalarAsync<int>(APIConstants.SP_NAME_USP_CountryMaster, parameters, commandType: CommandType.StoredProcedure);
        //                    if (responseId == 200)
        //                    {
        //                        deleted.Add(id);
        //                    }
        //                    else
        //                    {
        //                        notDeleted.Add(id);
        //                    }
        //                }
        //                catch (InvalidOperationException ex)
        //                {
        //                    response.message = ex.Message;
        //                    response.statusCode = HttpStatusCode.NotFound;
        //                }
        //            }
        //            response.data = new { deleted, notDeleted };
        //            response.statusCode = HttpStatusCode.OK;
        //            response.message = (deleted.Count() == 0) ? "Country Can't Delete." : "Country Deleted Successfully.";
        //        }
        //    }
        //    return response;
        //}
    }
}
