using AutoMapper;
using FluentValidation;
using HaydiKafem.Application.Dtos.AboutDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Interfaces;
using HaydiKafem.Domain.Entities;

namespace HaydiKafem.Application.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateAboutDto> _createAboutValidator;
        private readonly IValidator<UpdateAboutDto> _updateAboutValidator;

        public AboutService(IRepository<About> repository, IMapper mapper, IValidator<CreateAboutDto> createAboutValidator, IValidator<UpdateAboutDto> updateAboutValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createAboutValidator = createAboutValidator;
            _updateAboutValidator = updateAboutValidator;
        }

        public async Task<ResponseDto<object>> CreateAboutAsync(CreateAboutDto dto)
        {
            try
            {
                var validate = await _createAboutValidator.ValidateAsync(dto);
                if (validate.IsValid is false)
                {
                    return new ResponseDto<object>
                    {
                        ErrorCodes = ErrorCodes.ValidationError,
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage)),
                        Success = false
                    };
                }
                var mappedValues = _mapper.Map<About>(dto);
                await _repository.CreateAsync(mappedValues);
                return new ResponseDto<object>
                {
                    Data = mappedValues,
                    Message = "Hakkımızda bölümü başarılı bir şekilde oluşturuldu.",
                    Success = true
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<object>
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata meydana geldi."
                };
            }
        }

        public async Task<ResponseDto<object>> DeleteAboutAsync(int id)
        {

            try
            {
                var aboutDatabase = await _repository.GetByIdAsync(id);
                if (aboutDatabase is null)
                {
                    return new ResponseDto<object>
                    {
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir hakkımda alanı bulunamadı.",
                        Success = false
                    };
                }
                await _repository.DeleteAsync(aboutDatabase);
                return new ResponseDto<object>
                {
                    Success = true,
                    Message = "Hakkımda alanı başarılı bir şekilde silindi."
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

        public async Task<ResponseDto<List<ResultAboutDto>>> GetAllAboutAsync()
        {
            try
            {
                var aboutsDatabase = await _repository.GetAllAsync();
                if (aboutsDatabase.Count == 0)
                {
                    return new ResponseDto<List<ResultAboutDto>>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir hakkımda alanı bulunamadı."
                    };
                }
                var mappedAbout = _mapper.Map<List<ResultAboutDto>>(aboutsDatabase);
                return new ResponseDto<List<ResultAboutDto>>
                {
                    Success = true,
                    Data = mappedAbout,
                    Message = "Hakkımda alanı başarılı bir şekilde getirildi."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<ResultAboutDto>>
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata meydana geldi."
                };
            }
        }

        public async Task<ResponseDto<GetByIdAboutDto>> GetByIdAboutAsync(int id)
        {
            try
            {
                var aboutDb = await _repository.GetByIdAsync(id);
                if (aboutDb is null)
                {
                    return new ResponseDto<GetByIdAboutDto>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir hakkımda alanı bulunamadı."
                    };
                }
                var mappedAbout = _mapper.Map<GetByIdAboutDto>(aboutDb);
                return new ResponseDto<GetByIdAboutDto>
                {
                    Success = true,
                    Data = mappedAbout,
                    Message = "Hakkımda alanı başarılı bir şekilde getirildi."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<GetByIdAboutDto>
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata meydana geldi."
                };
            }
        }

        public async Task<ResponseDto<object>> UpdateAboutAsync(UpdateAboutDto dto)
        {
            try
            {
                var validate = await _updateAboutValidator.ValidateAsync(dto);
                if (validate.IsValid is false)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.ValidationError,
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage))
                    };
                }
                var aboutDb = await _repository.GetByIdAsync(dto.AboutId);
                if (aboutDb is null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir hakkımda alanı bulunamadı."
                    };
                }
                var mappedAbout = _mapper.Map(dto, aboutDb);
                await _repository.UpdateAsync(mappedAbout);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = mappedAbout,
                    Message = "Hakkımda alanı başarılı bir şekilde güncellendi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Data = null,
                    ErrorCodes = ErrorCodes.Exception,
                    Success = false,
                    Message = "Bir hata meydana geldi."
                };
            }
        }
    }
}
