using AutoMapper;
using FluentValidation;
using HaydiKafem.Application.Dtos.FooterAddressDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Interfaces;
using HaydiKafem.Domain.Entities;

namespace HaydiKafem.Application.Services.FooterAddressServices
{
    public class FooterAddressService : IFooterAddressService
    {
        private readonly IRepository<FooterAddress> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateFooterAddressDto> _createFooterAddressValidator;
        private readonly IValidator<UpdateFooterAddressDto> _updateFooterAddressValidator;

        public FooterAddressService(IRepository<FooterAddress> repository, IMapper mapper, IValidator<CreateFooterAddressDto> createFooterAddressValidator, IValidator<UpdateFooterAddressDto> updateFooterAddressValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createFooterAddressValidator = createFooterAddressValidator;
            _updateFooterAddressValidator = updateFooterAddressValidator;
        }

        public async Task<ResponseDto<object>> CreateFooterAddressAsync(CreateFooterAddressDto dto)
        {
            try
            {
                var validate = await _createFooterAddressValidator.ValidateAsync(dto);
                if (validate.IsValid is false)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.ValidationError,
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage))
                    };
                }
                var mappedFooterAddress = _mapper.Map<FooterAddress>(dto);
                await _repository.CreateAsync(mappedFooterAddress);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = mappedFooterAddress,
                    Message = "Alt bilgi başarılı bir şekilde oluşturuldu."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<object>
                {
                    Success = false,
                    Message = "Bir hata meydana geldi.",
                    ErrorCodes = ErrorCodes.Exception
                };
            }
        }

        public async Task<ResponseDto<object>> DeleteFooterAddressAsync(int id)
        {
            try
            {
                var FooterAddressDb = await _repository.GetByIdAsync(id);
                if (FooterAddressDb is null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Bir alt bilgi bulunamadı.",
                        Data = null
                    };
                }
                await _repository.DeleteAsync(FooterAddressDb);
                return new ResponseDto<object>
                {
                    Success = true,
                    Message = "Alt bilgi başarılı bir şekilde silindi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Success = false,
                    Message = "Bir hata meydana geldi.",
                    ErrorCodes = ErrorCodes.ValidationError
                };
            }
        }

        public Task<ResponseDto<List<ResultFooterAddressDto>>> GetAllFooterAddressAsync()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<ResponseDto<GetByIdFooterAddressDto>> GetByIdFooterAddressAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<object>> UpdateFooterAddressAsync(UpdateFooterAddressDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
