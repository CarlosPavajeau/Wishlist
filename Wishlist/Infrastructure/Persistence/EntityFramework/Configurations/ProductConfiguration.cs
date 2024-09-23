using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wishlist.Domain;

namespace Wishlist.Infrastructure.Persistence.EntityFramework.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(128);
        builder.Property(x => x.Description).HasMaxLength(256);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Products);
    }
}
