using HaydiKafem.Application.Dtos.ColdDrinkDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Services.ColdDrinkServices;
using Microsoft.AspNetCore.Mvc;

namespace HaydiKafem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColdDrinksController : ControllerBase
    {
        private readonly IColdDrinkService _coldDrinkService;

        public ColdDrinksController(IColdDrinkService coldDrinkService)
        {
            _coldDrinkService = coldDrinkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllColdDrinkAsync()
        {
            var result = await _coldDrinkService.GetAllColdDrinkAsync();
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdColdDrinkAsync(int id)
        {
            var result = await _coldDrinkService.GetByIdColdDrinkAsync(id);
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
        public async Task<IActionResult> CreateColdDrinkAsync(CreateColdDrinkDto dto)
        {
            var result = await _coldDrinkService.CreateColdDrinkAsync(dto);
            if (result.Success is false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateColdDrinkAsync(UpdateColdDrinkDto dto)
        {
            var result = await _coldDrinkService.UpdateColdDrinkAsync(dto);
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
        public async Task<IActionResult> DeleteColdDrinkAsync(int id)
        {
            var result = await _coldDrinkService.DeleteColdDrinkAsync(id);
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
