using App.Service.Mapping;
using App.Service.Services.RoomServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Service.Extensions;

public static class ServiceExtension
{
    public static void AddService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(GeneralMapping));

        services.AddScoped<IRoomService, RoomService>();
    }
}