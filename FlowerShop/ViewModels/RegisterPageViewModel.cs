using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlowerShop.Services.api;
using FlowerShop.Services.interfaces;
using System.Threading.Tasks;

namespace FlowerShop.ViewModels
{
    public partial class RegisterPageViewModel : ViewModelBase
    {
        private readonly IUserApi _userApi;
        private readonly MainWindowViewModel _mainViewModel;


        public RegisterPageViewModel(MainWindowViewModel mainViewModel) 
        {
            _userApi = new UserApi();
            _mainViewModel = mainViewModel;
        }

        [RelayCommand]
        private async Task BackToStart()
        {
            _mainViewModel.CurrentGlobalScreen = new StartPageViewModel(_mainViewModel);
        }

    }
}
