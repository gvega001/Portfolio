using MudBlazor.Services;
using Portfolio.Shared.Services;
using Portfolio.Web.Components;
using Portfolio.Web.Services;
using MudBlazor; // Add this using directive
using Blazorise;
using Radzen;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddSingleton<WeatherService>();
builder.Services.AddSingleton<FormFactor>();
builder.Services.AddRadzenComponents();
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
builder.Services.AddControllers();  // <-- Required for API controllers

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Add device-specific services used by the Portfolio.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

// Register the AI service
//builder.Services.AddSingleton<AIService>();

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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
