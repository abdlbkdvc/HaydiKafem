using HaydiKafem.Application.Dtos.DesertDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;

namespace HaydiKafem.Application.Services.DesertServices
{
    public interface IDesertService
    {
        Task<ResponseDto<List<ResultDesertDto>>> GetAllDesertAsync();
        Task<ResponseDto<GetByIdDesertDto>> GetByIdDesertAsync(int id);
        Task<ResponseDto<object>> CreateDesertAsync(CreateDesertDto dto);
        Task<ResponseDto<object>> UpdateDesertAsync(UpdateDesertDto dto);
        Task<ResponseDto<object>> DeleteDesertAsync(int id);
    }
}
