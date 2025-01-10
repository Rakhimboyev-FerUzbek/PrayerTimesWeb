namespace PrayerTime.Web.Dtos;

public class Timings
{
    public TimeSpan Fajr { get; set; }
    public TimeSpan Sunrise { get; set; }
    public TimeSpan Dhuhr { get; set; }
    public TimeSpan Asr { get; set; }
    public TimeSpan Maghrib { get; set; }
    public TimeSpan Isha { get; set; }
}
