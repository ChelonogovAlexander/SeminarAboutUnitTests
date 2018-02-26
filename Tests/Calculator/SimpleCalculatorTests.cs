using NUnit.Framework;
using SeminarAboutUnitTests.Calculator;

namespace Tests.Calculator
{
    /// <summary> Тесты на <see cref="SimpleCalculator"/> </summary>
    [TestFixture]
    public class SimpleCalculatorTests
    {
        private SimpleCalculator _service;

        /// <summary> Перед каждым тестом </summary>
        [SetUp]
        public void Setup()
        {
            _service = GetService();
        }

        /// <summary> Проверяем, что возвращается 0, если складываем отрицательное число и модуль отрицательного числа </summary>
        [Test]
        public void Test_Sum_Return_0_If_Sum_Negative_Number_With_AbsOfNegative()
        {
            //Arrange
            var firstArgument = -123;
            var secondArgument = 123;

            //Act
            var act = _service.Sum(firstArgument, secondArgument);

            //Assert
            Assert.AreEqual(0, act);
        }

        /// <summary> Проверяем, что возвращается 4, если складываем 2+2 </summary>
        [Test]
        public void Test_Sum_Return_4_If_Sum_2_And_2()
        {
            //Arrange
            var firstArgument = 2;
            var secondArgument = 2;

            //Act
            var act = _service.Sum(firstArgument, secondArgument);

            //Assert
            Assert.AreEqual(4, act);
        }

        /// <summary> Проверяем, что возвращается 0, если оба аргумента = 0 </summary>
        [Test]
        public void Test_Sum_Return_0_If_Both_Arguments_Are_0()
        {
            //Arrange
            var firstArgument = 0;
            var secondArgument = 0;

            //Act
            var act = _service.Sum(firstArgument, secondArgument);

            //Assert
            Assert.AreEqual(0, act);
        }

        /// <summary> Проверяем, что возвращается первый аргумент, если второй равен 0 </summary>
        [Test]
        public void Test_Sum_Return_First_Argument_If_Second_Argument_Is_0()
        {
            //Arrange
            var firstArgument = 1234;
            var secondArgument = 0;

            //Act
            var act = _service.Sum(firstArgument, secondArgument);

            //Assert
            Assert.AreEqual(firstArgument, act);
        }

        /// <summary> Проверяем, что возвращается второй аргумент, если первый равен 0 </summary>
        [Test]
        public void Test_Sum_Return_Second_Argument_If_First_Argument_Is_0()
        {
            //Arrange
            var firstArgument = 0;
            var secondArgument = 1234;

            //Act
            var act = _service.Sum(firstArgument, secondArgument);

            //Assert
            Assert.AreEqual(secondArgument, act);
        }

        private SimpleCalculator GetService()
        {
            return new SimpleCalculator();
        }
    }
}