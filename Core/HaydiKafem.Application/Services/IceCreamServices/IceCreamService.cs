using AutoMapper;
using FluentValidation;
using HaydiKafem.Application.Dtos.IceCreamDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Interfaces;
using HaydiKafem.Domain.Entities;

namespace HaydiKafem.Application.Services.IceCreamServices
{
    public class IceCreamService : IIceCreamService
    {
        private readonly IRepository<IceCream> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateIceCreamDto> _createIceCreamValidator;
        private readonly IValidator<UpdateIceCreamDto> _updateIceCreamValidator;

        public IceCreamService(IRepository<IceCream> repository, IMapper mapper, IValidator<CreateIceCreamDto> createIceCreamValidator, IValidator<UpdateIceCreamDto> updateIceCreamValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createIceCreamValidator = createIceCreamValidator;
            _updateIceCreamValidator = updateIceCreamValidator;
        }

        public async Task<ResponseDto<object>> CreateIceCreamAsync(CreateIceCreamDto dto)
        {
            try
            {
                var validate = await _createIceCreamValidator.ValidateAsync(dto);
                if (validate.IsValid is false)
                {
                    return new ResponseDto<object>
                    {
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage)),
                        Success = false,
                        ErrorCodes = ErrorCodes.ValidationError
                    };
                }
                var mappedIceCream = _mapper.Map<IceCream>(dto);
                await _repository.CreateAsync(mappedIceCream);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = mappedIceCream,
                    Message = "Dondurma başarılı bir şekilde oluşturuldu."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<object>
                {
                    Success = false,
                    Message = "Bir hata oluştu.",
                    ErrorCodes = ErrorCodes.Exception
                };
            }
        }

        public async Task<ResponseDto<object>> DeleteIceCreamAsync(int id)
        {
            try
            {
                var IceCream = await _repository.GetByIdAsync(id);
                if (IceCream == null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir dondurma bulunamadı."
                    };
                }
                await _repository.DeleteAsync(IceCream);
                return new ResponseDto<object>
                {
                    Success = true,
                    Message = "Dondurma başarılı bir şekilde silindi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.NotFound,
                    Data = null,
                    Message = "Bir hata oluştu."
                };
            }
        }

        public async Task<ResponseDto<List<ResultIceCreamDto>>> GetAllIceCreamAsync()
        {
            try
            {
                var IceCreams = await _repository.GetAllAsync();
                if (IceCreams.Count is 0)
                {
                    return new ResponseDto<List<ResultIceCreamDto>>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir dondurma bulunamadı."
                    };
                }
                var mappedIceCreams = _mapper.Map<List<ResultIceCreamDto>>(IceCreams);
                return new ResponseDto<List<ResultIceCreamDto>>
                {
                    Success = true,
                    Data = mappedIceCreams,
                    Message = "Dondurmalar başarılı bir şekilde getirildi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<ResultIceCreamDto>>
                {
                    Success = false,
                    Data = null,
                    Message = "Bir hata oluştu.",
                    ErrorCodes = ErrorCodes.Exception
                };

            }
        }

        public async Task<ResponseDto<GetByIdIceCreamDto>> GetByIdIceCreamAsync(int id)
        {
            try
            {
                var IceCream = await _repository.GetByIdAsync(id);
                if (IceCream is null)
                {
                    return new ResponseDto<GetByIdIceCreamDto>
                    {
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir dondurma bulunamadı.",
                        Success = false
                    };
                }
                var mappedIceCream = _mapper.Map<GetByIdIceCreamDto>(IceCream);
                return new ResponseDto<GetByIdIceCreamDto>
                {
                    Data = mappedIceCream,
                    Success = true,
                    Message = "Dondurma başarılı bir şekilde getirildi."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<GetByIdIceCreamDto>
                {
                    Data = null,
                    Message = "Bir hata oluştu.",
                    Success = false,
                    ErrorCodes = ErrorCodes.Exception
                };
            }
        }

        public async Task<ResponseDto<object>> UpdateIceCreamAsync(UpdateIceCreamDto dto)
        {
            try
            {
                var validate = await _updateIceCreamValidator.ValidateAsync(dto);
                if (validate.IsValid is false)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.ValidationError,
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage))
                    };
                }
                var IceCream = await _repository.GetByIdAsync(dto.IceCreamId);
                if (IceCream is null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir dondurma bulunamadı."
                    };
                }
                var mappedIceCream = _mapper.Map(dto, IceCream);
                await _repository.UpdateAsync(mappedIceCream);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = mappedIceCream,
                    Message = "Dondurma bölümü başarılı bir şekilde güncellendi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Data = null,
                    Message = "Bir hata oluştu.",
                    Success = false,
                    ErrorCodes = ErrorCodes.Exception
                };

            }
        }
    }
}
