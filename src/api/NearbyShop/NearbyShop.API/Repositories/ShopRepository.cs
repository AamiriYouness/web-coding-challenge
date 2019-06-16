using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NearbyShop.API.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NearbyShop.API.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ShopRepository> _logger;

        public ShopRepository(ApplicationDbContext context,
                              ILogger<ShopRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Shop[]> GetAllShopsAsync()
        {
            _logger.LogInformation($"Getting all Shops");

            IQueryable<Shop> query =
                _context.Shops.OrderBy(s => s.Distance);

            return await query.ToArrayAsync();
        }
    }
}
