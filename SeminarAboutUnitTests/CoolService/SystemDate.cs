using System;

namespace SeminarAboutUnitTests.CoolService
{
    /// <summary> Сервис времени </summary>
    public class SystemDate : ISystemDate
    {
        /// <summary> Получить текущее время </summary>
        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}