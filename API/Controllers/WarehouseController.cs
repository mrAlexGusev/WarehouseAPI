using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.BL.Services.Interfaces;
using WarehouseAPI.DAL.Entities;

namespace WarehouseAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetAll()
        {
            var warehouses = await _warehouseService.GetAllAsync();
            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouse>> GetById(int id)
        {
            var warehouse = await _warehouseService.GetByIdAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Warehouse warehouse)
        {
            await _warehouseService.AddAsync(warehouse);
            return CreatedAtAction(nameof(GetById), new { id = warehouse.Id }, warehouse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Warehouse warehouse)
        {
            if (id != warehouse.Id)
            {
                return BadRequest();
            }
            await _warehouseService.UpdateAsync(warehouse);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _warehouseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
