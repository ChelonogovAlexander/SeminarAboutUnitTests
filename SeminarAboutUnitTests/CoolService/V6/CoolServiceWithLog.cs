namespace SeminarAboutUnitTests.CoolService.V6
{
    /// <summary> Супер сервис с логированием </summary>
    public class CoolServiceWithLog : ICoolService
    {
        private readonly ICoolService _coolService;
        private readonly ILogger _logger;
        private readonly ISystemDate _systemDate;

        /// <summary> Супер сервис с логированием </summary>
        public CoolServiceWithLog(ICoolService coolService, ILogger logger, ISystemDate systemDate)
        {
            _coolService = coolService;
            _logger = logger;
            _systemDate = systemDate;
        }

        /// <summary> Получить число </summary>
        public int GetNumber(int number1, int number2)
        {
            var res = _coolService.GetNumber(number1, number2);

            var msg = string.Format(
                "Метод вызвали в {0} с параметрами: number1={1}, number2={2}. В результате получили result={3}",
                _systemDate.GetNow(),
                number1,
                number2,
                res);
            _logger.Log(msg);

            return res;
        }
    }
}