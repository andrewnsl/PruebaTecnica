using PruebaTecnica.Models.Dtos;
using PruebaTecnica.Models.Dtos.Income;
using PruebaTecnica.Models.PayLoad;

namespace PruebaTecnica.Services.Interfaces
{
    public interface IIncomeService
    {
        Task<ResponseServiceDto<List<CarAvailableDto>>> GetCarAvailable(CarAvailableFilterLoad carAvailableFilterLoad);
    }
}