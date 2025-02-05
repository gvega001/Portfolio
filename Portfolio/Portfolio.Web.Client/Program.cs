using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Portfolio.Shared.Services;
using Portfolio.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the Portfolio.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
