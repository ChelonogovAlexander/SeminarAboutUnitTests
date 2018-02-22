using System;

namespace SeminarAboutUnitTests.CoolService
{
    /// <summary> Сервис времени </summary>
    public interface ISystemDate
    {
        /// <summary> Получить текущее время </summary>
        DateTime GetNow();
    }
}