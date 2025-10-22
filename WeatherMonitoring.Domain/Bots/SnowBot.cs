using WeatherMonitoring.Domain.Entities;

namespace WeatherMonitoring.Domain.Bots;

public class SnowBot : WeatherBot
{
    public SnowBot(BotConfiguration config) : base(config)
    {
    }
    public override bool ShouldActivate(WeatherData weatherData)
    {
        return weatherData.Temperature < Configuration.Threshold;
    }
}