using AutoMapper;
using FluentValidation;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Dtos.WeekDiscountDtos;
using HaydiKafem.Application.Interfaces;
using HaydiKafem.Domain.Entities;

namespace HaydiKafem.Application.Services.WeekDiscountServices
{
    public class WeekDiscountService : IWeekDiscountService
    {
        private readonly IRepository<WeekDiscount> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateWeekDiscountDto> _createWeekDiscountValidator;
        private readonly IValidator<UpdateWeekDiscountDto> _updateWeekDiscountValidator;

        public WeekDiscountService(IRepository<WeekDiscount> repository)
        {
            _repository = repository;
        }

        public WeekDiscountService(IRepository<WeekDiscount> repository, IMapper mapper, IValidator<CreateWeekDiscountDto> createWeekDiscountValidator, IValidator<UpdateWeekDiscountDto> updateWeekDiscountValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createWeekDiscountValidator = createWeekDiscountValidator;
            _updateWeekDiscountValidator = updateWeekDiscountValidator;
        }

        public async Task<ResponseDto<object>> CreateWeekDiscountAsync(CreateWeekDiscountDto dto)
        {
            try
            {
                var validate = await _createWeekDiscountValidator.ValidateAsync(dto);
                if (validate.IsValid is false)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.ValidationError,
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage))
                    };
                }
                var mappedValues = _mapper.Map<WeekDiscount>(dto);
                await _repository.CreateAsync(mappedValues);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = mappedValues,
                    Message = "Haftalık indirim başarılı bir şekilde oluşturuldu."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Success = false,
                    Message = "Bir hata meydana geldi.",
                    ErrorCodes = ErrorCodes.Exception,
                };
            }
        }

        public async Task<ResponseDto<object>> DeleteWeekDiscountAsync(int id)
        {
            try
            {
                var weekDiscountDb = await _repository.GetByIdAsync(id);
                if (weekDiscountDb is null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Bir hata meydana geldi."
                    };
                }
                await _repository.DeleteAsync(weekDiscountDb);
                return new ResponseDto<object>
                {
                    Success = true,
                    Message = "Haftalık indirim bölümü başarılı bir şekilde silindi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Success = false,
                    Data = null,
                    Message = "Bir hata meydana geldi.",
                    ErrorCodes = ErrorCodes.Exception
                };
            }
        }

        public async Task<ResponseDto<List<ResultWeekDiscountDto>>> GetAllWeekDiscountAsync()
        {
            try
            {
                var weekDiscountsDb = await _repository.GetAllAsync();
                if (weekDiscountsDb.Count == 0)
                {
                    return new ResponseDto<List<ResultWeekDiscountDto>>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir haftalık indirim alanı bulunamadı."
                    };
                }
                var mappedWeekDiscount = _mapper.Map<List<ResultWeekDiscountDto>>(weekDiscountsDb);
                return new ResponseDto<List<ResultWeekDiscountDto>>
                {
                    Success = true,
                    Message = "Haftalık indirim bölümü başarılı bir şekilde getirildi.",
                    Data = mappedWeekDiscount
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<ResultWeekDiscountDto>>
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata meydana geldi."
                };
            }
        }

        public async Task<ResponseDto<GetByIdWeekDiscountDto>> GetByIdWeekDiscountAsync(int id)
        {
            try
            {
                var WeekDiscountDb = await _repository.GetByIdAsync(id);
                if (WeekDiscountDb is null)
                {
                    return new ResponseDto<GetByIdWeekDiscountDto>
                    {
                        Message = "Herhangi bir haftalık indirim bulunamadı.",
                        Success = false,
                        ErrorCodes = ErrorCodes.NotFound
                    };
                }
                var mappedWeekDiscount = _mapper.Map<GetByIdWeekDiscountDto>(WeekDiscountDb);
                return new ResponseDto<GetByIdWeekDiscountDto>
                {
                    Success = true,
                    Message = "Haftalık indirimi başarılı bir şekilde getirildi.",
                    Data = mappedWeekDiscount
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<GetByIdWeekDiscountDto>
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata meydana geldi."
                };
            }
        }

        public async Task<ResponseDto<object>> UpdateWeekDiscountAsync(UpdateWeekDiscountDto dto)
        {
            try
            {
                var validate = await _updateWeekDiscountValidator.ValidateAsync(dto);
                if (validate.IsValid is false)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.ValidationError,
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage))
                    };
                }
                var WeekDiscountDb = await _repository.GetByIdAsync(dto.WeekDiscountId);
                if (WeekDiscountDb is null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir haftalık indirim alanı bulunamadı."
                    };
                }
                var mappedWeekDiscount = _mapper.Map(dto, WeekDiscountDb);
                await _repository.UpdateAsync(mappedWeekDiscount);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = mappedWeekDiscount,
                    Message = "Haftalık indirim alanı başarılı bir şekilde güncellendi."
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
    }
}
