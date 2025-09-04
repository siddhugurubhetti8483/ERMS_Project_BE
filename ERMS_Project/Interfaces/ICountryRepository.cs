using ERMS_Project.DTOs;
using ERMS_Project.DTOs.Employee;

namespace ERMS_Project.Interfaces
{
    public interface ICountryRepository
    {
        public Task<ResponseClass> GetCountries();
        public Task<ResponseClass> GetCountryById(int Id);
        public Task<ResponseClass> GetCountryByName(string name);
        public Task<ResponseClass> AddCountry(CountryDTO countryDTO);
        public Task<ResponseClass> UpdateCountry(CountryDTO countryDTO, int Id);
        public Task<ResponseClass> DeleteCountries(CountryDTO country);
    }
}
