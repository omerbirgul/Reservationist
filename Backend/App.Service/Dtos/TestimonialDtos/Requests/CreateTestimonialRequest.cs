namespace App.Service.Dtos.TestimonialDtos.Requests;

public record CreateTestimonialRequest(string Description,
    string ClientFullName, string ClientImage);