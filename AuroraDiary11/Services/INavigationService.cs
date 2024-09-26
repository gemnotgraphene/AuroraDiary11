using System.Threading.Tasks;

namespace AuroraDiary.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync(Page page);
    }
}
