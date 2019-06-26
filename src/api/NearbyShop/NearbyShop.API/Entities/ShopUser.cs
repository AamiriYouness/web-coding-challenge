using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearbyShop.API.Entities
{
    public class ShopUser
    {
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
