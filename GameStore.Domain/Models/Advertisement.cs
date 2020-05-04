using GameStore.Domain.Common;
using System;

namespace GameStore.Domain.Models
{
    public class Advertisement
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
