using AutoMapper;
using PruebaTecnica.DataAccess.Repository;
using PruebaTecnica.Helpers.LoggerManager;
using PruebaTecnica.Models.Dtos.Generic;
using PruebaTecnica.Models.Dtos;
using PruebaTecnica.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnica.Models.PayLoad;
using PruebaTecnica.Models.Dtos.Income;
using PruebaTecnica.Helpers.Extensions;
using PruebaTecnica.Services.Interfaces;

namespace PruebaTecnica.Services
{
    public class IncomeService : Service, IIncomeService
    {
        private readonly IDataRepository<CarAvailable> _carAvailableRepository;
        public IncomeService(IMapper mapper, ILog log, IDataRepository<CarAvailable> carAvailableRepository)
            : base(mapper, log)
        {
            _carAvailableRepository = carAvailableRepository;
        }

        public async Task<ResponseServiceDto<List<CarAvailableDto>>> GetCarAvailable(CarAvailableFilterLoad carAvailableFilterLoad)
        {
            ResponseServiceDto<List<CarAvailableDto>> response = new();
            try
            {
                List<CarAvailable> carAvailable = await _carAvailableRepository.ListInclude(new List<string>() { "Car", "Car.CarBrandNavigation", "CollectionLocation", "ReturnLocation" },
                    x => x.CarAvailableActive
                    && (carAvailableFilterLoad.DepartmentId.HasValue ? x.ReturnLocation.City.DepartmentId == carAvailableFilterLoad.DepartmentId.Value : x.ReturnLocation.City.DepartmentId == x.ReturnLocation.City.DepartmentId)
                    && (carAvailableFilterLoad.CityId.HasValue ? x.ReturnLocation.CityId == carAvailableFilterLoad.CityId.Value : x.ReturnLocation.CityId == x.ReturnLocation.CityId)
                    && (carAvailableFilterLoad.CollectionLocationId.HasValue ? x.CollectionLocationId == carAvailableFilterLoad.CollectionLocationId.Value : x.CollectionLocationId == x.CollectionLocationId)
                    && (carAvailableFilterLoad.ReturnLocationId.HasValue ? x.ReturnLocationId == carAvailableFilterLoad.ReturnLocationId.Value : x.ReturnLocationId == x.ReturnLocationId)
                    );
                List<CarAvailableDto> carAvailableDto = _mapper.Map<List<CarAvailableDto>>(carAvailable);

                return await response.GetResultSucces(carAvailableDto);
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return await response.GetResultError();
            }
        }
    }
}
