using App.Service.Mapping;
using App.Service.Services.GenericServices;
using App.Service.Services.HotelServices;
using App.Service.Services.RapidServices;
using App.Service.Services.RoomServices;
using App.Service.Services.StaffServices;
using App.Service.Services.SubscribeServices;
using App.Service.Services.TestimonialServices;
using App.Service.Services.UserServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Service.Extensions;

public static class ServiceExtension
{
    public static void AddService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(GeneralMapping));

        services.AddScoped(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IStaffService, StaffService>();
        services.AddScoped<ISubscribeService, SubscribeService>();
        services.AddScoped<ITestimonialService, TestimonialService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IUserService, UserService>();
    }
}