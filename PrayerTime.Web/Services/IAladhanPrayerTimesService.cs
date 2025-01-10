using PrayerTime.Web.Dtos;

namespace PrayerTime.Web.Services;

public interface IAladhanPrayerTimesService
{
    public Task<ApiResponse> GetPrayerTimes(
        string selectedDate, 
        double latitude, 
        double longitude, 
        CancellationToken abortionToken = default);
}