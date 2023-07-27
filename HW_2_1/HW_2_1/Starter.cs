using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_1
{
    public class Starter
    {
        private Actions actions;
        private Logger logger;

        public Starter()
        {
            actions = new Actions();
            logger = Logger.Instance;
        }

        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                int randomNumber = new Random().Next(1, 4);

                Result result;
                switch (randomNumber)
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
                        result = new Result { Status = false, ErrorMessage = "Некорректный номер метода" };
                        break;
                }

                if (!result.Status)
                {
                    logger.LogError($"Действие не выполнено по причине: {result.ErrorMessage}");
                }
            }

            string allLogs = logger.GetLogs();
            File.WriteAllText("log.txt", allLogs);
        }
    }

}
