using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using Jeda.Storefront.Core.Options;
using Jeda.Storefront.Infrastructure.Configuration;
using Jeda.Storefront.Infrastructure.Entities;
using Jeda.Storefront.Infrastructure.Entities.Documents;
using Jeda.Storefront.Infrastructure.Entities.Financial;

namespace Jeda.Storefront.Infrastructure.Contexts;

public class StorefrontReadContext : DbContext
{
    public virtual DbSet<DocumentViewEntity> Documents { get; set; }
    public virtual DbSet<DocumentLineViewEntity> DocumentLines { get; set; }
    public virtual DbSet<FinancialEntryViewEntity> FinancialEntries { get; set; }
    public virtual DbSet<FinancialRegisterViewEntity> FinancialRegisters { get; set; }
    public virtual DbSet<TradePointViewEntity> TradePoints { get; set; }
    public virtual DbSet<PartnerViewEntity> Partners { get; set; }

    private readonly IDbCommandInterceptor _interceptor;
    private readonly string _connection;
    private readonly int _timeout;
    private readonly int _retry;
    

    public StorefrontReadContext(DbContextOptions<StorefrontReadContext> dbContextOptions, 
        IOptions<StorefrontSqlOptions> options, 
        IDbCommandInterceptor interceptor) : base(dbContextOptions)
    {
        StorefrontSqlOptions sqlOptions = options.Value;
        _connection = sqlOptions.GetConnectionString();
        _interceptor = interceptor;
        _timeout = sqlOptions.Timeout;
        _retry = sqlOptions.Retry;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        optionsBuilder.UseSqlServer(_connection, o =>
        {
            o.CommandTimeout(_timeout);
            o.EnableRetryOnFailure(_retry);
            o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        }).AddInterceptors(_interceptor);
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
