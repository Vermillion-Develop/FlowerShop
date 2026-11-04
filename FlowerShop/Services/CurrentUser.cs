using FlowerShopSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop.Services
{
    public static class CurrentUser
    {
        public static UserDTO? LoginedUser = null;
    }
}
