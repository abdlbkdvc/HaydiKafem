using HaydiKafem.Application.Dtos.HotDrinkDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Services.HotDrinkServices;
using Microsoft.AspNetCore.Mvc;

namespace HaydiKafem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotDrinksController : ControllerBase
    {
        private readonly IHotDrinkService _hotDrinkService;

        public HotDrinksController(IHotDrinkService hotDrinkService)
        {
            _hotDrinkService = hotDrinkService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHotDrinkAsync()
        {
            var result = await _hotDrinkService.GetAllHotDrinkAsync();
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
        public async Task<IActionResult> GetByIdHotDrinkAsync(int id)
        {
            var result = await _hotDrinkService.GetByIdHotDrinkAsync(id);
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
        public async Task<IActionResult> CreateHotDrinkAsync(CreateHotDrinkDto dto)
        {
            var result = await _hotDrinkService.CreateHotDrinkAsync(dto);
            if (result.Success is false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHotDrinkAsync(UpdateHotDrinkDto dto)
        {
            var result = await _hotDrinkService.UpdateHotDrinkAsync(dto);
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
        public async Task<IActionResult> DeleteHotDrinkAsync(int id)
        {
            var result = await _hotDrinkService.DeleteHotDrinkAsync(id);
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
