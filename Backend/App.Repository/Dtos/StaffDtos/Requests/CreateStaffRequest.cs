namespace App.Repository.Dtos.StaffDtos.Requests;

public record CreateStaffRequest(string Image, string FullName,
    string Title, Uri FacebookUri, Uri TwitterUri, Uri InstagramUri);