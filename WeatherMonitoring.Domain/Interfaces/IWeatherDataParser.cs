using WeatherMonitoring.Domain.Entities;


namespace WeatherMonitoring.Domain.Interfaces;
public interface IWeatherDataParser
{
    WeatherData Parse(string rawData);
}