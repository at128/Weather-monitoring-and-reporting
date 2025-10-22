namespace WeatherMonitoring.Domain.Interfaces;

using WeatherMonitoring.Domain.Entities;
public interface IConfigurationService
{
    Dictionary<string,BotConfiguration> GetBotConfigurations();
}