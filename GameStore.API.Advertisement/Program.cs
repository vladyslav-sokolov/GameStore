using GameStore.Application.Interfaces;
using GameStore.Domain.Common;
using GameStore.Persistence.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace GameStore.API.Advertisement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider
                    .GetService<IGameStoreAdvertisementDbContext>();
                var dateTime = scope.ServiceProvider
                    .GetService<IDateTime>();

                context.Migrate();

                if (!context.Advertisements.Any())
                {
                    context.SeedData(dateTime);
                    context.SaveChanges();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
