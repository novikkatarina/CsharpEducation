using Microsoft.EntityFrameworkCore;

namespace PhonebookSQL;

/// <summary>
/// Телефонный справочник.
/// </summary>
public class Phonebook
{
  #region Поля и свойства

  /// <summary>
  /// Экземпляр класса.
  /// </summary>
  private static Phonebook instance;

  /// <summary>
  /// Контекст базы данных телефонной книги.
  /// </summary>
  private PhonebookContext db;

  /// <summary>
  /// Возвращает экземляр Phonebook.
  /// </summary>
  /// <returns></returns>
  public static Phonebook Instance()
  {
    if (instance == null)
      instance = new Phonebook();

    return instance;
  }

  #endregion

  #region Методы

  /// <summary>
  /// Читает объекты из бд и выводит в консоль.
  /// </summary>
  public void ReadAll()
  {
    var subscribers = db.Subscribers.ToList();
    Console.WriteLine("Все абоненты: ");
    foreach (Subscriber subscriber in subscribers)
    {
      Console.WriteLine(subscriber.ToString());
    }
  }

  /// <summary>
  /// Добавляет абонента в бд.
  /// </summary>
  /// <param name="name">Имя.</param>
  /// <param name="number">Номер.</param>
  public void AddSubscriber(string name, string number)
  {
    try
    {
      Subscriber subscriber = new Subscriber(name, number);
      db.Subscribers.Add(subscriber);
      db.SaveChanges();
      Console.WriteLine($"Абонент {name} добавлен");
    }
    catch (Exception)
    {
      Console.WriteLine($"Абонент с номером {number} уже существует");
      // Handle the exception caused by duplicate primary key
    }
  }

  /// <summary>
  /// Ищет абонента по номеру.
  /// </summary>
  /// <param name="number">Номер.</param>
  public Subscriber ReadByNumber(string number)
  {
    Subscriber subscriber =
      db.Subscribers.FirstOrDefault(p => p.Number == number);
    Console.WriteLine(subscriber?.ToString());

    return subscriber;
  }

  /// <summary>
  /// Ищет абонента по имени.
  /// </summary>
  /// <param name="name">Имя.</param>
  public Subscriber ReadByName(string name)
  {
    Subscriber subscriber =
      db.Subscribers.FirstOrDefault(p => p.Name == name);

    Console.WriteLine(subscriber?.ToString());

    return subscriber;
  }

  /// <summary>
  /// Изменяет номер абонента.
  /// </summary>
  /// <param name="number">Номер.</param>
  /// <param name="newnumber">Новый номер.</param>
  public void UpdateNumber(string number, string newnumber)
  {
    try
    {
      Subscriber subscriber =
        db.Subscribers.First(p => p.Number == number);
      subscriber.Number = newnumber;
      Console.WriteLine($"Номер абонента {subscriber.Name} обновлен.");
      db.SaveChanges();
    }
    catch (Exception)
    {
      Console.WriteLine("Такого абонента не существует");
    }
  }

  /// <summary>
  /// Изменяет имя абонента.
  /// </summary>
  /// <param name="name">Имя.</param>
  /// <param name="newname">Новое имя.</param>
  public void UpdateName(string name, string newname)
  {
    try
    {
      Subscriber subscriber =
        db.Subscribers.First(p => p.Number == name);
      subscriber.Number = newname;
      Console.WriteLine($"Имя абонента {name} изменено на {newname}");
      db.SaveChanges();
    }
    catch (Exception)
    {
      Console.WriteLine("Такого абонента не существует");
    }
  }

  /// <summary>
  /// Удалить абонента по номеру.
  /// </summary>
  /// <param name="number"></param>
  public void DeleteByNumber(string number)
  {
    try
    {
      Subscriber subscriber =
        db.Subscribers.First(p => p.Number == number);
      db.Subscribers.Remove(subscriber);
      Console.WriteLine($"Абонент {subscriber} удален");
      db.SaveChanges();
    }
    catch (Exception)
    {
      Console.WriteLine($"Абонент с номером {number} не существует");
      // Handle the exception caused by duplicate primary key
    }
  }

  #endregion

  /// <summary>
  /// Экземпляр контекста базы данных.
  /// </summary>
  private Phonebook()
  {
    DbContextOptions<PhonebookContext> options =
      new DbContextOptionsBuilder<PhonebookContext>()
        .UseNpgsql(
          "Host=localhost;Database=testdb;Username=postgres;Password=8313")
        .Options;

    db = new PhonebookContext(options);
  }
}
