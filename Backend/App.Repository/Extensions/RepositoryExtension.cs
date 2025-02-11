using App.Repository.Database;
using App.Repository.Entities.Concrete;
using App.Repository.GenericRepositories;
using App.Repository.GenericRepositories.HotelServiceRepositories;
using App.Repository.GenericRepositories.RoomRepositories;
using App.Repository.GenericRepositories.StaffRepositories;
using App.Repository.GenericRepositories.SubscribeRepositories;
using App.Repository.GenericRepositories.TestimonialRepositories;
using App.Repository.Interceptors;
using App.Repository.UnitOfWork;
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

            opt.AddInterceptors(new AuditDbContextInterceptors());
        });
        
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IHotelServiceRepository, HotelServiceRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<ISubscribeRepository, SubscribeRepository>();
        services.AddScoped<ITestimonialRepository, TestimonialRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        return services;
    }
    
}