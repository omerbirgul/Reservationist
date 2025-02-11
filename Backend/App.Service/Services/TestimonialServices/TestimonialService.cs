using App.Repository.Dtos.TestimonialDtos;
using App.Repository.Dtos.TestimonialDtos.Requests;
using App.Repository.Entities.Concrete;
using App.Repository.GenericRepositories;
using App.Repository.UnitOfWork;
using App.Service.Services.GenericServices;
using AutoMapper;

namespace App.Service.Services.TestimonialServices;

public class TestimonialService : GenericService<
    CreateTestimonialRequest,
    UpdateTestimonialRequest,
    TestimonialDto,
    Testimonial>, ITestimonialService

{
    public TestimonialService(IGenericRepository<Testimonial> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) 
        : base(genericRepository, mapper, unitOfWork)
    {
    }
}