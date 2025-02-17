using System.Text.Json.Serialization;

namespace App.Repository.Dtos.RapidApiDtos;

public record LocationIdRoot(
    bool status,
    string message,
    long timestamp,
    [property: JsonPropertyName("data")] List<LocationIdData> data
);

public record LocationIdData(
    string dest_id,
    string search_type
);

public record LocationIdDto(string id);