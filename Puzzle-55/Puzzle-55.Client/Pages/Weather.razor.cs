using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Puzzle_55.Client.Pages;
public partial class Weather
{

	private WeatherForecast[]? forecasts;

	[Inject]
	public HttpClient client { get; set; }

	protected override async Task OnInitializedAsync()
	{
		// Simulate asynchronous loading to demonstrate a loading indicator
		await Task.Delay(500);

		forecasts = await client.GetFromJsonAsync<WeatherForecast[]>("api/weatherforecast");

	}

}
