using System;
using System.Threading;

namespace SeminarAboutUnitTests.CoolService.V6
{
    /// <summary> Супер сервис </summary>
    public class CoolService : ICoolService
    {
        /// <summary> Получить число </summary>
        public int GetNumber(int number1, int number2)
        {
            var res = Math.Min(number1, number2);

            return res;
        }
    }
}