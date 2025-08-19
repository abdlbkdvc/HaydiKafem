using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Dtos.WeekDiscountDtos;
using HaydiKafem.Application.Services.WeekDiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace HaydiKafem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekDiscountsController : ControllerBase
    {
        private readonly IWeekDiscountService _weekDiscountService;

        public WeekDiscountsController(IWeekDiscountService weekDiscountService)
        {
            _weekDiscountService = weekDiscountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWeekDiscountAsync()
        {
            var result = await _weekDiscountService.GetAllWeekDiscountAsync();
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
        public async Task<IActionResult> CreateWeekDiscountAsync(CreateWeekDiscountDto dto)
        {
            var result = await _weekDiscountService.CreateWeekDiscountAsync(dto);
            if (result.Success is false)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWeekDiscountAsync(UpdateWeekDiscountDto dto)
        {
            var result = await _weekDiscountService.UpdateWeekDiscountAsync(dto);
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
        public async Task<IActionResult> DeleteWeekDiscountAsync(int id)
        {
            var result = await _weekDiscountService.DeleteWeekDiscountAsync(id);
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
        [HttpGet("GetByIdWeekDiscount")]
        public async Task<IActionResult> GetByIdWeekDiscount(int id)
        {
            var result = await _weekDiscountService.GetByIdWeekDiscountAsync(id);
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
