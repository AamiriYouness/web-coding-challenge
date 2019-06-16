using System.Threading.Tasks;

namespace NearbyShop.API.Repositories
{
    public interface IShopRepository
    {
        Task<Shop[]> GetAllShopsAsync();
    }
}