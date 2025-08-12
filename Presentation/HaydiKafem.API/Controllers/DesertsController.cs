using HaydiKafem.Application.Dtos.DesertDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Services.DesertServices;
using Microsoft.AspNetCore.Mvc;

namespace HaydiKafem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesertsController : ControllerBase
    {
        private readonly IDesertService _desertService;

        public DesertsController(IDesertService desertService)
        {
            _desertService = desertService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDesertAsync()
        {
            var result = await _desertService.GetAllDesertAsync();
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
        public async Task<IActionResult> GetByIdDesertAsync(int id)
        {
            var result = await _desertService.GetByIdDesertAsync(id);
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
        public async Task<IActionResult> CreateDesertAsync(CreateDesertDto dto)
        {
            var result = await _desertService.CreateDesertAsync(dto);
            if (result.Success is false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDesertAsync(UpdateDesertDto dto)
        {
            var result = await _desertService.UpdateDesertAsync(dto);
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
        [HttpDelete]
        public async Task<IActionResult> DeleteDesertAsync(int id)
        {
            var result = await _desertService.DeleteDesertAsync(id);
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
