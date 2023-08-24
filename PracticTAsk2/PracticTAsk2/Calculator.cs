namespace PracticTAsk2
{
    // 3. Создай класс "Калькулятор" с методами для выполнения основных арифметических
    // операций (сложение, вычитание, умножение, деление). Пусть эти методы
    // принимают два числа и возвращают результат операции.

    public static class Calculator
    {
        public static int addition(int a, int b)
        {
            return a + b;
        }

        public static int subtraction(int a, int b)
        {
            return a - b;
        }

        public static int dividing(int a, int b)
        {
            return a / b;
        }

        public static int multiplication(int a, int b)
        {
            return a * b;
        }
    }
}