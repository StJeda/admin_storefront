using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jeda.Storefront.Infrastructure.Configuration.Constants;
using Jeda.Storefront.Infrastructure.Entities.Documents;

namespace Jeda.Storefront.Infrastructure.Configuration;

internal class DocumentLineConfiguration : IEntityTypeConfiguration<DocumentLineViewEntity>
{
    public void Configure(EntityTypeBuilder<DocumentLineViewEntity> builder)
    {
        builder.ToTable(Tables.DocumentLines);

        builder.HasKey(p => p.DocumentLineId);

        builder.Property(p => p.DocumentLineId).ValueGeneratedOnAdd();

        builder.HasIndex(d => d.DocumentId);
    }

}
