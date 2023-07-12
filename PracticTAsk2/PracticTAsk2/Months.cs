using System;

namespace PracticTAsk2
{
    // 7. Создай перечисление "Месяцы" с элементами, представляющими названия
    // месяцев года. Напиши метод, который будет принимать месяц и возвращать
    // количество дней в этом месяце.
    public enum Month
    {
        January = 31,
        February = 28,
        March = 31,
        April = 30,
        May = 31,
        June = 30,
        July = 31,
        August = 31,
        September = 30,
        October = 31,
        November = 30,
        December = 31
    }

    public class Months
    {
        public static int Days(Month month)
        {
            if (Enum.IsDefined(typeof(Month), month)) return (int)month;
            else
            {
                return 0;
            }
        }
    }
}