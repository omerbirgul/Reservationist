namespace App.Service.Dtos.TestimonialDtos.Requests;

public record UpdateTestimonialRequest(string Description,
    string ClientFullName, string ClientImage);