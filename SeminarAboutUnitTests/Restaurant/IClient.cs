namespace SeminarAboutUnitTests.Restaurant
{
    /// <summary> Клиент ресторана </summary>
    public interface IClient
    {
        /// <summary> Поздороваться </summary>
        void Hello();

        /// <summary> Сделать заказ </summary>
        OrderInfo Order(Menu menu);

        /// <summary> Есть </summary>
        void Eat(Food food);
        
        /// <summary> Попросить счет </summary>
        void AskAccount();

        /// <summary> Оплатить счет </summary>
        void PayAccount(Account account);

        /// <summary> Попрощаться </summary>
        void Goodbye();

        void Thank();
    }
}