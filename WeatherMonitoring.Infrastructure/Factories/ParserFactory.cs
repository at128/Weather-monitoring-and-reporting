using WeatherMonitoring.Domain.Interfaces;
using WeatherMonitoring.Infrastructure.Parsers;

namespace WeatherMonitoring.Infrastructure.Factories;

public class ParserFactory
{
    public IWeatherDataParser GetParser(string rawData)
    {
        if (string.IsNullOrWhiteSpace(rawData))
            throw new ArgumentException("Raw data cannot be empty", nameof(rawData));

        string trimmedData = rawData.Trim();

        if (trimmedData.StartsWith("{"))
            return new JsonWeatherDataParser();

        if (trimmedData.StartsWith("<"))
            return new XmlWeatherDataParser();

        throw new InvalidOperationException(
            "Unknown data format. Supported formats: JSON (starts with '{'), XML (starts with '<')");
    }
}