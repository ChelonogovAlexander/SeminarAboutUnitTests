namespace SeminarAboutUnitTests.Restaurant
{
    /// <summary> Модель ресторана </summary>
    public interface IRestaurantModel
    {
        /// <summary> Процесс ресторана </summary>
        void Process(IClient client, IWaiter waiter);
    }
}