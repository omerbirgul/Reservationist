using App.Repository.Entities.Concrete;
using App.Service.Dtos.TestimonialDtos;
using App.Service.Dtos.TestimonialDtos.Requests;
using App.Service.Dtos.TestimonialDtos.Responses;
using App.Service.Services.GenericServices;

namespace App.Service.Services.TestimonialServices;

public interface ITestimonialService : IGenericService<
    CreateTestimonialRequest,
    UpdateTestimonialRequest,
    TestimonialDto,
    Testimonial>
{
    
}