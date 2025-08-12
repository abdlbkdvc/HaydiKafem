using HaydiKafem.Application.Dtos.Food;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Services.FoodServices;
using Microsoft.AspNetCore.Mvc;

namespace HaydiKafem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFoodAsync()
        {
            var result = await _foodService.GetAllFoodsAsync();
            if (result.Success is false)
            {
                if (result.ErrorCodes == ErrorCodes.NotFound)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFoodAsync(int id)
        {
            var result = await _foodService.GetByIdFoodAsync(id);
            if (result.Success is false)
            {
                if (result.ErrorCodes == ErrorCodes.NotFound)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFoodAsync(CreateFoodDto dto)
        {
            var result = await _foodService.CreateFoodAsync(dto);
            if (result.Success is false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFoodAsync(UpdateFoodDto dto)
        {
            var result = await _foodService.UpdateFoodAsync(dto);
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
        public async Task<IActionResult> DeleteFoodAsync(int id)
        {
            var result = await _foodService.DeleteFoodAsync(id);
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
