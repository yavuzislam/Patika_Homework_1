namespace Customer_management.Services;

public class DbLogger : ILoggerService
{
    public void LogInfo(string message)
    {
        Console.WriteLine("[DbLogger] - " + message);
    }
}