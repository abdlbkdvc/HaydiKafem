using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Dtos.TestimonialDtos;

namespace HaydiKafem.Application.Services.TestimonialServices
{
    public interface ITestimonialServices
    {
        Task<ResponseDto<List<ResultTestimonialDto>>> GetAllTestimonialAsync();
        Task<ResponseDto<GetByIdTestimonialDto>> GetByIdTestimonialAsync(int id);
        Task<ResponseDto<object>> CreateTestimonialAsync(CreateTestimonialDto dto);
        Task<ResponseDto<object>> UpdateTestimonialAsync(UpdateTestimonialDto dto);
        Task<ResponseDto<object>> DeleteTestimonialAsync(int id);
    }
}
