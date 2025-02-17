namespace App.Repository.Dtos.RapidApiDtos;

public record GetTopMovieDto(string Url, string OriginalTitle, string Description, string PrimaryImage, DateTime ReleaseDate);