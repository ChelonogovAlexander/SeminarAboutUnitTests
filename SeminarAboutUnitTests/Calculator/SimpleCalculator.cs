namespace SeminarAboutUnitTests.Calculator
{
    /// <summary> Простой калькулятор </summary>
    public class SimpleCalculator
    {
        /// <summary> Суммируем числа <see cref="a"/> и <see cref="b"/> </summary>
        /// <param name="a">Первое слагаемое</param>
        /// <param name="b">Второе слагаемое</param>
        /// <returns>Сумма двух слагаемых</returns>
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}