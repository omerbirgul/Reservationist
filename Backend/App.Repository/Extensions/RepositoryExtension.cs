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
using Microsoft.AspNetCore.Identity;
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


        services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = false;

                opt.Lockout.MaxFailedAccessAttempts = 3;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDbContext>();
        
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