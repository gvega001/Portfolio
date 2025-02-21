using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Portfolio.Shared.Services;
using Portfolio.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the Portfolio.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<HttpClient>();

await builder.Build().RunAsync();
