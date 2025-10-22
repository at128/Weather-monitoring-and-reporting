namespace WeatherMonitoring.Domain.Entities;

public class WeatherData
{
    public string Location { get; private set; }
    public double Temperature { get; private set; }
    public double Humidity { get; private set; }

    public WeatherData(string location, double temperature, double humidity)
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            throw new ArgumentException("Location cannot be null or empty.", nameof(location));
        }
        if (humidity < 0 || humidity > 100)
            throw new ArgumentOutOfRangeException(nameof(humidity), "Humidity must be between 0 and 100.");


        Location = location;
        Temperature = temperature;
        Humidity = humidity;
    }
}