using Microsoft.AspNetCore.Mvc;
using WareHolder.Server.DTOs;
using WareHolder.Server.Services;

namespace WareHolder.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var createdProduct = await _productService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productService.DeleteAsync(id);

            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
