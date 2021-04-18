using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleOrder.Infra.Data.Models;

namespace SimpleOrder.Infra.Data.Configurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price)
                .HasPrecision(18, 2)
                .IsRequired(true);

            builder.Property(x => x.Quantity)
                .IsRequired(true);

            builder.Property(x => x.ProductId)
                .IsRequired(true);
        }
    }
}
