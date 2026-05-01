
using HotelBooking.API.CustomMiddlewares;
using HotelBooking.API.DependencyInjection;
using HotelBooking.API.Extensions;
using HotelBooking.Application.DependencyInjection;
using HotelBooking.Infrastructure.DependencyInjection;
using HotelBooking.Infrastructure.Identity.Secutiry;

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
            builder.Services.AddApplicationServices();

            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));


            var app = builder.Build();

            await app.MigrateDatbaseAsync();
            await app.SeedDatabaseAsync();
            await app.SeedIdentityDatabaseAsync();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var asm = typeof(HotelBooking.Application.AssemblyReference).Assembly;

            var handlers = asm.GetTypes()
                .Where(t => t.GetInterfaces()
                .Any(i => i.Name.Contains("IRequestHandler")))
                .ToList();

            Console.WriteLine($"Handlers found: {handlers.Count}");

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
