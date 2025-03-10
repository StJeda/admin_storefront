using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jeda.Storefront.Infrastructure.Configuration.Constants;
using Jeda.Storefront.Infrastructure.Entities.Documents;

namespace Jeda.Storefront.Infrastructure.Configuration;

internal class DocumentConfiguration : IEntityTypeConfiguration<DocumentViewEntity>
{
    public void Configure(EntityTypeBuilder<DocumentViewEntity> builder)
    {
        builder.ToTable(Tables.Documents);

        builder.HasKey(p => p.DocumentId);

        builder.Property(p => p.DocumentId).ValueGeneratedOnAdd();

        builder.HasIndex(d => d.ServiceId);
    }
}
