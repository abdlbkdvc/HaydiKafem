using HaydiKafem.Application.Dtos.FooterAddressDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;

namespace HaydiKafem.Application.Services.FooterAddressServices
{
    public interface IFooterAddressService
    {
        Task<ResponseDto<List<ResultFooterAddressDto>>> GetAllFooterAddressAsync();
        Task<ResponseDto<GetByIdFooterAddressDto>> GetByIdFooterAddressAsync(int id);
        Task<ResponseDto<object>> CreateFooterAddressAsync(CreateFooterAddressDto dto);
        Task<ResponseDto<object>> UpdateFooterAddressAsync(UpdateFooterAddressDto dto);
        Task<ResponseDto<object>> DeleteFooterAddressAsync(int id);
    }
}
