namespace SeminarAboutUnitTests.Restaurant
{
    /// <summary> Модель ресторана </summary>
    public class RestaurantModel : IRestaurantModel
    {
        /// <summary> Процесс ресторана </summary>
        public void Process(IClient client, IWaiter waiter)
        {
            client.Hello();
            waiter.Hello();

            var menu = waiter.GiveMenu();
            var order = client.Order(menu);

            var food = waiter.ExecuteOrder(order);
            client.Thank();
            client.Eat(food);

            client.AskAccount();
            var account = waiter.GiveAccount();
            client.PayAccount(account);

            client.Goodbye();
            waiter.Goodbye();
        }
    }
}