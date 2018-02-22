using System;
using System.Threading;

namespace SeminarAboutUnitTests.CoolService.V4
{
    /// <summary> Супер сервис </summary>
    public class CoolService
    {
        private readonly ILogger _logger;

        /// <summary> Супер сервис </summary>
        public CoolService(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary> Получить число </summary>
        public int GetNumber(int number1, int number2)
        {
            var res = Math.Min(number1, number2);

            var msg = string.Format(
                "Метод вызвали в {0} с параметрами: number1={1}, number2={2}. В результате получили result={3}",
                DateTime.Now, 
                number1, 
                number2, 
                res);
            _logger.Log(msg);
              Thread.Sleep(2000);
            return res;
        }
    }
}