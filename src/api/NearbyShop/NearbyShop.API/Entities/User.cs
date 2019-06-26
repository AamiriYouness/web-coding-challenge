using Microsoft.AspNetCore.Identity;
using NearbyShop.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearbyShop
{
    public class User : IdentityUser
    {
        public virtual ICollection<ShopUser> ShopUsers { get; set; } = new HashSet<ShopUser>();
    }
}
