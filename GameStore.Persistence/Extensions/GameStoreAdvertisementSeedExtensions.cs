using System.Linq;
using GameStore.Application.Interfaces;
using GameStore.Domain.Common;

namespace GameStore.Persistence.Extensions
{
    public static class GameStoreAdvertisementSeedExtensions
    {
        public static void SeedData(this IGameStoreAdvertisementDbContext context, IDateTime dateTime)
        {
            var advertisements = Enumerable.Range(1, 2).Select(index => new Domain.Models.Advertisement
            {
                Description = "Top " + index,
                EndDateTime = dateTime.Now.AddDays(index)
            }).ToArray();

            context.Advertisements.AddRange(advertisements);
        }
    }
}
