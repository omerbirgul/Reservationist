using App.Repository.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Repository.Extensions;

public static class RepositoryExtension
{

    public static IServiceCollection AddRepositoryExtension(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            var connectionString = configuration
                .GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();

            opt.UseSqlServer(connectionString!.DefaultConnection, sqlServerOptionsAction =>
            {
                sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
            });
        });
        return services;
    }
    
}