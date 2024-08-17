using Microsoft.EntityFrameworkCore;
using WarehouseAPI.BL.Services;
using WarehouseAPI.BL.Services.Interfaces;
using WarehouseAPI.DAL.Data.Repositories;
using WarehouseAPI.DAL.Data.Repositories.Abstract;
using WarehouseAPI.DAL.DBContext;

namespace WarehouseAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            builder.Services.AddScoped<IStockRepository, StockRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddScoped<IWarehouseService, WarehouseService>();
            builder.Services.AddScoped<IStockService, StockService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddAutoMapper(typeof(Program));
            
            var app = builder.Build();
        }
    }
}
