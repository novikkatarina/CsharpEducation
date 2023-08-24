namespace Phonebook;

/// <summary>
/// Создает сущность Абонент.
/// </summary>
public class Subscriber
{
  /// <summary>
  /// Имя абонента.
  /// </summary>
  public string Name { set; get; }

  /// <summary>
  /// Номер телефона абонента.
  /// </summary>
  public string Number { set; get; }

  /// <summary>
  /// Переопределяет метод ToString() для строкого представления абонента.
  /// </summary>
  /// <returns></returns>
  public override string ToString()
  {
    string str = $"{Name} {Number}";
    return str;
  }

  /// <summary>
  /// Констрктор класса, при инициализации при входных аргументах Имя и Номер создает объект типа Абонент.
  /// </summary>
  /// <param name="name"></param>
  /// <param name="number"></param>
  public Subscriber(string name, string number)
  {
    Name = name;
    Number = number;
  }
}
