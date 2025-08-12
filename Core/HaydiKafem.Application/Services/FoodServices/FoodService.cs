using AutoMapper;
using HaydiKafem.Application.Dtos.Food;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Interfaces;
using HaydiKafem.Domain.Entities;

namespace HaydiKafem.Application.Services.FoodServices
{
    public class FoodService : IFoodService
    {
        private readonly IRepository<Food> _repository;
        private readonly IMapper _mapper;

        public FoodService(IRepository<Food> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<object>> CreateFoodAsync(CreateFoodDto dto)
        {
            try
            {
                var mappedFood = _mapper.Map<Food>(dto);
                await _repository.CreateAsync(mappedFood);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = mappedFood,
                    Message = "Yemek başarılı bir şekilde oluşturuldu."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<object>
                {
                    Message = "Bir hata bulundu.",
                    ErrorCodes = ErrorCodes.Exception,
                    Success = false
                };
            }
        }

        public async Task<ResponseDto<object>> DeleteFoodAsync(int id)
        {
            try
            {
                var food = await _repository.GetByIdAsync(id);
                if (food == null)
                {
                    return new ResponseDto<object>
                    {
                        Message = "Bir yemek bulunamadı.",
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Success = false
                    };
                }
                await _repository.DeleteAsync(food);
                return new ResponseDto<object>
                {
                    Success = true,
                    Message = "Yemek başarılı bir şekilde silindi.",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Data = null,
                    Message = "Bir hata oluştu.",
                    ErrorCodes = ErrorCodes.Exception,
                    Success = false
                };

            }
        }

        public async Task<ResponseDto<List<ResultFoodDto>>> GetAllFoodsAsync()
        {
            try
            {
                var foods = await _repository.GetAllAsync();
                if (foods.Count == 0)
                {
                    return new ResponseDto<List<ResultFoodDto>>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir yemek bulunamadı."
                    };
                }
                var mappedFoods = _mapper.Map<List<ResultFoodDto>>(foods);
                return new ResponseDto<List<ResultFoodDto>>
                {
                    Success = true,
                    Data = mappedFoods,
                    Message = "Yemekler başarılı bir şekilde getirildi."
                };

            }
            catch (Exception ex)
            {
                return new ResponseDto<List<ResultFoodDto>>
                {
                    Success = false,
                    Data = null,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata oluştu."
                };

            }
        }

        public async Task<ResponseDto<GetByIdFoodDto>> GetByIdFoodAsync(int id)
        {
            try
            {
                var food = await _repository.GetByIdAsync(id);
                if (food == null)
                {
                    return new ResponseDto<GetByIdFoodDto>
                    {
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir yemek bulunamadı.",
                        Success = false,
                    };
                }
                var mappedFood = _mapper.Map<GetByIdFoodDto>(food);
                return new ResponseDto<GetByIdFoodDto>
                {
                    Success = true,
                    Data = mappedFood,
                    Message = "Yemek başarılı bir şekilde getirildi."
                };

            }
            catch (Exception ex)
            {

                return new ResponseDto<GetByIdFoodDto>
                {
                    Success = false,
                    Message = "Bir hata oluştu.",
                    Data = null,
                    ErrorCodes = ErrorCodes.Exception
                };
            }
        }

        public async Task<ResponseDto<object>> UpdateFoodAsync(UpdateFoodDto dto)
        {
            try
            {
                var foodDatabase = await _repository.GetByIdAsync(dto.FoodId);
                if (foodDatabase == null)
                {
                    return new ResponseDto<object>
                    {
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir yemek bulunamadı.",
                        Success = false
                    };
                }
                var mappedFood = _mapper.Map(dto, foodDatabase);
                await _repository.UpdateAsync(mappedFood);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = mappedFood,
                    Message = "Yemek başarılı bir şekilde güncellendi."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<object>
                {
                    Data = null,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata oluştu.",
                    Success = false
                };
            }
        }
    }
}
