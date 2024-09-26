using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace AuroraDiary.Views
{
    public partial class OnboardingPage : ContentPage
    {
        public ObservableCollection<OnboardingItem> OnboardingItems { get; set; }
        public ICommand NextCommand { get; }
        public ICommand GetStartedCommand { get; }

        public OnboardingPage()
        {
            InitializeComponent();
            NextCommand = new Command(NextPage);
            GetStartedCommand = new Command(GetStarted);

            OnboardingItems = new ObservableCollection<OnboardingItem>
            {
                new OnboardingItem
                {
                    Image = "onboarding1.png",
                    Title = "Diary with lock",
                    Description = "Store your memories in a safe and secure way!",
                    ButtonText = "Next",
                    ButtonCommand = NextCommand
                },
                new OnboardingItem
                {
                    Image = "onboarding2.png",
                    Title = "Portable",
                    Description = "We can write our Diary any where!",
                    ButtonText = "Next",
                    ButtonCommand = NextCommand
                },
                new OnboardingItem
                {
                    Image = "onboarding3.png",
                    Title = "Search diary",
                    Description = "Effortlessly search your diary to relive a particular memory!",
                    ButtonText = "Get Started",
                    ButtonCommand = GetStartedCommand
                }
            };

            BindingContext = this;
        }

        private void NextPage()
        {
            var currentIndex = OnboardingItems.IndexOf((OnboardingItem)carouselView.CurrentItem);
            var nextIndex = (currentIndex + 1) % OnboardingItems.Count;
            carouselView.Position = nextIndex;
        }

        private async void GetStarted()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage1());
        }
    }

    public class OnboardingItem
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ButtonText { get; set; }
        public ICommand ButtonCommand { get; set; }
    }
}
