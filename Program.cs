using Microsoft.EntityFrameworkCore;
using WarehouseAPI.BL.Services;
using WarehouseAPI.BL.Services.Interfaces;
using WarehouseAPI.DAL.Data.Repositories;
using WarehouseAPI.DAL.Data.Repositories.Abstract;
using WarehouseAPI.DAL.DBContext;
using Microsoft.OpenApi.Models;

namespace WarehouseAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ���������� DbContext � ������������
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            builder.Services.AddScoped<IStockRepository, StockRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            // ���������� ��������
            builder.Services.AddScoped<IWarehouseService, WarehouseService>();
            builder.Services.AddScoped<IStockService, StockService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            // ���������� AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            // ���������� �������� ��� ����������� � ��������������
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication();

            // ���������� �������� ��� ������������
            builder.Services.AddControllers();

            // ���������� Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Warehouse API", Version = "v1" });
            });

            var app = builder.Build();

            // ��������� Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Warehouse API V1");
                });
            }

            // ��������� middleware
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
