using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopSharedModels.Models
{
    public class User_orders
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
        public int? Quantity { get; set; }
    }
}
