using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PrayerTime.Web.Dtos;
using PrayerTime.Web.Services;

namespace PrayerTime.Web.Pages;

public partial class PrayerTimes
{
    [Inject] private ILogger<PrayerTimes> Logger { get; set; } = default!;
    [Inject] private IAladhanPrayerTimesService PrayerTimesService { get; set; } = default!;
    [Inject] private IJSRuntime JSRuntime { get; set ;} = default!;

    private ApiResponse? data = default!;

    protected override async Task OnInitializedAsync()
    {
        var location = await JSRuntime.InvokeAsync<Location>("getUserLocation");
        data = await PrayerTimesService
            .GetPrayerTimes(DateTime.Now.ToString("dd-MM-yyyy"), location.Latitude!, location.Longitude!);
    }
}