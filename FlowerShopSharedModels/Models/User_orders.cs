using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopSharedModels.Models
{
    public class User_orders
    {
        public int Id { get; set; }
        public int? Product_Id { get; set; }
        public int? Order_Id { get; set; }
        public int? Quantity { get; set; }
    }
}
