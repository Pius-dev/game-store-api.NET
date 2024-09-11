using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace gameStore.API.DatabaseConnection
{
    public class GameStoreDbContextFactory : IDesignTimeDbContextFactory<GameStoreDbContext>
    {
        public GameStoreDbContext CreateDbContext(string[] args)
        {
            // Set up the configuration to read from the appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Create options builder for DbContext
            var optionsBuilder = new DbContextOptionsBuilder<GameStoreDbContext>();
            
            // Get the connection string from the configuration
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Pass the connection string to the options builder
            optionsBuilder.UseNpgsql(connectionString);

            return new GameStoreDbContext(optionsBuilder.Options);
        }
    }
}
