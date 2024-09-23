using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wishlist.Domain;

namespace Wishlist.Infrastructure.Persistence.EntityFramework.Configurations;

public class WishlistProductConfiguration : IEntityTypeConfiguration<WishlistProduct>
{
    public void Configure(EntityTypeBuilder<WishlistProduct> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserId).HasMaxLength(128);

        builder.HasOne(x => x.Product);
    }
}
