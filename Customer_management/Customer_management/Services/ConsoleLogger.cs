namespace Customer_management.Services;

public class ConsoleLogger : ILoggerService
{
    public void LogInfo(string message)
    {
        Console.WriteLine("[ConsoleLogger] - " + message);
    }
}