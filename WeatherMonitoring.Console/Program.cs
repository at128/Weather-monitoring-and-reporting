using WeatherMonitoring.Application.Factories;
using WeatherMonitoring.Application.Services;
using WeatherMonitoring.Infrastructure.Configuration;
using WeatherMonitoring.Infrastructure.Factories;

var configService = new JsonConfigurationService("config.json");
var weatherBotFactory = new WeatherBotFactory();
var weatherBots = weatherBotFactory.GetWeatherBots(configService);
var parserFactory = new ParserFactory();

while (true)
{
    Console.WriteLine("Enter weather data:");
    string input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        break;
    }
    try
    {
        var parser = parserFactory.GetParser(input);
        var weatherService = new WeatherMonitoringService(weatherBots, parser);
        weatherService.ProcessWeatherData(input);
    }
    catch (FormatException ex)
    {
        Console.WriteLine($"Error processing weather data: {ex.Message}");
    }
}