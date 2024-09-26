using System.Windows.Input;
using Microsoft.Maui.Controls;
using AuroraDiary.Models;
using AuroraDiary.Services;

namespace AuroraDiary.Views
{
    public partial class RegisterPage1 : ContentPage
    {
        public ICommand ContinueCommand { get; }
        public ICommand LoginCommand { get; }

        public RegisterPage1()
        {
            InitializeComponent();
            ContinueCommand = new Command(RegisterButton_Clicked);
            LoginCommand = new Command(OnLoginClicked);
            BindingContext = this;
        }

        private async void RegisterButton_Clicked()
        {
            // Validation such as comparing password and confirm password should go here
            User user = new User()
            {
                Email = EntryEmail.Text,
                Username = EntryFirstName.Text, // assuming Username is the first name
                FullName = EntryLastName.Text, // assuming FullName is the last name
                DateOfBirth = DateTime.Now // placeholder for actual DateOfBirth
            };

            // Send to AuthManager
            var result = await FirebaseAuthManager.RegisterAccount(user, EntryPassword.Text);
            if (result)
            {
                // If successful, return to login by closing page
                await Shell.Current.Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Error", "Could not create account. Check details and try again.", "OK");
            }
        }

        private async void OnContinueClicked()
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnLoginClicked()
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
