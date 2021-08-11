using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name).HasMaxLength(100).IsRequired();
            builder.Property(product => product.Description).HasMaxLength(200).IsRequired();
            builder.Property(product => product.Price).HasPrecision(10, 2);

            builder.HasOne(product => product.Category).WithMany(category => category.Products).HasForeignKey(product => product.CategoryId);
        }
    }
}
