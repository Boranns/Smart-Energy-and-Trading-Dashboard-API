using Microsoft.AspNetCore.Mvc;
using SmartEnergyAPI.Entities;
using SmartEnergyAPI.Services;

namespace SmartEnergyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnergyProductsController : ControllerBase
    {
        private readonly EnergyProductService _service;

        public EnergyProductsController(EnergyProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EnergyProduct product)
        {
            await _service.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EnergyProduct product)
        {
            if (id != product.Id) return BadRequest();
            await _service.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetById(id);
            if (product == null) return NotFound();
            await _service.Delete(product);
            return NoContent();
        }
    }
}

