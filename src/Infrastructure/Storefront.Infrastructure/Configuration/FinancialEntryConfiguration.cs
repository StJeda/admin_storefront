using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jeda.Storefront.Infrastructure.Configuration.Constants;
using Jeda.Storefront.Infrastructure.Entities.Financial;

namespace Jeda.Storefront.Infrastructure.Configuration;

internal class FinancialEntryConfiguration : IEntityTypeConfiguration<FinancialEntryViewEntity>
{
    public void Configure(EntityTypeBuilder<FinancialEntryViewEntity> builder)
    {
        builder.ToTable(Tables.FinancialEntries);

        builder.HasKey(p => p.EntryId);

        builder.Property(p => p.EntryId).ValueGeneratedOnAdd();
    }

}
