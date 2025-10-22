using Newtonsoft.Json.Linq;
using WeatherMonitoring.Domain.Entities;
using WeatherMonitoring.Domain.Interfaces;
using System.IO;
namespace WeatherMonitoring.Infrastructure.Configuration;

public class JsonConfigurationService : IConfigurationService
{
    private readonly string _filePath;
    public JsonConfigurationService(string filePath)
    {
        if(string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
        }
        _filePath = filePath;
    }

    public Dictionary<string, BotConfiguration> GetBotConfigurations()
    {
        if(!System.IO.File.Exists(_filePath))
        {
            throw new FileNotFoundException("Configuration file not found.", _filePath);
        }
        string jsonContent = File.ReadAllText(_filePath);
        var botConfigs = new Dictionary<string, BotConfiguration>();
        try
        {
            JObject jsonObject = JObject.Parse(jsonContent);
            foreach (var bot in jsonObject)
            {
                string botName = bot.Key;
                JObject botDetails = (JObject)bot.Value;
                bool isEnabled = botDetails["enabled"]?.Value<bool>() ?? throw new FormatException($"IsEnabled field is missing or invalid for bot {botName}");
                double threshold = botDetails["humidityThreshold"]?.Value<double>() ?? botDetails["temperatureThreshold"]?.Value<double>() ?? throw new FormatException($"Threshold field is missing or invalid for bot {botName}");
                string message = botDetails["message"]?.Value<string>() ?? throw new FormatException($"Message field is missing or invalid for bot {botName}");
                var botConfig = new BotConfiguration(botName,isEnabled, threshold, message);
                botConfigs.Add(botName, botConfig);
            }
        }
        catch (Exception ex)
        {
            throw new FormatException("Failed to parse bot configurations from JSON", ex);
        }
        return botConfigs;
    }
}