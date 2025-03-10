using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;

namespace Jeda.Storefront.Infrastructure.Interceptors;

internal class CachedQueryInterceptor(IMemoryCache cache) : DbCommandInterceptor
{
    private const int _cacheTimeout = 120;

    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        if (cache.TryGetValue(command.CommandText, out object? cachedResult))
        {
            DbDataReader cached = (DbDataReader)cachedResult!;
            return InterceptionResult<DbDataReader>.SuppressWithResult(cached);
        }

        var reader = base.ReaderExecuting(command, eventData, result).Result;
        cache.Set(command.CommandText, reader, TimeSpan.FromSeconds(_cacheTimeout));
        return InterceptionResult<DbDataReader>.SuppressWithResult(reader);
    }
}
