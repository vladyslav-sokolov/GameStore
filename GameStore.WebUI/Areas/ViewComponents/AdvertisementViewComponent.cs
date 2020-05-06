using GameStore.Domain.Models;
using GameStore.WebUI.ViewModel;
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
            HttpResponseMessage code;

            try
            {
                using var client = new HttpClient();
                code = await client.GetAsync(configuration["Advertisement_API"] + "advertisement");

                if (code.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View(new AdvertisementViewModel());
                }
            }
            catch (Exception)
            {
                return View(new AdvertisementViewModel());
            }

            var result = (IEnumerable<Advertisement>)JsonConvert.DeserializeObject(
                await code.Content.ReadAsStringAsync(),
                typeof(IEnumerable<Advertisement>));

            return View(new AdvertisementViewModel
            {
                IsOk = true,
                Advertisements = result
            });
        }
    }
}
