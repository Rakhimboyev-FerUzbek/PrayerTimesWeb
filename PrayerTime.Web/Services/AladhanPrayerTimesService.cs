using System.Text.Json;
using System.Text.Json.Serialization;
using PrayerTime.Web.Dtos;

namespace PrayerTime.Web.Services;

public class AladhanPrayerTimesService(
    HttpClient httpClient, 
    ILogger<ApiResponse> logger) : IAladhanPrayerTimesService
{
    private string apiUrl = "https://api.aladhan.com/v1/timings/";

    public async Task<ApiResponse> GetPrayerTimes(
        string selectedDate, 
        double latitude, 
        double longitude, 
        CancellationToken abortionToken = default)
    {
        logger.LogInformation("AladhanPrayerTimesServicega request keldi: {time}, {latitude}, {longitude}",
             selectedDate, latitude, longitude);

        var requestUrl = apiUrl + $"{selectedDate}?latitude={latitude}&longitude={longitude}&timezonestring=Asia%2FTashkent";
        var response = await httpClient.GetAsync(requestUrl, abortionToken);
        logger.LogInformation("{requestUrl}", requestUrl);
        
        if (response.IsSuccessStatusCode is false)
        {
            response = await httpClient.GetAsync(requestUrl, abortionToken);
            logger.LogInformation("Second Request status code : {statusCode}", response.IsSuccessStatusCode);
        }
        logger.LogInformation("First Request status code : {statusCode}", response.IsSuccessStatusCode);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, 
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull 
        };

        var json = await response.Content.ReadAsStringAsync(abortionToken);
        return JsonSerializer.Deserialize<ApiResponse>(json, options)!;
    }
}