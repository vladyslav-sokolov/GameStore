using GameStore.Application.Interfaces;
using GameStore.Domain.Models;
using GameStore.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Persistence
{
    public class GameStoreAdvertisementDbContext : DbContext, IGameStoreAdvertisementDbContext
    {
        public DbSet<Advertisement> Advertisements { get; set; }

        public GameStoreAdvertisementDbContext(DbContextOptions<GameStoreAdvertisementDbContext> options) : base(options) { }

        public void Migrate()
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
        }

        new public void SaveChanges() => base.SaveChanges();
    }
}
