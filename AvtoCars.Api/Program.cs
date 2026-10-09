using Microsoft.EntityFrameworkCore;
using AvtoCars.Application.Interfaces;
using AvtoCars.Application.Services;
using AvtoCars.Infrastructure.Persistence;
using AvtoCars.Infrastructure.Repositories;

namespace AvtoCars.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ICarRepository, CarRepository>();

            builder.Services.AddScoped<AddCarServices>();
            builder.Services.AddScoped<SellCarServices>();


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

          
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
