using FlowerShop.Services.interfaces;
using FlowerShopSharedModels.Models;
using FlowerShopSharedModels.requests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Services.api
{
    public class UserApi : IUserApi
    {
        private readonly HttpClient _httpClient;

        public UserApi()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://100.101.246.43:80") };
        }
        public async Task<UserDTO?> LoginInAsync(string login, string password)
        {
			try
			{
                LoginRequestDTO request = new LoginRequestDTO() { Login = login, Password = password };
                var response = await _httpClient.PostAsJsonAsync("api/User/loginIn", request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<UserDTO>();
                }
                return null;
			}
			catch (Exception ex)
			{
                Debug.WriteLine(ex.Message);
                return null;
				throw;
			}
        }

    }
}
