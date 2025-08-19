using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Dtos.TestimonialDtos;
using HaydiKafem.Application.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace HaydiKafem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialServices _testimonialServices;

        public TestimonialsController(ITestimonialServices testimonialServices)
        {
            _testimonialServices = testimonialServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTestimonialsAsync()
        {
            var result = await _testimonialServices.GetAllTestimonialAsync();
            if (result.Success is false)
            {
                if (result.ErrorCodes is ErrorCodes.NotFound)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonialAsync(CreateTestimonialDto dto)
        {
            var result = await _testimonialServices.CreateTestimonialAsync(dto);
            if (result.Success is false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonialAsync(UpdateTestimonialDto dto)
        {
            var result = await _testimonialServices.UpdateTestimonialAsync(dto);
            if (result.Success is false)
            {
                if (result.ErrorCodes is ErrorCodes.NotFound)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTestimonialAsync(int id)
        {
            var result = await _testimonialServices.DeleteTestimonialAsync(id);
            if(result.Success is false)
            {
                if(result.ErrorCodes is ErrorCodes.NotFound)
                {
                    return Ok(result);                         
                }
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
