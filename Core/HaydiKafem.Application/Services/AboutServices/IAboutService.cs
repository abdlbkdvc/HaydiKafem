using HaydiKafem.Application.Dtos.AboutDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;

namespace HaydiKafem.Application.Services.AboutServices
{
    public interface IAboutService
    {
        Task<ResponseDto<List<ResultAboutDto>>> GetAllAboutAsync();
        Task<ResponseDto<GetByIdAboutDto>> GetByIdAboutAsync(int id);
        Task<ResponseDto<object>> CreateAboutAsync(CreateAboutDto dto);
        Task<ResponseDto<object>> UpdateAboutAsync(UpdateAboutDto dto);
        Task<ResponseDto<object>> DeleteAboutAsync(int id);
    }
}
