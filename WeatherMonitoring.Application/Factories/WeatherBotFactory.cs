using WeatherMonitoring.Domain.Bots;
using WeatherMonitoring.Domain.Interfaces;

namespace WeatherMonitoring.Application.Factories;

public class WeatherBotFactory
{
    public List<IWeatherObserver> GetWeatherBots(IConfigurationService configurationService)
    {
        if (configurationService == null)
            throw new ArgumentNullException(nameof(configurationService));

        var bots = new List<IWeatherObserver>();
        var configurations = configurationService.GetBotConfigurations();
        foreach (var config in configurations)
        {
            switch (config.Key)
            {
                case "RainBot":
                    bots.Add(new RainBot(config.Value));
                    break;
                case "SunBot":
                    bots.Add(new SunBot(config.Value));
                    break;
                case "SnowBot":
                    bots.Add(new SnowBot(config.Value));
                    break;
                default:
                    throw new InvalidOperationException($"Unknown bot type: {config.Value.BotName}");
            }
        }
        return bots;
        
    }
}