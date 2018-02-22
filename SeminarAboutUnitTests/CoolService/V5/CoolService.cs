using System;
using System.Threading;

namespace SeminarAboutUnitTests.CoolService.V5
{
    /// <summary> Супер сервис </summary>
    public class CoolService
    {
        private readonly ILogger _logger;
        private readonly ISystemDate _systemDate;

        /// <summary> Супер сервис </summary>
        public CoolService(ILogger logger, ISystemDate systemDate)
        {
            _logger = logger;
            _systemDate = systemDate;
        }

        /// <summary> Получить число </summary>
        public int GetNumber(int number1, int number2)
        {
            var res = Math.Min(number1, number2);

            var msg = string.Format(
                "Метод вызвали в {0} с параметрами: number1={1}, number2={2}. В результате получили result={3}",
                _systemDate.GetNow(), 
                number1, 
                number2, 
                res);
            _logger.Log(msg);

            Thread.Sleep(2000);

            return res;
        }
    }
}