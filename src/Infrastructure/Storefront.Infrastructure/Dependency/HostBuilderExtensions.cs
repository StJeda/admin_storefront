using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Jeda.Storefront.Core.Options;
using Jeda.Storefront.Infrastructure.Contexts;
using Jeda.Storefront.Infrastructure.Interceptors;

namespace Jeda.Storefront.Infrastructure.Dependency
{
    public static class HostBuilderExtensions
    {
        public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder)
        {
            IServiceCollection services = builder.Services;
            IConfiguration configuration = builder.Configuration;

            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<IDbCommandInterceptor, CachedQueryInterceptor>();

            services.Configure<StorefrontSqlOptions>(configuration.GetSection(StorefrontSqlOptions.SectionName));
            services.AddDbContext<StorefrontReadContext>();
            services.AddDbContext<StorefrontWriteContext>();

            return builder;
        }
    }

}