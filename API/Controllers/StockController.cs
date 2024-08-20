using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.API.Models;
using WarehouseAPI.BL.Domain;
using WarehouseAPI.BL.Services.Interfaces;

namespace WarehouseAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;

        public StockController(IStockService stockService, IMapper mapper)
        {
            _stockService = stockService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockModel>>> GetAll()
        {
            var stockDTOs = await _stockService.GetAllAsync();
            var stockModels = _mapper.Map<IEnumerable<StockModel>>(stockDTOs);
            return Ok(stockModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockModel>> GetById(int id)
        {
            var stockDTO = await _stockService.GetByIdAsync(id);
            if (stockDTO == null)
            {
                return NotFound();
            }
            var stockModel = _mapper.Map<StockModel>(stockDTO);
            return Ok(stockModel);
        }

        [HttpPost]
        public async Task<ActionResult> Add(StockModel stockModel)
        {
            var stockDTO = _mapper.Map<StockDTO>(stockModel);
            await _stockService.AddAsync(stockDTO);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, StockModel stockModel)
        {
            if (id != stockModel.Id)
            {
                return BadRequest();
            }
            var stockDTO = _mapper.Map<StockDTO>(stockModel);
            await _stockService.UpdateAsync(stockDTO);
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
