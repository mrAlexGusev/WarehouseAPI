using AutoMapper;
using WarehouseAPI.API.Models;
using WarehouseAPI.BL.Domain;

namespace WarehouseAPI.Mapper
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<WarehouseDTO, WarehouseModel>();
            CreateMap<WarehouseModel, WarehouseDTO>();
        }
    }
}
