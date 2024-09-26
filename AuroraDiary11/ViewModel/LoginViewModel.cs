using System.Windows.Input;


namespace AuroraDiary.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        private string _password;
        private string _errorMessage;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked()
        {
            bool isAuthenticated = AuthenticateUser(Email, Password);

            if (isAuthenticated)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Logged in successfully", "Ok");
                // Navigate to AllEntryListPage
                await Application.Current.MainPage.Navigation.PushAsync(new AuroraDiary.Views.AllEntryList());
            }
            else
            {
                ErrorMessage = "Could not log in, please check credentials and try again";
                await Application.Current.MainPage.DisplayAlert("Error", ErrorMessage, "Ok");
            }
        }

        private bool AuthenticateUser(string email, string password)
        {
            return email == "test@example.com" && password == "password123";
        }
    }
}
