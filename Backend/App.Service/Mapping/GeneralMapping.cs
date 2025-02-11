using App.Repository.Dtos.HotelServiceDtos.Requests;
using App.Repository.Dtos.RoomDtos;
using App.Repository.Dtos.RoomDtos.Requests;
using App.Repository.Dtos.StaffDtos;
using App.Repository.Dtos.StaffDtos.Requests;
using App.Repository.Dtos.SubscribeDtos;
using App.Repository.Dtos.SubscribeDtos.Requests;
using App.Repository.Dtos.TestimonialDtos;
using App.Repository.Dtos.TestimonialDtos.Requests;
using App.Repository.Dtos.UserDtos.Requests;
using App.Repository.Dtos.UserDtos.Responses;
using App.Repository.Entities.Concrete;
using App.Service.Dtos.HotelServiceDtos;
using AutoMapper;

namespace App.Service.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<HotelService, CreateHotelServiceRequest>().ReverseMap();
        CreateMap<HotelService, UpdateHotelServiceRequest>().ReverseMap();
        CreateMap<HotelService, HotelServiceDto>().ReverseMap();

        CreateMap<Room, CreateRoomRequest>().ReverseMap();
        CreateMap<Room, UpdateRoomRequest>().ReverseMap();
        CreateMap<Room, RoomDto>().ReverseMap();

        CreateMap<Staff, CreateStaffRequest>().ReverseMap();
        CreateMap<Staff, UpdateStaffRequest>().ReverseMap();
        CreateMap<Staff, StaffDto>().ReverseMap();

        CreateMap<Subscribe, CreateSubscribeRequest>().ReverseMap();
        CreateMap<Subscribe, UpdateStaffRequest>().ReverseMap();
        CreateMap<Subscribe, SubscribeDto>().ReverseMap();

        CreateMap<Testimonial, CreateTestimonialRequest>().ReverseMap();
        CreateMap<Testimonial, UpdateTestimonialRequest>().ReverseMap();
        CreateMap<Testimonial, TestimonialDto>().ReverseMap();

        CreateMap<AppUser, CreateUserRequest>().ReverseMap();
        CreateMap<AppUser, CreateUserResponse>().ReverseMap();
    }
}