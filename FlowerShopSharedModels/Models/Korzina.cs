using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopSharedModels.Models
{
    public class Korzina
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string? DeliveryAdress { get; set; }
        public decimal? Cost { get; set; }
    }
}
