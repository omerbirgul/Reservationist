namespace App.Service.Dtos.StaffDtos;

public record StaffDto(int Id, string Image, string FullName,
    string Title, Uri FacebookUri, Uri TwitterUri, Uri InstagramUri);