using Microsoft.AspNetCore.Mvc;
using WareHolder.Server.DTOs;
using WareHolder.Server.Services;

namespace WareHolder.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _warehouseService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var warehouse = await _warehouseService.GetByIdAsync(id);
            if (warehouse == null) return NotFound();
            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWarehouseDto dto)
        {
            var created = await _warehouseService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _warehouseService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
