using System;
using Moq;
using NUnit.Framework;
using SeminarAboutUnitTests.CoolService;
using SeminarAboutUnitTests.CoolService.V5;

namespace Tests.CoolServiceTests.V5
{
    /// <summary> Тесты на <see cref="CoolService"/> </summary>
    [TestFixture]
    public class CoolServiceTests
    {
        private CoolService _service;
        private Mock<ILogger> _loggerMock;
        private Mock<ISystemDate> _systemDate;

        /// <summary> Перед каждым тестом </summary>
        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger>();
            _systemDate = new Mock<ISystemDate>();
            _systemDate.Setup(s => s.GetNow()).Returns(new DateTime(2011, 3, 4));
            _service = GetService();
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
                _systemDate.Object.GetNow(),
                number1,
                number2,
                act);
            _loggerMock.Verify(s => s.Log(expMessage), Times.Once);
        }

        private CoolService GetService()
        {
            return new CoolService(_loggerMock.Object, _systemDate.Object);
        }
    }
}