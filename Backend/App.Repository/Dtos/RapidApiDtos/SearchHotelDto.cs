namespace App.Repository.Dtos.RapidApiDtos;

public record HotelRootObject(
    bool status,
    string message,
    long timestamp,
    HotelData data
);

public record HotelData(
    List<Hotel> hotels
);

public record Hotel(
    int hotel_id,
    string accessibilityLabel,
    Property property
);
public record Property(
      string name,
      double reviewScore,
      string checkinDate,
      string checkoutDate
  );




public record SearchHotelDto(string name, string arrival, string departure, double reviewScore);
