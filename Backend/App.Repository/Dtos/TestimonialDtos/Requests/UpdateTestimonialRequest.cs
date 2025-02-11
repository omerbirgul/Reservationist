namespace App.Repository.Dtos.TestimonialDtos.Requests;

public record UpdateTestimonialRequest(string Description,
    string ClientFullName, string ClientImage);