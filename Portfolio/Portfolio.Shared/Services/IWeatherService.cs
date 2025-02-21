namespace Portfolio.Shared.Services
{
    public interface IWeatherService
    {
        Task<double> GetCurrentTemperatureAsync();
    }
}
