namespace SeminarAboutUnitTests.Restaurant
{
    /// <summary> Подмостовный ресторан </summary>
    public class UnderTheBridgeRestaurant
    {
        private readonly IWaiterFactory _waiterFactory;
        private readonly IRestaurantModel _restaurantModel;

        /// <summary> Подмостовный ресторан </summary>
        public UnderTheBridgeRestaurant(IWaiterFactory waiterFactory, IRestaurantModel restaurantModel)
        {
            _waiterFactory = waiterFactory;
            _restaurantModel = restaurantModel;
        }

        /// <summary> Процесс ресторана </summary>
        public void Progress(IClient client)
        {
            var waiter = _waiterFactory.GetFreeWaiter();
            _restaurantModel.Process(client, waiter);
        }
    }
}