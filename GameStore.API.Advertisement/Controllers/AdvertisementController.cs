using System.Collections.Generic;
using System.Linq;
using GameStore.Application.Interfaces;
using GameStore.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Advertisement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertisementController : ControllerBase
    {
        private readonly IDateTime dateTime;
        private readonly IGameStoreAdvertisementDbContext context;

        public AdvertisementController(IDateTime dateTime, IGameStoreAdvertisementDbContext context)
        {
            this.dateTime = dateTime;
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Domain.Models.Advertisement> Get()
        {
            return context.Advertisements.ToArray();
        }
    }
}
