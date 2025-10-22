using WeatherMonitoring.Domain.Entities;
using WeatherMonitoring.Domain.Interfaces;

namespace WeatherMonitoring.Domain.Bots;

public abstract class WeatherBot:IWeatherObserver
{
    protected BotConfiguration Configuration  { get; }
    public bool IsActivated { get; protected set; } = false;

    public WeatherBot(BotConfiguration config)
    {
        Configuration  = config?? throw new ArgumentNullException(nameof(config));
    }

    public void Update(WeatherData weatherData)
    {
        if(weatherData==null)
            throw new ArgumentNullException(nameof(weatherData));
        if (!Configuration.IsEnabled) return;

        if (ShouldActivate(weatherData))
        {
            IsActivated = true;
            Console.WriteLine($"{Configuration.BotName} activated!");
            Console.WriteLine($"{Configuration.BotName}: \"{Configuration.Message}\"");
        }
        else
        {
            IsActivated = false;
        }
    }
    public abstract bool ShouldActivate(WeatherData weatherData);
}