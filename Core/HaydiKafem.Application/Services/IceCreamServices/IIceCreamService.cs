using HaydiKafem.Application.Dtos.IceCreamDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;

namespace HaydiKafem.Application.Services.IceCreamServices
{
    public interface IIceCreamService
    {
        Task<ResponseDto<List<ResultIceCreamDto>>> GetAllIceCreamAsync();
        Task<ResponseDto<GetByIdIceCreamDto>> GetByIdIceCreamAsync(int id);
        Task<ResponseDto<object>> CreateIceCreamAsync(CreateIceCreamDto dto);
        Task<ResponseDto<object>> UpdateIceCreamAsync(UpdateIceCreamDto dto);
        Task<ResponseDto<object>> DeleteIceCreamAsync(int id);
    }
}
