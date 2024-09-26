using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace AuroraDiary.Views
{
    public partial class ForgotPasswordPage : ContentPage
    {
        public ICommand SendCommand { get; }

        public ForgotPasswordPage()
        {
            InitializeComponent();
            SendCommand = new Command(OnSendClicked);
            BindingContext = this;
        }

        private async void OnSendClicked()
        {
            await Navigation.PushAsync(new ResetPasswordPage());
        }
    }
}
