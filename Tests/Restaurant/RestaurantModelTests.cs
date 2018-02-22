using Moq;
using NUnit.Framework;
using SeminarAboutUnitTests.Restaurant;


namespace Tests.Restaurant
{
    /// <summary> Тесты на <see cref="RestaurantModel"/> </summary>
    [TestFixture]
    public class RestaurantModelTests
    {
        private RestaurantModel _service;

        /// <summary> Перед каждым тестом </summary>
        [SetUp]
        public void Setup()
        {
            _service = GetService();
        }

        /// <summary> Проверяем, что клиент здоровается </summary>
        [Test]
        public void Test_Process_Client_Say_Hello()
        {
            //Arrange
            var clientMock = new Mock<IClient>(MockBehavior.Loose);
            var waiterMock = new Mock<IWaiter>(MockBehavior.Loose);

            //Act
            _service.Process(clientMock.Object, waiterMock.Object);

            //Assert
            clientMock.Verify(c => c.Hello(), Times.Once);
        }

        /// <summary> Проверяем, что официант здоровается </summary>
        [Test]
        public void Test_Process_Waiter_Say_Hello()
        {
            //Arrange
            var clientMock = new Mock<IClient>(MockBehavior.Loose);
            var waiterMock = new Mock<IWaiter>(MockBehavior.Loose);

            //Act
            _service.Process(clientMock.Object, waiterMock.Object);

            //Assert
            waiterMock.Verify(c => c.Hello(), Times.Once);
        }

        /// <summary> Проверяем, что официант дает меню </summary>
        [Test]
        public void Test_Process_Waiter_GiveMenu()
        {
            //Arrange
            var clientMock = new Mock<IClient>(MockBehavior.Loose);
            var waiterMock = new Mock<IWaiter>(MockBehavior.Loose);

            //Act
            _service.Process(clientMock.Object, waiterMock.Object);

            //Assert
            waiterMock.Verify(c => c.GiveMenu(), Times.Once);
        }

        /// <summary> Проверяем, что клиент делает заказ по меню официанта </summary>
        [Test]
        public void Test_Process_Client_Make_Order_By_Menu()
        {
            //Arrange
            var clientMock = new Mock<IClient>(MockBehavior.Loose);
            var waiterMock = new Mock<IWaiter>(MockBehavior.Loose);
            var menu = new Menu();
            waiterMock.Setup(s => s.GiveMenu()).Returns(menu);

            //Act
            _service.Process(clientMock.Object, waiterMock.Object);

            //Assert
            clientMock.Verify(c => c.Order(menu), Times.Once);
        }

        /// <summary> Проверяем, что официант исполняет заказ, который заказал клиент </summary>
        [Test]
        public void Test_Process_Waiter_Take_Client_Order()
        {
            //Arrange
            var clientMock = new Mock<IClient>(MockBehavior.Loose);
            var waiterMock = new Mock<IWaiter>(MockBehavior.Loose);
            var order = new OrderInfo();
            clientMock.Setup(s => s.Order(It.IsAny<Menu>())).Returns(order);

            //Act
            _service.Process(clientMock.Object, waiterMock.Object);

            //Assert
            waiterMock.Verify(c => c.ExecuteOrder(order), Times.Once);
        }

        /// <summary> Проверяем, что клиент ест еду, которую принес официант </summary>
        [Test]
        public void Test_Process_Client_Eat_Food_From_Waiter()
        {
            //Arrange
            var clientMock = new Mock<IClient>(MockBehavior.Loose);
            var waiterMock = new Mock<IWaiter>(MockBehavior.Loose);
            var food = new Food();
            waiterMock.Setup(s => s.ExecuteOrder(It.IsAny<OrderInfo>())).Returns(food);

            //Act
            _service.Process(clientMock.Object, waiterMock.Object);

            //Assert
            clientMock.Verify(c => c.Eat(food), Times.Once);
        }

        /// <summary> Проверяем, что клиент просит счет </summary>
        [Test]
        public void Test_Process_Client_AskAccount()
        {
            //Arrange
            var clientMock = new Mock<IClient>(MockBehavior.Loose);
            var waiterMock = new Mock<IWaiter>(MockBehavior.Loose);

            //Act
            _service.Process(clientMock.Object, waiterMock.Object);

            //Assert
            clientMock.Verify(c => c.AskAccount(), Times.Once);
        }

        /// <summary> Проверяем, что официант приносит счет </summary>
        [Test]
        public void Test_Process_Waiter_GiveAccount()
        {
            //Arrange
            var clientMock = new Mock<IClient>(MockBehavior.Loose);
            var waiterMock = new Mock<IWaiter>(MockBehavior.Loose);

            //Act
            _service.Process(clientMock.Object, waiterMock.Object);

            //Assert
            waiterMock.Verify(c => c.GiveAccount(), Times.Once);
        }

        /// <summary> Проверяем, что клиент оплачивает счет от официанта </summary>
        [Test]
        public void Test_Process_Client_PayAccount_From_Waiter()
        {
            //Arrange
            var clientMock = new Mock<IClient>(MockBehavior.Loose);
            var waiterMock = new Mock<IWaiter>(MockBehavior.Loose);
            var account = new Account();
            waiterMock.Setup(s => s.GiveAccount()).Returns(account);

            //Act
            _service.Process(clientMock.Object, waiterMock.Object);

            //Assert
            clientMock.Verify(c => c.PayAccount(account), Times.Once);
        }

        /// <summary> Проверяем, что клиент прощается </summary>
        [Test]
        public void Test_Process_Client_Say_Goodbye()
        {
            //Arrange
            var clientMock = new Mock<IClient>(MockBehavior.Loose);
            var waiterMock = new Mock<IWaiter>(MockBehavior.Loose);

            //Act
            _service.Process(clientMock.Object, waiterMock.Object);

            //Assert
            clientMock.Verify(c => c.Goodbye(), Times.Once);
        }

        /// <summary> Проверяем, что официант прощается </summary>
        [Test]
        public void Test_Process_Waiter_Say_Goodbye()
        {
            //Arrange
            var clientMock = new Mock<IClient>(MockBehavior.Loose);
            var waiterMock = new Mock<IWaiter>(MockBehavior.Loose);

            //Act
            _service.Process(clientMock.Object, waiterMock.Object);

            //Assert
            waiterMock.Verify(c => c.Goodbye(), Times.Once);
        }

        /// <summary> Проверяем целостность модели </summary>
        [Test]
        public void Test_Process()
        {
            //Arrange
            var clientMock = new Mock<IClient>(MockBehavior.Strict);
            var waiterMock = new Mock<IWaiter>(MockBehavior.Strict);

            waiterMock.Setup(s => s.Hello());
            waiterMock.Setup(s => s.GiveMenu()).Returns(new Menu());
            waiterMock.Setup(s => s.ExecuteOrder(It.IsAny<OrderInfo>())).Returns(new Food());
            waiterMock.Setup(s => s.GiveAccount()).Returns(new Account());
            waiterMock.Setup(s => s.Goodbye());

            clientMock.Setup(s => s.Hello());
            clientMock.Setup(s => s.Order(It.IsAny<Menu>())).Returns(new OrderInfo());
            clientMock.Setup(s => s.Eat(It.IsAny<Food>()));
            clientMock.Setup(s => s.AskAccount());
            clientMock.Setup(s => s.Thank());
            clientMock.Setup(s => s.PayAccount(It.IsAny<Account>()));
            clientMock.Setup(s => s.Goodbye());

            //Act
            _service.Process(clientMock.Object, waiterMock.Object);

            //Assert
            waiterMock.Verify(c => c.Hello(), Times.Once);
            waiterMock.Verify(c => c.GiveMenu(), Times.Once);
            waiterMock.Verify(c => c.ExecuteOrder(It.IsAny<OrderInfo>()), Times.Once);
            waiterMock.Verify(c => c.GiveAccount(), Times.Once);
            waiterMock.Verify(c => c.Goodbye(), Times.Once);

            clientMock.Verify(c => c.Hello(), Times.Once);
            clientMock.Verify(c => c.Order(It.IsAny<Menu>()), Times.Once);
            clientMock.Verify(c => c.Eat(It.IsAny<Food>()), Times.Once);
            clientMock.Verify(c => c.AskAccount(), Times.Once);
            clientMock.Verify(c => c.PayAccount(It.IsAny<Account>()), Times.Once);
            clientMock.Verify(c => c.Goodbye(), Times.Once);
        }

        private RestaurantModel GetService()
        {
            return new RestaurantModel();
        }
    }
}