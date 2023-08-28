namespace PracticTask4;

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
