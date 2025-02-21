using MudBlazor.Services;
using Portfolio.Shared.Services;
using Portfolio.Web.Components;
using Portfolio.Web.Services;
using Blazorise;
using Radzen;
using MudBlazor;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Configure services
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddRadzenComponents();
builder.Services.AddSingleton<AIService>();
// Register Blazorise services
builder.Services.AddBlazorise(options =>
{
    options.Immediate = true;
});

string? openAiKey = configuration["OpenAIKey"];

if (string.IsNullOrEmpty(openAiKey))
{
    throw new InvalidOperationException("OpenAIKey is not configured.");
}

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Register services, including controllers for API endpoints.
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Register the AI service
builder.Services.AddSingleton<AIService>();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration = new SnackbarConfiguration()
    {
        PositionClass = Defaults.Classes.Position.BottomRight,
        PreventDuplicates = false,
        NewestOnTop = false,
        ShowCloseIcon = true,
        VisibleStateDuration = 10000,
        HideTransitionDuration = 500,
        ShowTransitionDuration = 500,
    };
});
builder.Services.AddSingleton<HttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(Portfolio.Shared._Imports).Assembly,
        typeof(Portfolio.Web.Client._Imports).Assembly);

app.Run();
