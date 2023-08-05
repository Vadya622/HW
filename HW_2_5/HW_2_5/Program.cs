namespace HW_2_5
{
    using System;
    using System.IO;

    public enum LogType
    {
        Error,
        Info,
        Warning
    }

    public class Logger
    {
        public static void Log(LogType logType, string message)
        {
            string logTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt");
            string logTypeStr = logType.ToString();
            Console.WriteLine($"{logTime}: {logTypeStr}: {message}");
        }
    }

    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }

    public class Actions
    {
        public void Method1()
        {
            Logger.Log(LogType.Info, "Метод запуска: Method1");
        }

        public void Method2()
        {
            try
            {
                throw new BusinessException("Пропущенная логика в методе");
            }
            catch (BusinessException ex)
            {
                Logger.Log(LogType.Warning, $"Action got this custom Exception: {ex.Message}");
            }
        }

        public void Method3()
        {
            try
            {
                throw new Exception("Я нарушил логику");
            }
            catch (Exception ex)
            {
                Logger.Log(LogType.Error, $"Действие не выполнено по причине: {ex}");
            }
        }
    }

    public class FileService
    {
        private const string logDirectory = "logs";

        public static void LogToFile(string logMessage)
        {
            string logTime = DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss_fff_tt");
            string logFileName = $"{logTime}.txt";

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            string filePath = Path.Combine(logDirectory, logFileName);

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(logMessage);
            }

            // Check and delete the oldest log file if there are more than 3 files.
            string[] logFiles = Directory.GetFiles(logDirectory, "*.txt");
            if (logFiles.Length > 3)
            {
                Array.Sort(logFiles);
                File.Delete(logFiles[0]);
            }
        }
    }

    public class App
    {
        public static void Run()
        {
            Actions actions = new Actions();
            Random random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                int randomAction = random.Next(1, 4);
                try
                {
                    switch (randomAction)
                    {
                        case 1:
                            actions.Method1();
                            break;
                        case 2:
                            actions.Method2();
                            break;
                        case 3:
                            actions.Method3();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    FileService.LogToFile($"Exception occurred: {ex}");
                }
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            App.Run();
        }
    }

}