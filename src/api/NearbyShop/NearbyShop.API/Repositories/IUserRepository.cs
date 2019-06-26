using System.Threading.Tasks;

namespace NearbyShop.API.Repositories
{
    public interface IUserRepository
    {
        Task<Shop[]> GetPreferredShopsAsync(string userId);
        Task<Shop[]> AddPreferredShopAsync(int shopId, string userId);
        Task<Shop[]> RemovePreferredShopAsync(int shopId, string userId);

    }
}