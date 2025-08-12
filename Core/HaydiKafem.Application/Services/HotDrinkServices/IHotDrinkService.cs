using HaydiKafem.Application.Dtos.HotDrinkDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;

namespace HaydiKafem.Application.Services.HotDrinkServices
{
    public interface IHotDrinkService
    {
        Task<ResponseDto<List<ResultHotDrinkDto>>> GetAllHotDrinkAsync();
        Task<ResponseDto<GetByIdHotDrinkDto>> GetByIdHotDrinkAsync(int id);
        Task<ResponseDto<object>> CreateHotDrinkAsync(CreateHotDrinkDto dto);
        Task<ResponseDto<object>> UpdateHotDrinkAsync(UpdateHotDrinkDto dto);
        Task<ResponseDto<object>> DeleteHotDrinkAsync(int id);
    }
}
