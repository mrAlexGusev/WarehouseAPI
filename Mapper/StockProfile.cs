using AutoMapper;
using WarehouseAPI.API.Models;
using WarehouseAPI.BL.Domain;

namespace WarehouseAPI.Mapper
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<StockDTO, StockModel>();
            CreateMap<StockModel, StockDTO>();
        }
    }
}
