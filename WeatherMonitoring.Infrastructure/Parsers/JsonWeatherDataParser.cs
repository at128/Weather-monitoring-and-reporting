using WeatherMonitoring.Domain.Entities;
using WeatherMonitoring.Domain.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherMonitoring.Infrastructure.Parsers;

public class JsonWeatherDataParser  : IWeatherDataParser
{
    public WeatherData Parse(string rawData)
    {
        if (string.IsNullOrWhiteSpace(rawData))
        {
            throw new ArgumentException("Input data cannot be null or empty", nameof(rawData));
        }

        try
        {
            JObject jsonObject = JObject.Parse(rawData);
            string location = jsonObject["Location"]?.ToString() ?? throw new FormatException("Location field is missing or invalid");
            double temperature = jsonObject["Temperature"]?.Value<double>() ?? throw new FormatException("Temperature field is missing or invalid");
            double humidity = jsonObject["Humidity"]?.Value<double>() ?? throw new FormatException("Humidity field is missing or invalid");
            return new WeatherData(location, temperature, humidity);
        }
        catch (Exception ex)
        {
            throw new FormatException("Failed to parse weather data from JSON", ex);
        }
    }
}