using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_1
{
    public class Actions
    {
        private Logger logger;

        public Actions()
        {
            logger = Logger.Instance;
        }

        public Result Method1()
        {
            logger.LogInfo("Метод запуска: Method1");
            return new Result { Status = true };
        }

        public Result Method2()
        {
            logger.LogWarning("Пропущенная логика в методе: Method2");
            return new Result { Status = true };
        }

        public Result Method3()
        {
            logger.LogError("Я нарушил логику");
            return new Result { Status = false, ErrorMessage = "Я нарушил логику" };
        }
    }

}
