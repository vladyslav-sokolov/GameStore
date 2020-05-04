using GameStore.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace GameStore.WebUI.Areas.ViewComponents
{
    public class AdvertisementViewComponent : ViewComponent
    {
        private readonly IConfiguration configuration;

        public AdvertisementViewComponent(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async System.Threading.Tasks.Task<IViewComponentResult> InvokeAsync()
        {
            using var client = new HttpClient();
            var code = await client.GetAsync(configuration["Advertisement_API"] + "advertisement");

            if (code.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(code.StatusCode.ToString());
            }

            var cc = await code.Content.ReadAsStringAsync();
            var result = (IEnumerable<Advertisement>)JsonConvert.DeserializeObject(cc, typeof(IEnumerable<Advertisement>));

            return View(result);
        }
    }
}
