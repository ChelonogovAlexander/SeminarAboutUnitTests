namespace SeminarAboutUnitTests.Restaurant
{
    /// <summary> Ресторан с тремя звездами Мишлена </summary>
    public class Michelins3StarsRestaurant
    {
        private readonly IWaiterFactory _waiterFactory;
        private readonly IRestaurantModel _restaurantModel;

        /// <summary> Ресторан с тремя звездами Мишлена </summary>
        public Michelins3StarsRestaurant(IWaiterFactory waiterFactory, IRestaurantModel restaurantModel)
        {
            _waiterFactory = waiterFactory;
            _restaurantModel = restaurantModel;
        }

        /// <summary> Процесс ресторана </summary>
        public void Progress(IClient client)
        {
            var waiter = _waiterFactory.GetWaiter(client);
            _restaurantModel.Process(client, waiter);
        }
    }
}