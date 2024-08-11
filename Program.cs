using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

            var app = builder.Build();

        }
    }
}
