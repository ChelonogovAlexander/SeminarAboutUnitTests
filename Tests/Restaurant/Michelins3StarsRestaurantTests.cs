﻿using Moq;
using NUnit.Framework;
using SeminarAboutUnitTests.Restaurant;

namespace Tests.Restaurant
{
    /// <summary> Тесты на <see cref="Michelins3StarsRestaurant"/> </summary>
    [TestFixture]
    public class Michelins3StarsRestaurantTests
    {
        private Michelins3StarsRestaurant _service;

        private Mock<IWaiterFactory> _waiterFactoryMock;
        private Mock<IRestaurantModel> _restaurantModelMock;

        /// <summary> Перед каждым тестом </summary>
        [SetUp]
        public void Setup()
        {
            _waiterFactoryMock = new Mock<IWaiterFactory>(MockBehavior.Strict);
            _restaurantModelMock = new Mock<IRestaurantModel>(MockBehavior.Strict);
            _service = GetService();
        }

        /// <summary>
        /// Проверяем, что ресторан использует модель ресторана <see cref="IRestaurantModel.Process"/> 
        /// с фабрики <see cref="IWaiterFactory.GetWaiter"/>
        /// </summary>
        [Test]
        public void Test_Progress_Use_RestaurantModel_With_Free_Waiter_From_Factory()
        {
            //Arrange
            var client = new Mock<IClient>().Object;
            var waiter = new Mock<IWaiter>().Object;
            _waiterFactoryMock.Setup(s => s.GetWaiter(client)).Returns(waiter);
            _restaurantModelMock.Setup(s => s.Process(client, waiter));

            //Act
            _service.Progress(client);

            //Assert
            _waiterFactoryMock.Verify(s => s.GetWaiter(client), Times.Once);
            _restaurantModelMock.Verify(s => s.Process(client, waiter), Times.Once);
        }

        private Michelins3StarsRestaurant GetService()
        {
            return new Michelins3StarsRestaurant(_waiterFactoryMock.Object, _restaurantModelMock.Object);
        }
    }
}