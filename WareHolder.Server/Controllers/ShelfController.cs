using Microsoft.AspNetCore.Mvc;
using WareHolder.Server.DTOs;
using WareHolder.Server.Services;

namespace WareHolder.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShelfController : ControllerBase
    {
        private readonly IShelfService _shelfService;

        ShelfController(IShelfService shelfService)
        {
            _shelfService = shelfService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _shelfService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shelf = await _shelfService.GetByIdAsync(id);
            if (shelf == null) return NotFound();
            return Ok(shelf);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShelfDto dto)
        {
            var created = await _shelfService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _shelfService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }


}
