using HaydiKafem.Application.Dtos.Food;
using HaydiKafem.Application.Dtos.ResponseDtos;

namespace HaydiKafem.Application.Services.FoodServices
{
    public interface IFoodService
    {
        Task<ResponseDto<List<ResultFoodDto>>> GetAllFoodsAsync();
        Task<ResponseDto<GetByIdFoodDto>> GetByIdFoodAsync(int id);
        Task<ResponseDto<object>> CreateFoodAsync(CreateFoodDto dto);
        Task<ResponseDto<object>> UpdateFoodAsync(UpdateFoodDto dto);
        Task<ResponseDto<object>> DeleteFoodAsync(int id);
    }
}
