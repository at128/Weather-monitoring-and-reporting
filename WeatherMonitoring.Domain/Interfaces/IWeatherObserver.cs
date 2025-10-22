using WeatherMonitoring.Domain.Entities;

namespace WeatherMonitoring.Domain.Interfaces;
public interface IWeatherObserver
{
    void Update(WeatherData weatherData);
}