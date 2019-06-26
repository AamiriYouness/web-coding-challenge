using NearbyShop.API.Entities;
using System.Collections.Generic;

namespace NearbyShop
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }
        public int Distance { get; set; }
        public virtual ICollection<ShopUser> ShopUsers { get; set; } = new HashSet<ShopUser>();
    }
}
