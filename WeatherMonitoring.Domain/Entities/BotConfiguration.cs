namespace WeatherMonitoring.Domain.Entities;
public class BotConfiguration
{
    public string BotName{ get; private set; }
    public bool IsEnabled { get; private set; }
    public double Threshold { get; private set; }
    public string Message { get; private set; }

    public BotConfiguration(string botName,bool isEnabled, double threshold, string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentException("Message cannot be null or empty.", nameof(message));
        }
        BotName=botName;
        IsEnabled = isEnabled;
        Threshold = threshold;
        Message = message;
    }

}
