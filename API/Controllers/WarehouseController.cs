using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.API.Models;
using WarehouseAPI.BL.Domain;
using WarehouseAPI.BL.Services.Interfaces;

namespace WarehouseAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IMapper _mapper;

        public WarehouseController(IWarehouseService warehouseService, IMapper mapper)
        {
            _warehouseService = warehouseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseModel>>> GetAll()
        {
            var warehouseDTOs = await _warehouseService.GetAllAsync();
            var warehouseModels = _mapper.Map<IEnumerable<WarehouseModel>>(warehouseDTOs);
            return Ok(warehouseModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseModel>> GetById(int id)
        {
            var warehouseDTO = await _warehouseService.GetByIdAsync(id);
            if (warehouseDTO == null)
            {
                return NotFound();
            }
            var warehouseModel = _mapper.Map<WarehouseModel>(warehouseDTO);
            return Ok(warehouseModel);
        }

        [HttpPost]
        public async Task<ActionResult> Add(WarehouseModel warehouseModel)
        {
            var warehouseDTO = _mapper.Map<WarehouseDTO>(warehouseModel);
            await _warehouseService.AddAsync(warehouseDTO);
            return CreatedAtAction(nameof(GetById), new { id = warehouseModel.Id }, warehouseModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, WarehouseModel warehouseModel)
        {
            if (id != warehouseModel.Id)
            {
                return BadRequest();
            }
            var warehouseDTO = _mapper.Map<WarehouseDTO>(warehouseModel);
            await _warehouseService.UpdateAsync(warehouseDTO);
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
