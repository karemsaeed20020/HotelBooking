using HotelBooking.Application.Interfaces;
using HotelBooking.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.API.Extensions
{
    public static class DatabaseMigrationExtensions
    {
        public static async Task<WebApplication> MigrateDatbaseAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var dbContextService = scope.ServiceProvider.GetRequiredService<HotelBookingDbContext>();
            var pendingMigrations = await dbContextService.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                await dbContextService.Database.MigrateAsync();
            }

            return app;
        }

        public static async Task<WebApplication> SeedDatabaseAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var DataInatializerService = scope.ServiceProvider.GetRequiredKeyedService<IDataInitializer>("Default");
            await DataInatializerService.InitializeAsync();
            return app;
        }
        public static async Task<WebApplication> SeedIdentityDatabaseAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var dataInatializerService = scope.ServiceProvider.GetRequiredKeyedService<IDataInitializer>("Identity");
            await dataInatializerService.InitializeAsync();
            return app;
        }
    }
}
