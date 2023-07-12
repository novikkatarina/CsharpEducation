using System;

namespace ClassLibrary1

    // Создай библиотеку классов, в которой будет класс "Person" с полями "Имя" и
    // "Возраст". Реализуй метод, который будет выводить информацию о персоне в
    // консоль. Подключи эту пользовательскую библиотеку классов в новый проект и
    //     создай объекты класса "Person" для выполнения задач, связанных с персонами.
{
    public class PersonLib
    {
        public class Person1
        {
            public string name;
            public int age;

            public void GetInfo()
            {
                Console.WriteLine(name + " " + age);
            }
        }
    }
}