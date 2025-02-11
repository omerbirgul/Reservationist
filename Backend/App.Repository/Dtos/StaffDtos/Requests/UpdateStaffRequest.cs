namespace App.Repository.Dtos.StaffDtos.Requests;

public record UpdateStaffRequest(string Image, string FullName,
        string Title, Uri FacebookUri, Uri TwitterUri, Uri InstagramUri);