using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.BL.Services.Interfaces;
using WarehouseAPI.DAL.Entities;

namespace WarehouseAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetAll()
        {
            var stocks = await _stockService.GetAllAsync();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetById(int id)
        {
            var stock = await _stockService.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Stock stock)
        {
            await _stockService.AddAsync(stock);
            return CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Stock stock)
        {
            if (id != stock.Id)
            {
                return BadRequest();
            }
            await _stockService.UpdateAsync(stock);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _stockService.DeleteAsync(id);
            return NoContent();
        }
    }
}
