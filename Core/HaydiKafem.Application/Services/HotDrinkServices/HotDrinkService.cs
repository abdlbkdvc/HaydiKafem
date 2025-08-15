using AutoMapper;
using FluentValidation;
using HaydiKafem.Application.Dtos.HotDrinkDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Interfaces;
using HaydiKafem.Domain.Entities;

namespace HaydiKafem.Application.Services.HotDrinkServices
{
    public class HotDrinkService : IHotDrinkService
    {
        private readonly IRepository<HotDrink> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateHotDrinkDto> _createHotDrinkValidator;
        private readonly IValidator<UpdateHotDrinkDto> _updateHotDrinkValidator;

        public HotDrinkService(IRepository<HotDrink> repository, IMapper mapper, IValidator<CreateHotDrinkDto> createHotDrinkValidator, IValidator<UpdateHotDrinkDto> updateHotDrinkValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createHotDrinkValidator = createHotDrinkValidator;
            _updateHotDrinkValidator = updateHotDrinkValidator;
        }

        public async Task<ResponseDto<object>> CreateHotDrinkAsync(CreateHotDrinkDto dto)
        {
            try
            {
                var validate = await _createHotDrinkValidator.ValidateAsync(dto);
                if (validate.IsValid is false)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.ValidationError,
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage))
                    };
                }
                var mappedHotDrink = _mapper.Map<HotDrink>(dto);
                await _repository.CreateAsync(mappedHotDrink);
                return new ResponseDto<object>
                {
                    Data = mappedHotDrink,
                    Message = "Sıcak İçecekler başarılı bir şekilde eklendi.",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Success = false,
                    Message = "Bir hata meydana geldi.",
                    ErrorCodes = ErrorCodes.Exception,
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<object>> DeleteHotDrinkAsync(int id)
        {
            try
            {
                var HotDrink = await _repository.GetByIdAsync(id);
                if (HotDrink is null)
                {
                    return new ResponseDto<object>
                    {
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir sıcak içecek bulunamadı.",
                        Success = false
                    };
                }
                await _repository.DeleteAsync(HotDrink);
                return new ResponseDto<object>
                {
                    Data = null,
                    Message = "Sıcak içecek başarılı bir şekilde silindi.",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Success = false,
                    Message = "Bir hata meydana geldi.",
                    ErrorCodes = ErrorCodes.Exception,
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<List<ResultHotDrinkDto>>> GetAllHotDrinkAsync()
        {
            var HotDrinks = await _repository.GetAllAsync();
            if (HotDrinks.Count is 0)
            {
                return new ResponseDto<List<ResultHotDrinkDto>>
                {
                    Success = false,
                    Data = null,
                    ErrorCodes = ErrorCodes.NotFound,
                    Message = "Bir sıçak içecek bulunamadı."
                };
            }
            var mappedHotDrinks = _mapper.Map<List<ResultHotDrinkDto>>(HotDrinks);
            return new ResponseDto<List<ResultHotDrinkDto>>
            {
                Data = mappedHotDrinks,
                Message = "Sıçak içecekler başarılı bir şekilde getirildi.",
                Success = true
            };
        }

        public async Task<ResponseDto<GetByIdHotDrinkDto>> GetByIdHotDrinkAsync(int id)
        {
            try
            {
                var HotDrink = await _repository.GetByIdAsync(id);
                if (HotDrink is null)
                {
                    return new ResponseDto<GetByIdHotDrinkDto>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir sıcak içecek bulunamadı."
                    };
                }
                var mappedHotDrink = _mapper.Map<GetByIdHotDrinkDto>(HotDrink);
                return new ResponseDto<GetByIdHotDrinkDto>
                {
                    Message = "Sıcak içecek başarılı bir şekilde getirildi.",
                    Data = mappedHotDrink,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<GetByIdHotDrinkDto>
                {
                    Success = false,
                    Data = null,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata meydana geldi."
                };

            }
        }

        public async Task<ResponseDto<object>> UpdateHotDrinkAsync(UpdateHotDrinkDto dto)
        {
            try
            {
                var validate = await _updateHotDrinkValidator.ValidateAsync(dto);
                if(validate.IsValid is false)
                {
                    return new ResponseDto<object>
                    {
                        ErrorCodes = ErrorCodes.ValidationError,
                        Success = false,
                        Message = string.Join(",",validate.Errors.Select(x=>x.ErrorMessage))
                    };
                }
                var HotDrink = await _repository.GetByIdAsync(dto.HotDrinkId);
                if (HotDrink is null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir sıcak içecek bulunamadı."
                    };
                }
                var mappedHotDrink = _mapper.Map(dto, HotDrink);
                await _repository.UpdateAsync(mappedHotDrink);
                return new ResponseDto<object>
                {
                    Data = mappedHotDrink,
                    Message = "Sıcak içecek başarılı bir şekilde güncellendi.",
                    Success = true
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<object>
                {
                    Success = false,
                    Data = null,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata meydana geldi"
                };
            }
        }
    }
}
