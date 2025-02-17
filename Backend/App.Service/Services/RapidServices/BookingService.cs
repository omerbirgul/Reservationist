using System.Text.Json.Serialization;
using App.Repository.Dtos.RapidApiDtos;
using Newtonsoft.Json;

namespace App.Service.Services.RapidServices;

public class BookingService : IBookingService
{
    public async Task<ServiceResult<List<GetTopMovieDto>>> ReservationList()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://imdb236.p.rapidapi.com/imdb/top250-movies"),
            Headers =
            {
                { "x-rapidapi-key", "050e857a92msh109f6c54de584abp11074bjsne807ca4809f3" },
                { "x-rapidapi-host", "imdb236.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var movieListDto = new List<GetTopMovieDto>();
            movieListDto = JsonConvert.DeserializeObject<List<GetTopMovieDto>>(body);
            return ServiceResult<List<GetTopMovieDto>>.Success(movieListDto);
        }
    }
}