using App.Repository.Entities.Concrete;
using App.Service.Dtos.HotelServiceDtos;
using App.Service.Dtos.HotelServiceDtos.Requests;
using App.Service.Dtos.RoomDtos;
using App.Service.Dtos.RoomDtos.Requests;
using App.Service.Dtos.StaffDtos;
using App.Service.Dtos.StaffDtos.Requests;
using App.Service.Dtos.SubscribeDtos;
using App.Service.Dtos.SubscribeDtos.Requests;
using App.Service.Dtos.TestimonialDtos;
using App.Service.Dtos.TestimonialDtos.Requests;
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
    }
}