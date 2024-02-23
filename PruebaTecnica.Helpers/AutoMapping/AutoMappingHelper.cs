using AutoMapper;
using PruebaTecnica.Models.Dtos.Generic;
using PruebaTecnica.Models.Dtos.Income;
using PruebaTecnica.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Helpers.AutoMapping
{
    public class AutoMappingHelper : Profile
    {
        public AutoMappingHelper()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<City, CityDto>();
            CreateMap<Location, LocationDto>();
            CreateMap<CarAvailable, CarAvailableDto>();
            CreateMap<Car, CarDto>();
            CreateMap<CarBrand, CarBrandDto>();
        }
    }
}
