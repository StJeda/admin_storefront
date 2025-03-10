using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jeda.Storefront.Infrastructure.Configuration.Constants;
using Jeda.Storefront.Infrastructure.Entities;

namespace Jeda.Storefront.Infrastructure.Configuration;

internal class PartnerConfiguration : IEntityTypeConfiguration<PartnerViewEntity>
{
    public void Configure(EntityTypeBuilder<PartnerViewEntity> builder)
    {
        builder.ToTable(Tables.Partners);

        builder.HasKey(p => p.PartnerId);

        builder.Property(p => p.PartnerId).ValueGeneratedOnAdd();
    }

}
