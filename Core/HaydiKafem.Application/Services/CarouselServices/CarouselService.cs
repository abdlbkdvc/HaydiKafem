using AutoMapper;
using FluentValidation;
using HaydiKafem.Application.Dtos.CarouselDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Interfaces;
using HaydiKafem.Domain.Entities;

namespace HaydiKafem.Application.Services.CarouselServices
{
    public class CarouselService : ICarouselService
    {
        private readonly IRepository<Carousel> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCarouselDto> _createCarouselValidator;
        private readonly IValidator<UpdateCarouselDto> _updateCarouselValidator;

        public CarouselService(IRepository<Carousel> repository, IMapper mapper, IValidator<CreateCarouselDto> createCarouselValidator, IValidator<UpdateCarouselDto> updateCarouselValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createCarouselValidator = createCarouselValidator;
            _updateCarouselValidator = updateCarouselValidator;
        }

        public async Task<ResponseDto<object>> CreateCarouselAsync(CreateCarouselDto dto)
        {
            try
            {
                var validate = await _createCarouselValidator.ValidateAsync(dto);
                if (validate.IsValid is false)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.ValidationError,
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage))
                    };
                }
                var mappedAbout = _mapper.Map<Carousel>(dto);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = mappedAbout,
                    Message = "Dönen Sayfa başarılı bir şekilde oluşturuldu."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Data = null,
                    Message = "Bir hata meydana geldi.",
                    Success = false,
                    ErrorCodes = ErrorCodes.Exception
                };
            }
        }

        public async Task<ResponseDto<object>> DeleteCarouselAsync(int id)
        {
            try
            {
                var carouselDb = await _repository.GetByIdAsync(id);
                if (carouselDb is null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir dönen sayfa alanı bulunamadı."
                    };
                }
                await _repository.DeleteAsync(carouselDb);
                return new ResponseDto<object>
                {
                    Success = true,
                    Message = "Dönen sayfa alanı başarılı bir şekilde silindi."
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

        public async Task<ResponseDto<List<ResultCarouselDto>>> GetAllCarouselAsync()
        {
            try
            {
                var aboutsDb = await _repository.GetAllAsync();
                if (aboutsDb.Count == 0)
                {
                    return new ResponseDto<List<ResultCarouselDto>>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir dönen sayfa alanı bulunamadı."
                    };
                }
                var mappedAbouts = _mapper.Map<List<ResultCarouselDto>>(aboutsDb);
                return new ResponseDto<List<ResultCarouselDto>>
                {
                    Success = true,
                    Data = mappedAbouts,
                    Message = "Dönen sayfa başarılı bir şekilde getirildi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<ResultCarouselDto>>
                {
                    Success = false,
                    Message = "Bir hata meydana geldi.",
                    Data = null,
                    ErrorCodes = ErrorCodes.Exception
                };
            }
        }

        public async Task<ResponseDto<GetByIdCarouselDto>> GetByIdCarouselAsync(int id)
        {
            try
            {
                var aboutDb = await _repository.GetByIdAsync(id);
                if (aboutDb == null)
                {
                    return new ResponseDto<GetByIdCarouselDto>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir dönen sayfa bulunamadı."
                    };
                }
                var mappedAbout = _mapper.Map<GetByIdCarouselDto>(aboutDb);
                return new ResponseDto<GetByIdCarouselDto>
                {
                    Success = true,
                    Data = mappedAbout,
                    Message = "Dönen sayfa alanı başarılı bir şekilde getirildi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<GetByIdCarouselDto>
                {
                    Message = "Bir hata meydana geldi.",
                    Success = false,
                    ErrorCodes = ErrorCodes.Exception
                };

            }
        }

        public async Task<ResponseDto<object>> UpdateCarouselAsync(UpdateCarouselDto dto)
        {
            try
            {
                var validate = await _updateCarouselValidator.ValidateAsync(dto);
                if (validate.IsValid == false)
                {
                    return new ResponseDto<object>
                    {
                        ErrorCodes = ErrorCodes.ValidationError,
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage)),
                        Success = false
                    };
                }
                var carouselDb = await _repository.GetByIdAsync(dto.CarouselId);
                if (carouselDb == null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir dönen sayfa bulunamadı."
                    };
                }
                var mappedCarousel = _mapper.Map(dto, carouselDb);
                await _repository.UpdateAsync(mappedCarousel);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = mappedCarousel,
                    Message = "Dönen sayfa alanı başarılı bir şekilde güncellendi."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<object>
                {
                    Success = false,
                    Message = "Bir hata meydana geldi.",
                    Data = null,
                    ErrorCodes = ErrorCodes.Exception
                };
            }
        }
    }
}
