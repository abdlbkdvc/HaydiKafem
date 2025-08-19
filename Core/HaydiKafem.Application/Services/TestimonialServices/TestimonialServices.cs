using AutoMapper;
using FluentValidation;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Dtos.TestimonialDtos;
using HaydiKafem.Application.Interfaces;
using HaydiKafem.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HaydiKafem.Application.Services.TestimonialServices
{

    public class TestimonialServices : ITestimonialServices
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTestimonialDto> _createTestimonialValidator;
        private readonly IValidator<UpdateTestimonialDto> _updateTestimonialValidator;

        public TestimonialServices(IRepository<Testimonial> repository, IMapper mapper, IValidator<CreateTestimonialDto> createTestimonialValidator, IValidator<UpdateTestimonialDto> updateTestimonialValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createTestimonialValidator = createTestimonialValidator;
            _updateTestimonialValidator = updateTestimonialValidator;
        }

        public async Task<ResponseDto<object>> CreateTestimonialAsync(CreateTestimonialDto dto)
        {
            try
            {
                var validate = await _createTestimonialValidator.ValidateAsync(dto);
                if (validate.IsValid is false)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.ValidationError,
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage))
                    };
                }
                var mappedTestimonial = _mapper.Map<Testimonial>(dto);
                await _repository.CreateAsync(mappedTestimonial);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = mappedTestimonial,
                    Message = "Müşteri yorumları başarılı bir şekilde eklendi."
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

        public async Task<ResponseDto<object>> DeleteTestimonialAsync(int id)
        {
            try
            {
                var testimonialDb = await _repository.GetByIdAsync(id);
                if (testimonialDb is null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.NotFound,
                        Data = null,
                        Message = "Herhangi bir müşteri yorumu bulunamadı."
                    };
                }
                await _repository.DeleteAsync(testimonialDb);
                return new ResponseDto<object>
                {
                    Success = true,
                    Message = "Müşteri yorumu başarılı bir şekilde silindi.",
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

        public async Task<ResponseDto<List<ResultTestimonialDto>>> GetAllTestimonialAsync()
        {
            try
            {
                var testimonialsDb = await _repository.GetAllAsync();
                if (testimonialsDb.Count == 0)
                {
                    return new ResponseDto<List<ResultTestimonialDto>>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Bir müşteri yorumları bulunamadı."
                    };
                }
                var mappedTestimonials = _mapper.Map<List<ResultTestimonialDto>>(testimonialsDb);
                return new ResponseDto<List<ResultTestimonialDto>>
                {
                    Success = true,
                    Data = mappedTestimonials,
                    Message = "Müşteri yorumları başarılı bir şekilde getirildi."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<List<ResultTestimonialDto>>
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.Exception,
                    Message = "Bir hata meydana geldi."
                };
            }
        }

        public async Task<ResponseDto<GetByIdTestimonialDto>> GetByIdTestimonialAsync(int id)
        {
            try
            {
                var testimonialDb = await _repository.GetByIdAsync(id);
                if (testimonialDb is null)
                {
                    return new ResponseDto<GetByIdTestimonialDto>
                    {
                        Success = false,
                        Data = null,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Herhangi bir müşteri yorumu belirtilen Id'de bulunamadı."
                    };
                }
                var mappedTestimonial = _mapper.Map<GetByIdTestimonialDto>(testimonialDb);
                return new ResponseDto<GetByIdTestimonialDto>
                {
                    Success = true,
                    Data = mappedTestimonial,
                    Message = "Müşteri yorumu başarılı bir şekilde getirildi."
                };
            }
            catch (Exception ex)
            {

                return new ResponseDto<GetByIdTestimonialDto>
                {
                    Success = false,
                    Message = "Bir hata meydana geldi.",
                    ErrorCodes = ErrorCodes.Exception,

                };
            }
        }

        public async Task<ResponseDto<object>> UpdateTestimonialAsync(UpdateTestimonialDto dto)
        {
            try
            {
                var validate = await _updateTestimonialValidator.ValidateAsync(dto);
                if (validate.IsValid is false)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.ValidationError,
                        Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage))
                    };
                }
                var testimonialId = await _repository.GetByIdAsync(dto.TestimonialId);
                if (testimonialId is null)
                {
                    return new ResponseDto<object>
                    {
                        Success = false,
                        ErrorCodes = ErrorCodes.NotFound,
                        Message = "Müşteri yorumu bulunamadı."
                    };
                }

                var mappedTestimonial = _mapper.Map(dto, testimonialId);
                await _repository.UpdateAsync(mappedTestimonial);
                return new ResponseDto<object>
                {
                    Success = true,
                    Data = mappedTestimonial,
                    Message = "Müşteri yorumları başarılı bir şekilde güncellendi."
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
