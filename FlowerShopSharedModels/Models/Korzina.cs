using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopSharedModels.Models
{
    public class Korzina
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Product_Id { get; set; }
        public string? Delivery_Adress { get; set; }
        public decimal? Cost { get; set; }
    }
}
