using Microsoft.EntityFrameworkCore;
using Wishlist.Domain;

namespace Wishlist.Infrastructure.Persistence.EntityFramework;

public class WishlistDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<WishlistProduct> Wishlists { get; set; }
}
