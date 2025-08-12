using AutoMapper;
using HaydiKafem.Application.Dtos.ColdDrinkDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Interfaces;
using HaydiKafem.Domain.Entities;

namespace HaydiKafem.Application.Services.ColdDrinkServices
{
    public class ColdDrinkService : IColdDrinkService
    {
        private readonly IRepository<ColdDrink> _repository;
        private readonly IMapper _mapper;

        public ColdDrinkService(IRepository<ColdDrink> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<object>> CreateColdDrinkAsync(CreateColdDrinkDto dto)
        {
            try
            {
                var mappedColdDrink = _mapper.Map<ColdDrink>(dto);
                await _repository.CreateAsync(mappedColdDrink);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = mappedColdDrink,
                    Message = "Soğuk içecek bölümüne eklendi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Success = false,
                    Message = "Bir hata oluştu.",
                    Data = null,
                    ErrorCodes = ErrorCodes.Exception
                };
            }
        }

        public async Task<ResponseDto<object>> DeleteColdDrinkAsync(int id)
        {
            try
            {
                var ColdDrink = await _repository.GetByIdAsync(id);
                if (ColdDrink is null)
                {
                    return new ResponseDto<object>
                    {
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Success = false,
                        Message = "Bir hata oluştu."
                    };
                }
                await _repository.DeleteAsync(ColdDrink);
                return new ResponseDto<object>
                {
                    Success = true,
                    Message = "Soğuk içecek başarılı bir şekilde silindi.",
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Data = null,
                    Success = false,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata oluştu."
                };
            }
        }

        public async Task<ResponseDto<List<ResultColdDrinkDto>>> GetAllColdDrinkAsync()
        {
            try
            {
                var ColdDrinks = await _repository.GetAllAsync();
                if (ColdDrinks.Count == 0)
                {
                    return new ResponseDto<List<ResultColdDrinkDto>>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.NotFound,
                        Data = null,
                        Message = "Herhangi bir soğuk içecek bulunamadı."
                    };
                }
                var mappedColdDrinks = _mapper.Map<List<ResultColdDrinkDto>>(ColdDrinks);
                return new ResponseDto<List<ResultColdDrinkDto>>
                {
                    Data = mappedColdDrinks,
                    Message = "Soğuk içecekler başarılı bir şekilde getirildi.",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<ResultColdDrinkDto>>
                {
                    Success = false,
                    Data = null,
                    Message = "Bir hata meydana geldi.",
                    ErrorCodes = ErrorCodes.Exception
                };

            }
        }
        public async Task<ResponseDto<GetByIdColdDrinkDto>> GetByIdColdDrinkAsync(int id)
        {
            var ColdDrink = await _repository.GetByIdAsync(id);
            if (ColdDrink is null)
            {
                return new ResponseDto<GetByIdColdDrinkDto>
                {
                    Success = false,
                    Data = null,
                    ErrorCodes = ErrorCodes.NotFound,
                    Message = "Herhangi bir soğuk içecek belirtilen id değerinde bulunamadı."
                };
            }
            var mappedColdDrink = _mapper.Map<GetByIdColdDrinkDto>(ColdDrink);
            return new ResponseDto<GetByIdColdDrinkDto>
            {
                Success = true,
                Data = mappedColdDrink,
                Message = "Soğuk içecekler başarıyla getirildi."
            };
        }

        public async Task<ResponseDto<object>> UpdateColdDrinkAsync(UpdateColdDrinkDto dto)
        {
            try
            {
                var ColdDrink = await _repository.GetByIdAsync(dto.ColdDrinkId);
                if (ColdDrink is null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir soğuk içecek bulunamadı."
                    };
                }
                var mappedColdDrink = _mapper.Map(dto, ColdDrink);
                await _repository.UpdateAsync(mappedColdDrink);
                return new ResponseDto<object>
                {
                    Success = true,
                    Message = "Soğuk içecek başarıyla getirildi.",
                    Data = mappedColdDrink,
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.Exception,
                    Data = null,
                    Message = "Bir hata meydana geldi."
                };
            }
        }
    }
}
