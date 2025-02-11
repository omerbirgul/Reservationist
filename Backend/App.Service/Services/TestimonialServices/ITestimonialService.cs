using App.Repository.Dtos.TestimonialDtos;
using App.Repository.Dtos.TestimonialDtos.Requests;
using App.Repository.Entities.Concrete;
using App.Service.Services.GenericServices;

namespace App.Service.Services.TestimonialServices;

public interface ITestimonialService : IGenericService<
    CreateTestimonialRequest,
    UpdateTestimonialRequest,
    TestimonialDto,
    Testimonial>
{
    
}