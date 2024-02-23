using AutoMapper;
using PruebaTecnica.DataAccess.Repository;
using PruebaTecnica.Helpers.Extensions;
using PruebaTecnica.Helpers.LoggerManager;
using PruebaTecnica.Models.Dtos;
using PruebaTecnica.Models.Dtos.Generic;
using PruebaTecnica.Models.Entities;
using PruebaTecnica.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Services
{
    public class GenericService : Service, IGenericService
    {
        private readonly IDataRepository<Country> _countryRepository;
        private readonly IDataRepository<Department> _departmentRepository;
        private readonly IDataRepository<City> _cityRepository;
        private readonly IDataRepository<Location> _locationRepository;

        public GenericService(IMapper mapper, ILog log, IDataRepository<Country> countryRepository, IDataRepository<Department> departmentRepository, IDataRepository<City> cityRepository, IDataRepository<Location> locationRepository)
            : base(mapper, log)
        {
            _countryRepository = countryRepository;
            _departmentRepository = departmentRepository;
            _cityRepository = cityRepository;
            _locationRepository = locationRepository;
        }

        public async Task<ResponseServiceDto<List<CountryDto>>> GetCountries()
        {
            ResponseServiceDto<List<CountryDto>> response = new();
            try
            {
                List<Country> countries = await _countryRepository.List(x => x.CountryActive);
                List<CountryDto> countriesDtos = _mapper.Map<List<CountryDto>>(countries);

                return await response.GetResultSucces(countriesDtos);
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return await response.GetResultError();
            }
        }

        public async Task<ResponseServiceDto<List<DepartmentDto>>> GetDepartments(int codeCountry)
        {
            ResponseServiceDto<List<DepartmentDto>> response = new();
            try
            {
                List<Department> departments = await _departmentRepository.List(x => x.DepartmentActive && x.Country.CountryCode == codeCountry);
                List<DepartmentDto> departmentDtos = _mapper.Map<List<DepartmentDto>>(departments);

                return await response.GetResultSucces(departmentDtos);
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return await response.GetResultError();
            }
        }

        public async Task<ResponseServiceDto<List<CityDto>>> GetCities(int codeDepartment)
        {
            ResponseServiceDto<List<CityDto>> response = new();
            try
            {
                List<City> departments = await _cityRepository.List(x => x.CityActive && x.Department.DepartmentCode == codeDepartment);
                List<CityDto> departmentDtos = _mapper.Map<List<CityDto>>(departments);

                return await response.GetResultSucces(departmentDtos);
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return await response.GetResultError();
            }
        }

        public async Task<ResponseServiceDto<List<LocationDto>>> GetLocations(int codeCity)
        {
            ResponseServiceDto<List<LocationDto>> response = new();
            try
            {
                List<Location> locations = await _locationRepository.List(x => x.LocationActive && x.City.CityCode == codeCity);
                List<LocationDto> locationsDto = _mapper.Map<List<LocationDto>>(locations);

                return await response.GetResultSucces(locationsDto);
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return await response.GetResultError();
            }
        }
    }
}
