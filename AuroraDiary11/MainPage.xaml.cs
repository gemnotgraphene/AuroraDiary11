using AuroraDiary.Services;
using Microsoft.Maui.Controls;
using System;

namespace AuroraDiary.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // If the user has not logged in yet, show the login page as a modal
            if (FirebaseAuthManager.GetCurrentUser == null)
            {
                Shell.Current.Navigation.PushModalAsync(new LoginPage());
            }
        }
    }
}

