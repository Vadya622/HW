namespace HW_2_1 {
    using System;
    using System.IO;

    public enum LogType
    {
        Info,
        Warning,
        Error
    }

    public class Logger
    {
        private static Logger instance;

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                    instance = new Logger();
                return instance;
            }
        }

        private Logger() { }

        public void Log(LogType type, string message)
        {
            string logTypeStr = type switch
            {
                LogType.Info => "Info",
                LogType.Warning => "Warning",
                LogType.Error => "Error",
                _ => "Unknown"
            };

            string logTime = DateTime.Now.ToString("HH:mm:ss");
            string logEntry = $"{logTime}: {logTypeStr}: {message}";
            Console.WriteLine(logEntry);
        }
    }

    public class Result
    {
        public bool Status { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Actions
    {
        private Logger logger = Logger.Instance;

        public Result Method1()
        {
            logger.Log(LogType.Info, "Метод запуска: Method1");
            return new Result { Status = true };
        }

        public Result Method2()
        {
            logger.Log(LogType.Warning, "Пропущенная логика в методе: Method2");
            return new Result { Status = true };
        }

        public Result Method3()
        {
            logger.Log(LogType.Error, "Я нарушил логику");
            return new Result { Status = false, ErrorMessage = "Я нарушил логику" };
        }
    }

    public class Starter
    {
        public void Run()
        {
            Actions actions = new Actions();
            string logText = "";

            for (int i = 0; i < 100; i++)
            {
                int randomAction = new Random().Next(1, 4);

                Result result;
                switch (randomAction)
                {
                    case 1:
                        result = actions.Method1();
                        break;
                    case 2:
                        result = actions.Method2();
                        break;
                    case 3:
                        result = actions.Method3();
                        break;
                    default:
                        result = new Result { Status = false, ErrorMessage = "Недопустимое действие" };
                        break;
                }

                if (!result.Status)
                {
                    Logger.Instance.Log(LogType.Error, $"Действие не выполнено по причине: {result.ErrorMessage}");
                }

                logText += $"{DateTime.Now}: {result.Status}: {result.ErrorMessage}\n";
            }

            File.WriteAllText("log.txt", logText);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Starter starter = new Starter();
            starter.Run();
        }
    }

}