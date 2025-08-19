using HaydiKafem.Application.Dtos.CarouselDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;

namespace HaydiKafem.Application.Services.CarouselServices
{
    public interface ICarouselService
    {
        Task<ResponseDto<List<ResultCarouselDto>>> GetAllCarouselAsync();
        Task<ResponseDto<GetByIdCarouselDto>> GetByIdCarouselAsync(int id);
        Task<ResponseDto<object>> CreateCarouselAsync(CreateCarouselDto dto);
        Task<ResponseDto<object>> UpdateCarouselAsync(UpdateCarouselDto dto);
        Task<ResponseDto<object>> DeleteCarouselAsync(int id);
    }
}
