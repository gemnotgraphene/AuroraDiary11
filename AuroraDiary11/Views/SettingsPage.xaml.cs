using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace AuroraDiary.Views
{
    public partial class SettingsPage : ContentPage
    {
        public ICommand NavigateToPersonalDetailsCommand { get; }
        public ICommand NavigateToNotificationsCommand { get; }
        public ICommand NavigateToLogoutCommand { get; }

        public SettingsPage()
        {
            InitializeComponent();
            NavigateToPersonalDetailsCommand = new Command(OnNavigateToPersonalDetails);
            NavigateToNotificationsCommand = new Command(OnNavigateToNotifications);
            NavigateToLogoutCommand = new Command(OnNavigateToLogout);
            BindingContext = this;
        }

        private async void OnNavigateToPersonalDetails()
        {
            await Navigation.PushAsync(new PersonalDetailsPage());
        }

        private async void OnNavigateToNotifications()
        {
            await Navigation.PushAsync(new NotificationsPage());
        }

        private async void OnNavigateToLogout()
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
