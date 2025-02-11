namespace App.Repository.Dtos.TestimonialDtos.Requests;

public record CreateTestimonialRequest(string Description,
    string ClientFullName, string ClientImage);