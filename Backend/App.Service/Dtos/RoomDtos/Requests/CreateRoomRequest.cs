namespace App.Service.Dtos.RoomDtos.Requests;

public record CreateRoomRequest(
    string Description,
    string RoomNumber,
    string CoverImage,
    decimal Price,
    string Title,
    string BedCount,
    string BathCount,
    bool HasWifi);
