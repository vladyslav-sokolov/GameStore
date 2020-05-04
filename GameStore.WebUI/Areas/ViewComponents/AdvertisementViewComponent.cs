using GameStore.Domain.Common;
using GameStore.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebUI.Areas.ViewComponents
{
    public class AdvertisementViewComponent : ViewComponent
    {
        private readonly Advertisement[] advertisements;

        public AdvertisementViewComponent(IDateTime dateTime)
        {
            advertisements = new[] { new Advertisement { Description = "Top Sale", EndDateTime = dateTime.Now.AddDays(1) } };
        }

        public IViewComponentResult Invoke()
        {
            return View(advertisements);
        }
    }
}
