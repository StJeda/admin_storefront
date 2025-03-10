using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jeda.Storefront.Infrastructure.Configuration.Constants;
using Jeda.Storefront.Infrastructure.Entities;

namespace Jeda.Storefront.Infrastructure.Configuration;

internal class TradePointConfiguration : IEntityTypeConfiguration<TradePointViewEntity>
{
    public void Configure(EntityTypeBuilder<TradePointViewEntity> builder)
    {
        builder.ToTable(Tables.TradePoints);

        builder.HasKey(p => p.TradePointId);

        builder.Property(p => p.TradePointId).ValueGeneratedOnAdd();
    }

}
