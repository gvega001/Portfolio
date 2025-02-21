using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using Portfolio.Shared.Models;


namespace Portfolio.Shared.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double> GetCurrentTemperatureAsync()
        {
            // Example: for lat=35, long=-97
            // If you need a different lat/long, adapt the URL
            string url = "https://api.open-meteo.com/v1/forecast?latitude=35&longitude=-97&hourly=temperature_2m";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                // Return NaN or throw an exception as needed
                return double.NaN;
            }

            var json = await response.Content.ReadAsStringAsync();

            // Deserialize JSON into our model
            var data = JsonSerializer.Deserialize<OpenMeteoResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (data?.Hourly?.Temperature2m == null || data.Hourly.Temperature2m.Count == 0)
            {
                return double.NaN; // or throw if you prefer
            }

            // For simplicity, let's just grab the first hour's temperature in °C
            // (the array is a timeline of hourly forecasts)
            double currentTempC = data.Hourly.Temperature2m[0];

            return currentTempC;
        }
    }
}
