namespace App.Service.Dtos.RoomDtos.Requests;

public record CreateRoomRequest(
    string RoomNumber,
    string CoverImage,
    decimal Price,
    string Title,
    string BedCount,
    string BathCount,
    bool HasWifi);
