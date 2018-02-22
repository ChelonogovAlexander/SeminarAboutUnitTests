namespace SeminarAboutUnitTests.Restaurant
{
    /// <summary> Фабрика официантов </summary>
    public interface IWaiterFactory
    {
        /// <summary> Определить свободного официанта </summary>
        IWaiter GetFreeWaiter();

        /// <summary> Определить официанта для клиента </summary>
        IWaiter GetWaiter(IClient client);
    }
}