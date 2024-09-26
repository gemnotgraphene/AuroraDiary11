using Microsoft.Maui.Controls;
using System.Windows.Input;
using AuroraDiary.Services;
using Microsoft.Maui.Storage;

namespace AuroraDiary.Views
{
    public partial class LoginPage : ContentPage
    {
        public ICommand LoginCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

        public LoginPage()
        {
            InitializeComponent();
            LoginCommand = new Command(LoginButton_Clicked);
            ForgotPasswordCommand = new Command(OnForgotPasswordClicked);
            BindingContext = this;
        }

        private async void LoginButton_Clicked()
        {
            // If login failed, display an error and return
            if (!await FirebaseAuthManager.Login(EntryEmail.Text, EntryPassword.Text))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Could not log in, please check credentials and try again", "Ok");
                EntryPassword.Text = "";
                return;
            }

            // If login succeeded, save details (if checkbox is ticked) and close page
            if (RememberMeCheckbox.IsChecked)
            {
                // Update preferences
                Preferences.Set(Constants.EMAIL_KEY, EntryEmail.Text);
                Preferences.Set(Constants.PASSWORD_KEY, EntryPassword.Text);
                Preferences.Set(Constants.REMEMBER_ME_KEY, true);
            }
            else
            {
                // Clear preferences
                Preferences.Default.Remove(Constants.EMAIL_KEY);
                Preferences.Default.Remove(Constants.PASSWORD_KEY);
                Preferences.Default.Remove(Constants.REMEMBER_ME_KEY);
            }

            // Navigate to AllEntryList and remove all previous pages from the navigation stack
            Application.Current.MainPage = new NavigationPage(new AllEntryList());
        }

        private async void OnForgotPasswordClicked()
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }

        private void RegisterLabel_Tapped(object sender, TappedEventArgs e)
        {
            Task task = Shell.Current.Navigation.PushAsync(new RegisterPage1());
        }
    }
}
