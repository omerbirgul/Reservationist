namespace App.Service.Dtos.RoomDtos;

public record RoomDto
    (
        int Id,
        string RoomNumber ,
        string CoverImage ,
        decimal Price,
        string Title,
        string BedCount,
        string BathCount,
        bool HasWifi
    );
