using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopSharedModels.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public TimeSpan? DeliveryTime { get; set; }
        public string? DeliveryAdress { get; set; }
        public decimal? Cost { get; set; }
    }
}
