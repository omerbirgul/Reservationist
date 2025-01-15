using App.Repository.Database;
using App.Repository.Entities.Concrete;

namespace App.Repository.GenericRepositories.TestimonialRepositories;

public class TestimonialRepository : GenericRepository<Testimonial>, ITestimonialRepository
{
    public TestimonialRepository(AppDbContext context) : base(context)
    {
    }
}