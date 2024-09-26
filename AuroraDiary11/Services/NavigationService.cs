using System.Threading.Tasks;

namespace AuroraDiary.Services
{
    public class NavigationService : INavigationService
    {
        public Task NavigateToAsync(Page page)
        {
            return Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
