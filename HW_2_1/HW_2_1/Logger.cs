public class Logger
{
    private static Logger instance;
    private List<string> logs;

    private Logger()
    {
        logs = new List<string>();
    }

    public static Logger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }
    }

    public void LogError(string message)
    {
        string log = $"{DateTime.Now}: Error: {message}";
        Console.WriteLine(log);
        logs.Add(log);
    }

    public void LogInfo(string message)
    {
        string log = $"{DateTime.Now}: Info: {message}";
        Console.WriteLine(log);
        logs.Add(log);
    }

    public void LogWarning(string message)
    {
        string log = $"{DateTime.Now}: Warning: {message}";
        Console.WriteLine(log);
        logs.Add(log);
    }

    public string GetLogs()
    {
        return string.Join("\n", logs);
    }
}
