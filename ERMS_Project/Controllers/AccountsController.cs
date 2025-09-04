using ERMS_Project.DTOs;
using ERMS_Project.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepo;

        public AccountsController(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [HttpGet("GetAccounts")]
        //[Authorize]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                var accounts = await _accountRepo.GetAccounts();
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("AccountCounts")]
        //[Authorize]

        public async Task<IActionResult> GetAccountCount()
        {
            try
            {
                var account_count = await _accountRepo.GetAccountCount();
                return Ok(account_count);
            }
            catch (Exception)
            {
                //log error
                return BadRequest();
            }

        }

        [HttpGet("{id}", Name = "AccountById")]
        //[Authorize]
        public async Task<IActionResult> GetAccount(int id)
        {
            try
            {
                var account = await _accountRepo.GetAccount(id);
                if (account == null)
                    return NotFound();

                return Ok(account);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateAccount")]
        //[Authorize]
        public async Task<IActionResult> CreateAccount([FromBody] AccountDTO accountDTO)
        {
            try
            {
                if (accountDTO == null)
                {
                    return BadRequest(accountDTO);
                }
                var createAccount = await _accountRepo.CreateAccount(accountDTO);
                if (createAccount != 0 && createAccount != -1)
                {
                    return Ok(new
                    {
                        Success = true,
                        Message = "Account created Successfully with AccountId = " + createAccount
                    });
                }
                else if (createAccount == -1)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Account already exists."
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

        [HttpPut("UpdateAccount/{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] AccountDTO accountDTO)
        {
            try
            {

                var dbAccount = await _accountRepo.GetAccount(id);
                if (dbAccount == null)
                    return NotFound();

                var AccountId = await _accountRepo.UpdateAccount(id, accountDTO);
                if (AccountId != 0 && AccountId == id)
                {
                    return Ok(new
                    {
                        Success = true,
                        Message = "Account updated Successfully with AccountId = " + AccountId
                    });
                }
                else if (AccountId == -1)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Account already exists."
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

        [HttpGet("[action]/{Name}", Name = "AccountByname")]
        //[Authorize]
        public async Task<IActionResult> GetAccountwithFilter(string Name)
        {
            try
            {
                var ResponseData = await _accountRepo.GetAccountwithFilter(Name);
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

        [HttpDelete("DeleteAccountsById")]
        //[Authorize]
        public async Task<IActionResult> DeleteAccountsById([FromQuery] int Id)
        {
            try
            {
                var ResponseData = await _accountRepo.DeleteAccountsById(Id);
                if (ResponseData == null)
                {
                    return BadRequest(new { ResponseData });
                }
                return Ok(ResponseData);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to Delete this Account");
            }
        }


        [HttpDelete("DeleteAccountsByIds")]
        //[Authorize]
        public async Task<IActionResult> DeleteAccountsByIds([FromBody] AccountDTO account)
        {
            try
            {
                var data = await _accountRepo.DeleteAccountsByIds(account);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
