using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlowerShop.Services.api;
using FlowerShop.Services.interfaces;
using FlowerShopSharedModels.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlowerShop.ViewModels
{
    public partial class PrimaryPageViewModel : ViewModelBase
    {
        private readonly IUserApi _userApi;
        private readonly MainWindowViewModel _mainViewModel;
        public ObservableCollection<Product> Products { get; set; }

        [ObservableProperty]
        private string? _error;

        public PrimaryPageViewModel(MainWindowViewModel mainViewModel) 
        {
            _userApi = new UserApi();
            _mainViewModel = mainViewModel;
            Title = "Главная";
            Products = new ObservableCollection<Product>()
            {
                new Product(){Name = "Роза", Cost = 1500},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
                new Product(){Name = "Ромашка", Cost = 15000},
            };
        }
    }
}
