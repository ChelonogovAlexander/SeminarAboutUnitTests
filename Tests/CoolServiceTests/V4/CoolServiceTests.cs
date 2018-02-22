using System;
using Moq;
using NUnit.Framework;
using SeminarAboutUnitTests.CoolService;
using SeminarAboutUnitTests.CoolService.V4;

namespace Tests.CoolServiceTests.V4
{
    /// <summary> Тесты на <see cref="CoolService"/> </summary>
    [TestFixture]
    public class CoolServiceTests
    {
        private CoolService _service;
        private Mock<ILogger> _loggerMock;

        /// <summary> Перед каждым тестом </summary>
        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger>();
            _service = GetService();
        }

        /// <summary> Проверяем, что возвращается минимум </summary>
        [Test]
        [TestCase(123, 456, 123)]
        [TestCase(456, 123, 123)]
        [TestCase(789, 789, 789)]
        public void Test_GetNumber_Return_Min_Number(int number1, int number2, int expected)
        {
            //Act
            var act = _service.GetNumber(number1, number2);

            //Assert
            Assert.AreEqual(expected, act);
        }

        /// <summary> Проверяем, что у нас всё логируется </summary>
        [Test]
        public void Test_GetNumber_Should_Log_Not_Correct()
        {
            //Arrange
            var number1 = 123;
            var number2 = 456;

            //Act
            var act = _service.GetNumber(number1, number2);

            //Assert
            var expMessage = string.Format(
                "Метод вызвали с параметрами: number1={0}, number2={1}. В результате получили result={2}",
                number1, number2, act);
            _loggerMock.Verify(s => s.Log(expMessage), Times.Once, "Тест упал, т. к. используется свойство DateTime.Now. Нужно от него избавляться. См. V5");
        }

        /// <summary> Проверяем, что у нас всё логируется </summary>
        [Test]
        public void Test_GetNumber_Should_Log()
        {
            //Arrange
            var number1 = 123;
            var number2 = 456;

            //Act
            var act = _service.GetNumber(number1, number2);

            //Assert
            var expMessage = string.Format("Метод вызвали в {0} с параметрами: number1={1}, number2={2}. В результате получили result={3}",
                DateTime.Now,
                number1,
                number2,
                act);
            _loggerMock.Verify(s => s.Log(expMessage), Times.Once, "Тест упал, т. к. используется свойство DateTime.Now. Нужно от него избавляться. См. V5");
        }

        private CoolService GetService()
        {
            return new CoolService(_loggerMock.Object);
        }
    }
}