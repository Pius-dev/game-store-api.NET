
using Microsoft.EntityFrameworkCore;

namespace gameStore.API.DatabaseConnection
{
    public static class DatabaseExtensions
    {
        public static void MigrateDb (this WebApplication app){
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<GameStoreDbContext>();
            db.Database.Migrate();
        }
    }
}