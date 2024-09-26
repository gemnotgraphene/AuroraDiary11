using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace AuroraDiary.Views
{
    public partial class ResetPasswordPage : ContentPage
    {
        public ICommand ResetCommand { get; }

        public ResetPasswordPage()
        {
            InitializeComponent();
            ResetCommand = new Command(() => OnResetClicked());
            BindingContext = this;
        }

        private void OnResetClicked()
        {
            // Handle the password reset logic here

            // Clear the navigation stack and navigate to LoginPage
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
