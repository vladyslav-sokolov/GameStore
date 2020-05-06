using GameStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces
{
    public interface IGameStoreAdvertisementDbContext
    {
        DbSet<Advertisement> Advertisements { get; set; }

        void Migrate();

        void SaveChanges();
    }
}
