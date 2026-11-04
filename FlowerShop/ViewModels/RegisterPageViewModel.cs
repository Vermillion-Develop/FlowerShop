using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlowerShop.Services.api;
using FlowerShop.Services.interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.ViewModels
{
    public partial class RegisterPageViewModel : ViewModelBase
    {
        private readonly IUserApi _userApi;
        private readonly MainWindowViewModel _mainViewModel;

        [ObservableProperty]
        private string? _capacityFamily;

        [ObservableProperty]
        private string? _error;

        [ObservableProperty]
        private string? _capacityName;

        [ObservableProperty]
        private string? _capacityFather;

        [ObservableProperty]
        private string? _capacityLogin;

        [ObservableProperty]
        private string? _capacityPhone;

        [ObservableProperty]
        private string? _family;

        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        private string? _father;

        [ObservableProperty]
        private string? _login;

        [ObservableProperty]
        private string? _phone;

        [ObservableProperty]
        private string? _password;

        [ObservableProperty]
        private string? _secondPassword;


        public RegisterPageViewModel(MainWindowViewModel mainViewModel) 
        {
            _userApi = new UserApi();
            _mainViewModel = mainViewModel;
            Title = "Регистрация";
        }

        [RelayCommand]
        private async Task BackToStart()
        {
            _mainViewModel.CurrentGlobalScreen = new StartPageViewModel(_mainViewModel);
        }

        [RelayCommand]
        private async Task GettedRegisterAsync()
        {
            if(string.IsNullOrWhiteSpace(Family) || string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Father) || string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Phone) || !Phone.All(char.IsDigit) || string.IsNullOrWhiteSpace(Password))
            {
                Error = "Заполните все поля!";
                return;
            }
            if(Password != SecondPassword)
            {
                Error = "Пароли не совпадают!";
                return;
            }
            var result = await _userApi.SignUpAsync(Family, Name, Father, Phone, Login, Password);
            if (result)
            {
                _ = BackToStart();
            }
            else
            {
                Error = "Произошла ошибка!";
                return;
            }

        }

        partial void OnFamilyChanged(string? value)
        {
            CapacityFamily = value.Length.ToString() + "/150";
        }
        partial void OnNameChanged(string? value)
        {
            CapacityName = value.Length.ToString() + "/150";
        }
        partial void OnFatherChanged(string? value)
        {
            CapacityFather = value.Length.ToString() + "/150";
        }
        partial void OnLoginChanged(string? value)
        {
            CapacityLogin = value.Length.ToString() + "/150";
        }
        partial void OnPhoneChanged(string? value)
        {
            CapacityPhone = value.Length.ToString() + "/11";
        }

    }
}
