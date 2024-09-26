using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace AuroraDiary.Views
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            NavigateToOnboardingPage();
        }

        async void NavigateToOnboardingPage()
        {
            await Task.Delay(3000); // 3 seconds delay
            await Application.Current.MainPage.Navigation.PushAsync(new OnboardingPage());
        }
    }
}
