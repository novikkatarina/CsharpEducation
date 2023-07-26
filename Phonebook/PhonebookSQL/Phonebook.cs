using Microsoft.EntityFrameworkCore;

namespace PhonebookSQL;

/// <summary>
/// 
/// </summary>
public class Phonebook
{
  private static Phonebook _phonebook;
  public PhonebookContext db;

  /// <summary>
  /// 
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

  /// <summary>
  /// Возвращает экземляр Phonebook.
  /// </summary>
  /// <returns></returns>
  public static Phonebook Instance()
  {
    if (_phonebook == null)
      _phonebook = new Phonebook();

    return _phonebook;
  }


  /// <summary>
  /// Читает объекты из бд и выводит в консоль.
  /// </summary>
  public void ReadAll()
  {
    var subscribers = db.Subscribers.ToList();
    Console.WriteLine("Все абоненты: ");
    foreach (Subscriber s in subscribers)
    {
      Console.WriteLine($"{s.Name} - {s.Number}");
    }
  }

  /// <summary>
  /// Добавляет абонента в бд.
  /// </summary>
  /// <param name="name"></param>
  /// <param name="number"></param>
  public void AddSubscriber(string name, string number)
  {
    try
    {
      Subscriber subscriber = new Subscriber(name, number);
      db.Subscribers.Add(subscriber);
      db.SaveChanges();
      Console.WriteLine($"Абонент {name} добавлен");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Абонент с номером {number} уже существует");
      // Handle the exception caused by duplicate primary key
    }
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="number"></param>
  public void ReadByNumber(string number)
  {
    try
    {
      Subscriber subscriber =
        db.Subscribers.FirstOrDefault(p => p.Number == number);
      if (subscriber != null)
        Console.WriteLine($"{subscriber.Name} {subscriber.Number}");
      db.SaveChanges();
    }
    catch (Exception)
    {
      Console.WriteLine("Абонента не существует");
      // Console.WriteLine(ex.Message);
      // Handle the exception caused by duplicate primary key
    }
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="name"></param>
  public void ReadByName(string name)
  {
    try
    {
      Subscriber subscriber =
        db.Subscribers.FirstOrDefault(p => p.Name == name);
      if (subscriber != null)
        Console.WriteLine($"{subscriber.Name} {subscriber.Number}");
      db.SaveChanges();
    }
    catch (Exception)
    {
      Console.WriteLine("Такого абонента не существует");
      // Handle the exception caused by duplicate primary key
    }
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="number"></param>
  /// <param name="newnumber"></param>
  public void UpdateNumber(string number, string newnumber)
  {
    try
    {
      Subscriber subscriber =
        db.Subscribers.FirstOrDefault(p => p.Number == number);
      if (subscriber != null)
      {
        subscriber.Number = newnumber;
        Console.WriteLine($"Номер абонента {subscriber.Name} обновлен.");
      }

      db.SaveChanges();
    }
    catch (Exception)
    {
      Console.WriteLine("Такого абонента не существует");
    }
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="name"></param>
  /// <param name="newname"></param>
  public void UpdateName(string name, string newname)
  {
    try
    {
      Subscriber subscriber =
        db.Subscribers.FirstOrDefault(p => p.Number == name);
      if (subscriber != null)
      {
        subscriber.Number = newname;
        Console.WriteLine($"Имя абонента {name} изменено на {newname}");
      }

      db.SaveChanges();
    }
    catch (Exception)
    {
      Console.WriteLine("Такого абонента не существует");
      // Handle the exception caused by duplicate primary key
    }
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="name"></param>
  public void DeleteByNumber(string number)
  {
    try
    {
      Subscriber subscriber =
        db.Subscribers.FirstOrDefault(p => p.Number == number);
      if (subscriber != null)
      {
        db.Subscribers.Remove(subscriber);
        Console.WriteLine($"Абонент {subscriber} удален");
        db.SaveChanges();
      }
    }
    catch (Exception)
    {
      Console.WriteLine($"Абонент с номером {number} не существует");
      // Handle the exception caused by duplicate primary key
    }
  }
}
