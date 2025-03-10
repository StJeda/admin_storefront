using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jeda.Storefront.Infrastructure.Configuration.Constants;
using Jeda.Storefront.Infrastructure.Entities.Financial;

namespace Jeda.Storefront.Infrastructure.Configuration;

internal class FinancialRegisterConfiguration : IEntityTypeConfiguration<FinancialRegisterViewEntity>
{
    public void Configure(EntityTypeBuilder<FinancialRegisterViewEntity> builder)
    {
        builder.ToTable(Tables.FinancialRegisters);

        builder.HasKey(p => p.RegisterId);

        builder.Property(p => p.RegisterId).ValueGeneratedOnAdd();
    }

}
