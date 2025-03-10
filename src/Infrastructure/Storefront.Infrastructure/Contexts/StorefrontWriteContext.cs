using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Jeda.Storefront.Core.Options;
using Jeda.Storefront.Infrastructure.Configuration;
using Jeda.Storefront.Infrastructure.Entities;
using Jeda.Storefront.Infrastructure.Entities.Documents;
using Jeda.Storefront.Infrastructure.Entities.Financial;

namespace Jeda.Storefront.Infrastructure.Contexts;

public class StorefrontWriteContext : DbContext
{
    public virtual DbSet<DocumentViewEntity> Documents { get; set; }
    public virtual DbSet<DocumentLineViewEntity> DocumentLines { get; set; }
    public virtual DbSet<FinancialEntryViewEntity> FinancialEntries { get; set; }
    public virtual DbSet<FinancialRegisterViewEntity> FinancialRegisters { get; set; }
    public virtual DbSet<TradePointViewEntity> TradePoints { get; set; }
    public virtual DbSet<PartnerViewEntity> Partners { get; set; }

    private readonly string _connection;
    private readonly int _timeout;
    private readonly int _retry;


    public StorefrontWriteContext(DbContextOptions<StorefrontWriteContext> dbContextOptions,
        IOptions<StorefrontSqlOptions> options) : base(dbContextOptions)
    {
        StorefrontSqlOptions sqlOptions = options.Value;
        _connection = sqlOptions.GetConnectionString();
        _timeout = sqlOptions.Timeout;
        _retry = sqlOptions.Retry;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        optionsBuilder.UseSqlServer(_connection, o =>
        {
            o.CommandTimeout(_timeout);
            o.EnableRetryOnFailure(_retry);
            o.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DocumentConfiguration());
        modelBuilder.ApplyConfiguration(new DocumentLineConfiguration());
        modelBuilder.ApplyConfiguration(new FinancialRegisterConfiguration());
        modelBuilder.ApplyConfiguration(new FinancialEntryConfiguration());
        modelBuilder.ApplyConfiguration(new PartnerConfiguration());
        modelBuilder.ApplyConfiguration(new TradePointConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
