using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleOrder.Infra.Data.Models;

namespace SimpleOrder.Infra.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(100);            

            builder
                .Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(255);

            builder.Property(x => x.Price)
                .HasPrecision(18, 2)
                .IsRequired(true);

            builder
                .Property(x => x.CreationDate)
                .IsRequired(true);
        }
    }
}
