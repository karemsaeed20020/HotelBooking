
using HotelBooking.API.CustomMiddlewares;
using HotelBooking.API.DependencyInjection;
using HotelBooking.API.Extensions;
using HotelBooking.Infrastructure.DependencyInjection;
using System.Threading.Tasks;

namespace HotelBooking.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddPresentationServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);


            var app = builder.Build();

            await app.MigrateDatbaseAsync();
            await app.MigrateDatbaseAsync();
            await app.SeedIdentityDatabaseAsync();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
