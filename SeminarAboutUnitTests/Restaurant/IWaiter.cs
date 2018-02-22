namespace SeminarAboutUnitTests.Restaurant
{
    /// <summary> Официант </summary>
    public interface IWaiter
    {
        /// <summary> Поздороваться </summary>
        void Hello();

        /// <summary> Предложить меню </summary>
        Menu GiveMenu();

        /// <summary> Исполнить заказ </summary>
        Food ExecuteOrder(OrderInfo order);

        /// <summary> Дать счет </summary>
        Account GiveAccount();

        /// <summary> Попрощаться </summary>
        void Goodbye();
    }
}