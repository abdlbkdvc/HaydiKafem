using HaydiKafem.Application.Dtos.ColdDrinkDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;

namespace HaydiKafem.Application.Services.ColdDrinkServices
{
    public interface IColdDrinkService
    {
        Task<ResponseDto<List<ResultColdDrinkDto>>> GetAllColdDrinkAsync();
        Task<ResponseDto<GetByIdColdDrinkDto>> GetByIdColdDrinkAsync(int id);
        Task<ResponseDto<object>> CreateColdDrinkAsync(CreateColdDrinkDto dto);
        Task<ResponseDto<object>> UpdateColdDrinkAsync(UpdateColdDrinkDto dto);
        Task<ResponseDto<object>> DeleteColdDrinkAsync(int id);
    }
}
