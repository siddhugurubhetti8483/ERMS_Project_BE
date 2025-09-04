using System.Data;
using Dapper;
using ERMS_Project.Constants;
using ERMS_Project.DTOs;
using ERMS_Project.DTOs.Employee;
using ERMS_Project.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ERMS_Project.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDapperContext _context;

        public AccountRepository(IDapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AccountDTO>> GetAccounts()
        {
            var parameters = new DynamicParameters();
            parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_GET);
            using (var connection = _context.CreateConnection())
            {
                var accounts = await connection.QueryAsync<AccountDTO>(APIConstants.ACCOUNT_ADD_EDIT_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                return accounts.ToList();
            }
        }

        public async Task<IEnumerable<CountOfAccountDTO>> GetAccountCount()
        {
            using (var connection = _context.CreateConnection())
            {
                var AccountCount = await connection.QueryAsync<CountOfAccountDTO>(APIConstants.ACCOUNT_COUNT_SP_NAME, commandType: CommandType.StoredProcedure);
                return AccountCount.ToList();
            }
        }

        public async Task<AccountDTO> GetAccount(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_GET_BYID);
            parameters.Add(APIConstants.PARAM_NAME_ACCOUNTID, id, DbType.Int32, ParameterDirection.InputOutput);
            using (var connection = _context.CreateConnection())
            {
                var account = await connection.QuerySingleOrDefaultAsync<AccountDTO>(APIConstants.ACCOUNT_ADD_EDIT_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                return account;
            }
        }

        public async Task<ResponseClass> GetAccountwithFilter(string Name)
        {
            ResponseClass responseClass = null;
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_GET);
                    parameters.Add(APIConstants.PARAM_NAME_NAME, Name);
                    var AccountwithFilter = await connection.QueryAsync<dynamic>(APIConstants.ACCOUNT_ADD_EDIT_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<int> CreateAccount(AccountDTO accounts)
        {
            var accountId = 0;
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add(APIConstants.PARAM_NAME_NAME, accounts.Name, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_DESCRIPTION, accounts.Description, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_ACCOUNTLOCATION, accounts.AccountLocation, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_POCNAME, accounts.POCName, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_POCEMAIL, accounts.POCEmail, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_POCMOBILENUMBER, accounts.PocMobileNumber, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_COUNTRYID, accounts.CountryId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_GSTNUMBER, accounts.GstNumber, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_PAYMENTTERMDURATION, accounts.PaymentTermsDuration, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_CREATEDBY, accounts.CreatedById, DbType.Int32);

                    parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_CREATE, DbType.String);
                    accountId = await connection.QuerySingleAsync<int>(APIConstants.ACCOUNT_ADD_EDIT_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                    return accountId;
                }
            }
            catch (System.InvalidOperationException)
            {
                return -1;
            }
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAccount(int id, AccountDTO accounts)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add(APIConstants.PARAM_NAME_ACCOUNTID, id, DbType.String, ParameterDirection.InputOutput);
                    parameters.Add(APIConstants.PARAM_NAME_NAME, accounts.Name, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_DESCRIPTION, accounts.Description, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_ACCOUNTLOCATION, accounts.AccountLocation, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_POCNAME, accounts.POCName, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_POCEMAIL, accounts.POCEmail, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_POCMOBILENUMBER, accounts.PocMobileNumber, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_COUNTRYID, accounts.CountryId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_GSTNUMBER, accounts.GstNumber, DbType.String, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_PAYMENTTERMDURATION, accounts.PaymentTermsDuration, DbType.Int32, ParameterDirection.Input);
                    parameters.Add(APIConstants.PARAM_NAME_MODIFYTBY, accounts.ModifiedById, DbType.Int32);
                    parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_UPDATE, DbType.String);
                    var AccountId = await connection.QuerySingleAsync<int>(APIConstants.ACCOUNT_ADD_EDIT_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                    return AccountId;
                }
            }
            catch (System.InvalidOperationException)
            {
                return -1;
            }

            throw new NotImplementedException();
        }

        public async Task<ResponseClass> DeleteAccountsById(int AccountId)
        {
            ResponseClass responseClass = null;
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add(APIConstants.PARM_NAME_MODE, APIConstants.PARM_VAL_DELETE);
                    parameters.Add(APIConstants.PARAM_NAME_ACCOUNTID, AccountId);
                    var Deleteaccount = await connection.QueryAsync<ResponseClass>(APIConstants.ACCOUNT_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
                    responseClass = new ResponseClass
                    {
                        statusCode = System.Net.HttpStatusCode.OK,
                        message = "Account Deleted Successfully",
                        data = Deleteaccount
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

        public async Task<ResponseClass> DeleteAccountsByIds(AccountDTO account)
        {
            var response = new ResponseClass();
            if (account.Ids is null || account.Ids.Count == 0)
            {
                response.message = "No AccountId Found To Delete.";
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

                    foreach (var id in account.Ids)
                    {
                        parameters.Add(APIConstants.PARAM_NAME_ACCOUNTID, id, DbType.Int16);
                        try
                        {
                            var responseId = await connection.QueryFirstOrDefaultAsync<int>(APIConstants.ACCOUNT_SP_NAME, parameters, commandType: CommandType.StoredProcedure);
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
                    response.message = (deleted.Count() == 0) ? "Account Can't Delete." : "Account Deleted Successfully.";
                }
            }
            return response;
        }




        

    }
}
