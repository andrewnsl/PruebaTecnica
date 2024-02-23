using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models.Dtos;
using PruebaTecnica.Models.Dtos.Generic;
using PruebaTecnica.Services.Interfaces;

namespace PruebaTecnica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        private readonly IGenericService _genericService;

        public GenericController(IGenericService genericService)
        {
            _genericService = genericService;
        }

        /// <summary>
        /// Obtiene los paises
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCountries")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseServiceDto<List<CountryDto>>>> GetCountries()
        {
            return Ok(await _genericService.GetCountries());
        }

        /// <summary>
        /// Obtiene los departamentos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDepartments/{codeCountry}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseServiceDto<List<DepartmentDto>>>> GetDepartments(int codeCountry)
        {
            return Ok(await _genericService.GetDepartments(codeCountry));
        }

        /// <summary>
        /// Obtiene las ciudades
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCities/{codeDepartment}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseServiceDto<List<CityDto>>>> GetCities(int codeDepartment)
        {
            return Ok(await _genericService.GetCities(codeDepartment));
        }

        /// <summary>
        /// Obtiene todas localidades
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetLocations/{codeCity}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseServiceDto<List<LocationDto>>>> GetLocations(int codeCity)
        {
            return Ok(await _genericService.GetLocations(codeCity));
        }
    }
}
