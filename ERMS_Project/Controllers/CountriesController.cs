using ERMS_Project.DTOs;
using ERMS_Project.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countriesRepo;
        public CountriesController(ICountryRepository countriesRepo)
        {
            _countriesRepo = countriesRepo;
        }

        [HttpGet("GetCountries")]
        //[Authorize]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var country = await _countriesRepo.GetCountries();
                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetCountryById")]
        //[Authorize]
        public async Task<IActionResult> GetCountryById(int Id)
        {
            try
            {
                var country = await _countriesRepo.GetCountryById(Id);
                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetCountryByName")]
        //[Authorize]
        public async Task<IActionResult> GetCountryByName(string name)
        {
            try
            {
                var country = await _countriesRepo.GetCountryByName(name);
                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("AddCountry")]
        //[Authorize]
        public async Task<IActionResult> AddCountry([FromBody] CountryDTO countryDTO)
        {
            try
            {
                var data = await _countriesRepo.AddCountry(countryDTO);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateCountry")]
        //[Authorize]
        public async Task<IActionResult> UpdateCountry([FromBody] CountryDTO countryDTO, [FromQuery] int Id)
        {
            try
            {
                var data = await _countriesRepo.UpdateCountry(countryDTO, Id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("deleteByCountryIds")]
        //[Authorize]
        public async Task<IActionResult> DeleteCountries([FromBody] CountryDTO country)
        {
            try
            {
                var data = await _countriesRepo.DeleteCountries(country);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
