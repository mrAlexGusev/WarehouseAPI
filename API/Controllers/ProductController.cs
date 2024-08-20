using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.API.Models;
using WarehouseAPI.BL.Domain;
using WarehouseAPI.BL.Services.Interfaces;

namespace WarehouseAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAll()
        {
            var productDTOs = await _productService.GetAllAsync();
            var productModels = _mapper.Map<IEnumerable<ProductModel>>(productDTOs);
            return Ok(productModels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetById(int id)
        {
            var productDTO = await _productService.GetByIdAsync(id);
            if (productDTO == null)
            {
                return NotFound();
            }
            var productModel = _mapper.Map<ProductModel>(productDTO);
            return Ok(productModel);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductModel productModel)
        {
            var productDTO = _mapper.Map<ProductDTO>(productModel);
            await _productService.AddAsync(productDTO);
            return CreatedAtAction(nameof(GetById), new { id = productModel.Id }, productModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ProductModel productModel)
        {
            if (id != productModel.Id)
            {
                return BadRequest();
            }
            var productDTO = _mapper.Map<ProductDTO>(productModel);
            await _productService.UpdateAsync(productDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
