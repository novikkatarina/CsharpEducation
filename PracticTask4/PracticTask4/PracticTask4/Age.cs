namespace PracticTask4;

// Создайте программу, которая принимает от пользователя его возраст и
// проверяет его на корректность. Если возраст меньше 18 лет, программа
//   должна выбросить исключение с сообщением о том, что пользователь
// несовершеннолетний. Если возраст равен или больше 18 лет, программа
//   должна вывести

public class Person
{
  public int Age { set; get; }

  public void CheckAge()
  {
    Console.WriteLine("Введите возраст");
    string input = Console.ReadLine();

    try
    {
      bool isInt = double.TryParse(input, out var age);
      if (!isInt)
      {
        throw new FormatException(
          "Введено не число.");
      }

      if (age < 0)
      {
        throw new ArgumentException("Возраст должен быть больше нуля.");
      }

      if (age < 18)
      {
        throw new AgeException("Пользователь несовершеннолетний");
      }
    }
    catch ( Exception e) when(e is FormatException ||
                              e is ArgumentException || e is AgeException)
    {
      Console.WriteLine(e.Message);
      return;
    }

    Console.WriteLine("Пользователь совершеннолетний");
  }
}

public class AgeException : Exception
{
  public AgeException(string message) : base(message) { }

}
