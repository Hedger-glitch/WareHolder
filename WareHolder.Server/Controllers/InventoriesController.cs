using Microsoft.AspNetCore.Mvc;
using WareHolder.Server.DTOs;
using WareHolder.Server.Services;

namespace WareHolder.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoriesController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoriesController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _inventoryService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate([FromBody] CreateInventoryDto dto)
        {
            try
            {
                var result = await _inventoryService.AddOrUpdateAsync(dto);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
