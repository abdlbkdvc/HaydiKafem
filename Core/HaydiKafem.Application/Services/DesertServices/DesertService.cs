using AutoMapper;
using HaydiKafem.Application.Dtos.DesertDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Interfaces;
using HaydiKafem.Domain.Entities;

namespace HaydiKafem.Application.Services.DesertServices
{
    public class DesertService : IDesertService
    {
        private readonly IRepository<Desert> _repository;
        private readonly IMapper _mapper;

        public DesertService(IRepository<Desert> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<object>> CreateDesertAsync(CreateDesertDto dto)
        {
            try
            {
                var mappedDesert = _mapper.Map<Desert>(dto);
                await _repository.CreateAsync(mappedDesert);
                return new ResponseDto<object>
                {
                    Data = mappedDesert,
                    Success = true,
                    Message = "Tatlı başarılı bir şekilde menüye eklendi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<object>
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata oluştu.",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<object>> DeleteDesertAsync(int id)
        {
            try
            {
                var desert = await _repository.GetByIdAsync(id);
                if (desert == null)
                {
                    return new ResponseDto<object>
                    {
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir tatlı bulunamadı.",
                        Success = false
                    };
                }
                await _repository.DeleteAsync(desert);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = null,
                    Message = "Tatlı menüden başarılı bir şekilde silindi."
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

        public async Task<ResponseDto<List<ResultDesertDto>>> GetAllDesertAsync()
        {
            try
            {
                var deserts = await _repository.GetAllAsync();
                if (deserts.Count == 0)
                {
                    return new ResponseDto<List<ResultDesertDto>>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir tatlı bulunamadı."
                    };
                }
                var mappedDeserts = _mapper.Map<List<ResultDesertDto>>(deserts);
                return new ResponseDto<List<ResultDesertDto>>
                {
                    Success = true,
                    Data = mappedDeserts,
                    Message = "Tatlılar başarılı bir şekilde getirildi."
                };

            }
            catch (Exception ex)
            {
                return new ResponseDto<List<ResultDesertDto>>
                {
                    Success = false,
                    Data = null,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata oluştu."
                };
            }
        }

        public async Task<ResponseDto<GetByIdDesertDto>> GetByIdDesertAsync(int id)
        {
            try
            {
                var desert = await _repository.GetByIdAsync(id);
                if (desert is null)
                {
                    return new ResponseDto<GetByIdDesertDto>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir tatlı bulunamadı."
                    };
                }
                var mappedDesert = _mapper.Map<GetByIdDesertDto>(desert);
                return new ResponseDto<GetByIdDesertDto>
                {
                    Data = mappedDesert,
                    Success = true,
                    Message = "Tatlı başarılı bir şekilde getirildi."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<GetByIdDesertDto>
                {
                    Success = false,
                    Message = "Bir hata oluştu.",
                    Data = null,
                    ErrorCodes = ErrorCodes.Exception
                };
            }

        }

        public async Task<ResponseDto<object>> UpdateDesertAsync(UpdateDesertDto dto)
        {
            try
            {
                var desert = await _repository.GetByIdAsync(dto.DesertId);
                if (desert is null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir tatlı bulunamadı."
                    };
                }
                var mappedDesert = _mapper.Map(dto, desert);
                await _repository.UpdateAsync(mappedDesert);
                return new ResponseDto<object>
                {
                    Data = mappedDesert,
                    Success = true,
                    Message = "Tatlı menüsü başarılı bir şekilde güncellendi."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<object>
                {
                    Success = false,
                    Data = null,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata oluştu."
                };
            }
        }
    }
}
