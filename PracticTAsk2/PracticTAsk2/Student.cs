using System;


// 1. Создай класс "Студент" с полями "Имя" и "Возраст". Напиши метод, который будет
// выводить информацию о студенте в консоль.
// 2. Создай класс "Студент" с полями "Имя" и "Возраст". Напиши метод, который будет
// выводить информацию о студенте в консоль. Добавь в класс "Студент" свойство
// "Средний балл". Реализуй геттер и сеттер для этого свойства. Добавь проверку в
//     сеттер, чтобы значение среднего балла было в диапазоне от 0 до 5


// 9. Создай класс "Студент" с полями "Имя" и "Возраст". Напиши метод, который будет
// принимать объект класса "Студент" и изменять его имя на "Аноним".

namespace PracticTAsk2
{
    public class Student
    {
        public string Name { set; get; }
        public int Age { set; get; }

        public double gta;

        public double Gta
        {
            set
            {
                if ((value < 0) || (value > 5))
                {
                    Console.WriteLine(" Not in between 0 and 5");
                }
                else
                {
                    gta = value;

                    Console.WriteLine("in between 0 and 5");
                }
            }
        }

        public void GetStudent()
        {
            Console.WriteLine($"Имя - {Name}, возраст - {Age}");
        }

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public void ChangeName(Student student)
        {
            student.Name = "Anonim";
            Console.WriteLine(Name);
        }
    }
}