using FlowerShopSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Services.interfaces
{
    public interface IUserApi
    {
        Task<UserDTO?> LoginInAsync(string login, string password);
        Task<bool> SignUpAsync(string family, string name, string father, string phone, string login, string password);
    }
}
