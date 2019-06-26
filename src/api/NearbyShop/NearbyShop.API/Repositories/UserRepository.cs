using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NearbyShop.API.Data;
using NearbyShop.API.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace NearbyShop.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ApplicationDbContext context,
                              ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Shop[]> AddPreferredShopAsync(int shopId, string userId)
        {
            if (_context.ShopUsers.Any(su => su.ShopId == shopId && su.UserId == userId))
                return await GetPreferredShopsAsync(userId);
            var query = new ShopUser
            {
                ShopId = shopId,
                UserId = userId
            };

            await _context.ShopUsers.AddAsync(query);
            await _context.SaveChangesAsync();
            return await GetPreferredShopsAsync(userId);
        }

        public async Task<Shop[]> GetPreferredShopsAsync(string userId)
        {
            _logger.LogInformation($"Getting all preferred shop for user {userId}");
            var shops = await _context.ShopUsers
                .Include(s => s.Shop)
                .Where(sh => sh.UserId == userId)
                .Select(s => s.Shop)
                .ToArrayAsync();

            return shops;
        }

        public async Task<Shop[]> RemovePreferredShopAsync(int shopId, string userId)
        {
            if (_context.ShopUsers.Any(su => su.ShopId == shopId && su.UserId == userId))
            {
                var query = new ShopUser
                {
                    ShopId = shopId,
                    UserId = userId
                };

                _context.ShopUsers.Remove(query);
                await _context.SaveChangesAsync();
            }
            return await GetPreferredShopsAsync(userId);
        }
    }
}
