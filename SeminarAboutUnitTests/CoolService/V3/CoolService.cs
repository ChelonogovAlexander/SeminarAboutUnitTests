using System;

namespace SeminarAboutUnitTests.CoolService.V3
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
            _logger.Log(string.Format(
                "Метод вызвали с параметрами: number1={0}, number2={1}. В результате получили result={2}",
                number1, number2, res));
            return res;
        }
    }
}