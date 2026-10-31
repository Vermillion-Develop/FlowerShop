using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopSharedModels.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public byte[]? PhotoHashed { get; set; }
        public decimal? Cost { get; set; }
    }
}
