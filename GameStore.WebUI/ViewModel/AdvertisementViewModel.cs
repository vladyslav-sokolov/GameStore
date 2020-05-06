using GameStore.Domain.Models;
using System.Collections.Generic;

namespace GameStore.WebUI.ViewModel
{
    public class AdvertisementViewModel
    {
        public IEnumerable<Advertisement> Advertisements { get; set; }

        public bool IsOk { get; set; } = false;
    }
}
