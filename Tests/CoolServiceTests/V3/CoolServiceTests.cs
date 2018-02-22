using Moq;
using NUnit.Framework;
using SeminarAboutUnitTests.CoolService;
using SeminarAboutUnitTests.CoolService.V3;

namespace Tests.CoolServiceTests.V3
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
        public void Test_GetNumber_Should_Log()
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
            _loggerMock.Verify(s => s.Log(expMessage), Times.Once);
        }

        private CoolService GetService()
        {
            return new CoolService(_loggerMock.Object);
        }
    }
}