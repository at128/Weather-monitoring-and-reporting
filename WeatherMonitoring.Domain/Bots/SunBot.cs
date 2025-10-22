using WeatherMonitoring.Domain.Entities;

namespace WeatherMonitoring.Domain.Bots;

public class SunBot : WeatherBot
{
    public SunBot(BotConfiguration config) : base(config)
    {
    }

    public override bool ShouldActivate(WeatherData weatherData)
    {
        return weatherData.Temperature > Configuration.Threshold;
    }
}