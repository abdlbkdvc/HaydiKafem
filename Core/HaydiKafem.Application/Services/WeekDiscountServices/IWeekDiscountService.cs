using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Dtos.WeekDiscountDtos;

namespace HaydiKafem.Application.Services.WeekDiscountServices
{
    public interface IWeekDiscountService
    {
        Task<ResponseDto<List<ResultWeekDiscountDto>>> GetAllWeekDiscountAsync();
        Task<ResponseDto<GetByIdWeekDiscountDto>> GetByIdWeekDiscountAsync(int id);
        Task<ResponseDto<object>> CreateWeekDiscountAsync(CreateWeekDiscountDto dto);
        Task<ResponseDto<object>> UpdateWeekDiscountAsync(UpdateWeekDiscountDto dto);
        Task<ResponseDto<object>> DeleteWeekDiscountAsync(int id);
    }
}
