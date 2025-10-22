using WeatherMonitoring.Domain.Entities;
using WeatherMonitoring.Domain.Interfaces;

namespace WeatherMonitoring.Application.Services;

public class WeatherMonitoringService
{
    private readonly List<IWeatherObserver> _observers;
    private readonly IWeatherDataParser _parser;
    public WeatherMonitoringService(List<IWeatherObserver> observers,IWeatherDataParser weatherDataParser)
    {
        _observers = observers ?? throw new ArgumentNullException(nameof(observers));
        _parser = weatherDataParser ?? throw new ArgumentNullException(nameof(weatherDataParser));
    }

    public void ProcessWeatherData(string rawData)
    {
        if(string.IsNullOrWhiteSpace(rawData))
        {
            throw new ArgumentException("Raw data cannot be null or empty", nameof(rawData));
        }
        var weatherData = _parser.Parse(rawData);
        NotifyObservers(weatherData);
    }

    private void NotifyObservers(WeatherData weatherData)
    {
        foreach (var observer in _observers)
        {
            observer.Update(weatherData);
        }
    }
}