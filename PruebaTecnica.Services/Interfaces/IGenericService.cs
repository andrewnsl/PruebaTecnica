using PruebaTecnica.Models.Dtos;
using PruebaTecnica.Models.Dtos.Generic;

namespace PruebaTecnica.Services.Interfaces
{
    public interface IGenericService
    {
        Task<ResponseServiceDto<List<CityDto>>> GetCities(int codeDepartment);
        Task<ResponseServiceDto<List<CountryDto>>> GetCountries();
        Task<ResponseServiceDto<List<DepartmentDto>>> GetDepartments(int codeCountry);
        Task<ResponseServiceDto<List<LocationDto>>> GetLocations(int codeCity);
    }
}