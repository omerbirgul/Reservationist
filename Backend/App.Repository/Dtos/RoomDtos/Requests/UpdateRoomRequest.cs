namespace App.Repository.Dtos.RoomDtos.Requests;

public record UpdateRoomRequest(
    string Description,
    string RoomNumber,
    string CoverImage,
    decimal Price,
    string Title,
    string BedCount,
    string BathCount,
    bool HasWifi);