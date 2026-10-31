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

        [ObservableProperty]
        private string? _capacityFamily;

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
