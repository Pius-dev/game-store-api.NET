using gameStore.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace gameStore.API.DatabaseConnection
{
    public class GameStoreDbContext : DbContext
    {
        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
