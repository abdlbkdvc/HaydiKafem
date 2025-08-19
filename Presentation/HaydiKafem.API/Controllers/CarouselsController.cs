using HaydiKafem.Application.Dtos.CarouselDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Services.CarouselServices;
using Microsoft.AspNetCore.Mvc;

namespace HaydiKafem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarouselsController : ControllerBase
    {
        private readonly ICarouselService _carouselService;

        public CarouselsController(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCarouselAsync()
        {
            var result = await _carouselService.GetAllCarouselAsync();
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
        public async Task<IActionResult> CreateCarouselAsync(CreateCarouselDto dto)
        {
            var result = await _carouselService.CreateCarouselAsync(dto);
            if (result.Success is false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCarouselAsync(UpdateCarouselDto dto)
        {
            var result = await _carouselService.UpdateCarouselAsync(dto);
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
        [HttpGet("GetByIdCarousel")]
        public async Task<IActionResult> GetByIdCarousel(int id)
        {
            var result = await _carouselService.GetByIdCarouselAsync(id);
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
        public async Task<IActionResult> DeleteCarouselAsync(int id)
        {
            var result = await _carouselService.DeleteCarouselAsync(id);
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
    }
}
