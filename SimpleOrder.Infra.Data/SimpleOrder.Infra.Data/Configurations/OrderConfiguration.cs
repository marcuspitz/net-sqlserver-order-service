using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleOrder.Infra.Data.Models;

namespace SimpleOrder.Infra.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreationDate)
                .IsRequired(true);

            var navigation = builder.Metadata.FindNavigation(nameof(Order.Products));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
