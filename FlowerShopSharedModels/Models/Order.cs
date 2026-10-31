using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopSharedModels.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public TimeSpan? Delivery_Time { get; set; }
        public string? Delivery_Adress { get; set; }
        public decimal? Cost { get; set; }
    }
}
