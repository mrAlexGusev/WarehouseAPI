using AutoMapper;
using WarehouseAPI.API.Models;
using WarehouseAPI.BL.Domain;

namespace WarehouseAPI.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, ProductModel>();
            CreateMap<ProductModel, ProductDTO>();
        }
    }
}
