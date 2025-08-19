using HaydiKafem.Application.Dtos.AboutDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace HaydiKafem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAboutAsync()
        {
            var result = await _aboutService.GetAllAboutAsync();
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
        public async Task<IActionResult> CreateAboutAsync(CreateAboutDto dto)
        {
            var result = await _aboutService.CreateAboutAsync(dto);
            if (result.Success is false)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAboutAsync(UpdateAboutDto dto)
        {
            var result = await _aboutService.UpdateAboutAsync(dto);
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
        public async Task<IActionResult> DeleteAboutAsync(int id)
        {
            var result = await _aboutService.DeleteAboutAsync(id);
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
        [HttpGet("GetAboutById")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var result = await _aboutService.GetByIdAboutAsync(id);
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
