using Microsoft.Data.SqlClient;

namespace Jeda.Storefront.Core.Options;

public abstract record SqlOptionsBase
{
    public required string Server { get; init; }
    public required string Database { get; init; }
    public int Timeout { get; init; } = 30;
    public int Retry { get; init; } = 3;

    public virtual string GetConnectionString()
    {
        SqlConnectionStringBuilder connectionStringBuilder = new()
        {
            DataSource = Server,
            InitialCatalog = Database,
            TrustServerCertificate = true
        };

        return connectionStringBuilder.ConnectionString;
    }
}
