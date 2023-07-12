using System;

namespace PracticTask1;

public enum Gender
{
    Male,
    Female
}

public class Person
{
    public string FirstName { set; get; }
    public string LastName { set; get; }
    public int Age { set; get; }
    public static int Number { get; private set; }
    public Gender Gender { set; get; }

//Создайте класс Person. Добавьте в него свойства
// a. FirstName, LastName, Age
//     b. Добавьте свойство Gender - перечисление (enum) с двумя значениями
//     c. Добавьте в класс метод для приветствия.
//     d. Добавьте в класс статическое свойство - счётчик созданных людей.
//     Свойство должно быть доступно только для чтения.


    public Person(string firstName, string lastName, int age, Gender gender)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Gender = gender;
        Number++;
    }


    public void Greetings()
    {
        Console.WriteLine("Здравствуйте");
    }
}