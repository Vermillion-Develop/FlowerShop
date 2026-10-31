using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlowerShop.Services.api;
using FlowerShop.Services.interfaces;
using System.Threading.Tasks;

namespace FlowerShop.ViewModels
{
    public partial class StartPageViewModel : ViewModelBase
    {
        private readonly IUserApi _userApi;
        private readonly MainWindowViewModel _mainViewModel;

        [ObservableProperty]
        private string? _error;

        [ObservableProperty]
        private string? _login;

        [ObservableProperty]
        private string? _password;
        public StartPageViewModel(MainWindowViewModel mainViewModel) 
        {
            _userApi = new UserApi();
            _mainViewModel = mainViewModel;
            Title = "Вход в систему";
        }

        [RelayCommand]
        private async Task GetLogginedAsync()
        {
            if(Login == null || Password == null)
            {
                Error = "Неверный логин или пароль";
                return;
            }
            var result = await _userApi.LoginInAsync(Login, Password);
            if(result == null)
            {
                Error = "Неверный логин или пароль";
                return;
            }
            Error = "Успешный вход!";
        }

        [RelayCommand]
        private async Task GoToRegister()
        {
            await _mainViewModel.GoToRegistration();
        }
    }
}
