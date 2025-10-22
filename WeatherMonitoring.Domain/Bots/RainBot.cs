using WeatherMonitoring.Domain.Entities;

namespace WeatherMonitoring.Domain.Bots;

public class RainBot : WeatherBot
{
    public RainBot(BotConfiguration config) : base(config)
    {
    }

    

    public override bool ShouldActivate(WeatherData weatherData)
    {
        return weatherData.Humidity > Configuration.Threshold;
    }
}