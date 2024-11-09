using Microsoft.AspNetCore.Components;
using Puzzle_55.Client;
using Puzzle_55.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
		.AddInteractiveWebAssemblyComponents();

// configure an httpclient for use in the app with a baseaddress specified
builder.Services.AddScoped(sp => new HttpClient
{
	BaseAddress = new Uri(sp.GetRequiredService<NavigationManager>().Uri)
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
		.AddInteractiveWebAssemblyRenderMode()
		.AddAdditionalAssemblies(typeof(Puzzle_55.Client._Imports).Assembly);

app.MapGet("/api/weatherforecast", () =>
{

	var startDate = DateOnly.FromDateTime(DateTime.Now);
	var summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild",
		"Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

	var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
	{
		Date = startDate.AddDays(index),
		TemperatureC = Random.Shared.Next(-20, 55),
		Summary = summaries[Random.Shared.Next(summaries.Length)]
	}).ToArray();

	return forecasts;


});

app.Run();
