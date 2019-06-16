using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NearbyShop.API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            string thumbnailUrl = "https://cdn.xl.thumbs.canstockphoto.com/street-store-building-facade-small-shop-front-shopping-design-detailed-illustration-vector-vector-clipart_csp42332205.jpg";
            builder.Entity<Shop>().HasData(
                new Shop { Id = 1, Name = "Shop Name 1", Distance = 5, ThumbnailUrl = thumbnailUrl },
                new Shop { Id = 2, Name = "Shop Name 2", Distance = 3, ThumbnailUrl = thumbnailUrl },
                new Shop { Id = 3, Name = "Shop Name 3", Distance = 10, ThumbnailUrl = thumbnailUrl },
                new Shop { Id = 4, Name = "Shop Name 4", Distance = 7, ThumbnailUrl = thumbnailUrl },
                new Shop { Id = 5, Name = "Shop Name 5", Distance = 50, ThumbnailUrl = thumbnailUrl },
                new Shop { Id = 6, Name = "Shop Name 5", Distance = 30, ThumbnailUrl = thumbnailUrl },
                new Shop { Id = 7, Name = "Shop Name 5", Distance = 43, ThumbnailUrl = thumbnailUrl },
                new Shop { Id = 8, Name = "Shop Name 5", Distance = 2, ThumbnailUrl = thumbnailUrl }
                );
            base.OnModelCreating(builder);
        }
    }
}
