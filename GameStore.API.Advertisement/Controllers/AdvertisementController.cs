using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Advertisement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertisementController : ControllerBase
    {
        private readonly IDateTime dateTime;

        public AdvertisementController(IDateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        [HttpGet]
        public IEnumerable<Domain.Models.Advertisement> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 2).Select(index => new Domain.Models.Advertisement
            {
                Description = "Top " + index,
                EndDateTime = dateTime.Now.AddDays(index)
            })
            .ToArray();
        }
    }
}
