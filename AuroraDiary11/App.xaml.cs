using Microsoft.Maui.Controls;
using AuroraDiary.Views;

namespace AuroraDiary
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new SplashPage());
        }

        public static object? NavigationService { get; internal set; }
    }
}
