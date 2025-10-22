using WeatherMonitoring.Domain.Entities;
using WeatherMonitoring.Domain.Interfaces;
using System.Xml.Linq;

namespace WeatherMonitoring.Infrastructure.Parsers;

public class XmlWeatherDataParser : IWeatherDataParser
{
    public WeatherData Parse(string rawData)
    {
        if (string.IsNullOrWhiteSpace(rawData))
        {
            throw new ArgumentException("Input data cannot be null or empty", nameof(rawData));
        }

        try
        {
            XDocument xmlDoc = XDocument.Parse(rawData);

            XElement root = xmlDoc.Root;
            string location = root.Element("Location")?.Value ?? throw new FormatException("Location field is missing or invalid");
            string temperatureStr = root.Element("Temperature")?.Value ?? throw new FormatException("Temperature field is missing or invalid");
            string humidityStr = root.Element("Humidity")?.Value ?? throw new FormatException("Humidity field is missing or invalid");
            double temperature = double.Parse(temperatureStr);
            double humidity = double.Parse(humidityStr);
            return new WeatherData(location, temperature, humidity);
        }
        catch (Exception ex)
        {
            throw new FormatException("Failed to parse weather data from XML", ex);
        }
    }
}