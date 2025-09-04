using ERMS_Project.DTOs;
using ERMS_Project.DTOs.Employee;

namespace ERMS_Project.Interfaces
{
    public interface IAccountRepository
    {
        public Task<IEnumerable<AccountDTO>> GetAccounts();
        public Task<IEnumerable<CountOfAccountDTO>> GetAccountCount();
        public Task<AccountDTO> GetAccount(int id);
        public Task<int> CreateAccount(AccountDTO accounts);
        public Task<int> UpdateAccount(int id, AccountDTO accounts);
        public Task<ResponseClass> GetAccountwithFilter(string Name);
        public Task<ResponseClass> DeleteAccountsById(int AccountId);
        public Task<ResponseClass> DeleteAccountsByIds(AccountDTO account);
    }
}
