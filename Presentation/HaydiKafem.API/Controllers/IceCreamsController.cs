using HaydiKafem.Application.Dtos.IceCreamDtos;
using HaydiKafem.Application.Dtos.ResponseDtos;
using HaydiKafem.Application.Services.IceCreamServices;
using Microsoft.AspNetCore.Mvc;

namespace HaydiKafem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IceCreamsController : ControllerBase
    {
        private readonly IIceCreamService _iceCreamService;

        public IceCreamsController(IIceCreamService iceCreamService)
        {
            _iceCreamService = iceCreamService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIceCreamAsync()
        {
            var result = await _iceCreamService.GetAllIceCreamAsync();
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
        public async Task<IActionResult> GetByIdIceCreamAsync(int id)
        {
            var result = await _iceCreamService.GetByIdIceCreamAsync(id);
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
        public async Task<IActionResult> CreateIceCreamAsync(CreateIceCreamDto dto)
        {
            var result = await _iceCreamService.CreateIceCreamAsync(dto);
            if (result.Success is false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateIceCreamAsync(UpdateIceCreamDto dto)
        {
            var result = await _iceCreamService.UpdateIceCreamAsync(dto);
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
        public async Task<IActionResult> DeleteIceCreamAsync(int id)
        {
            var result = await _iceCreamService.DeleteIceCreamAsync(id);
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
