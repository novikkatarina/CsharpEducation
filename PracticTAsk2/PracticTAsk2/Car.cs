using System;

namespace PracticTAsk2
{
    // 10. Создай класс "Автомобиль" с полем "Марка". Напиши метод, который будет
    // принимать объект класса "Автомобиль" и выводить информацию о марке
    // автомобиля в консоль.

    public class Car
    {
        public string Brand;

        public void GetInfo(Car car)
        {
            Console.WriteLine(car.Brand);
        }
    }
}