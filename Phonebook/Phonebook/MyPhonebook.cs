using Newtonsoft.Json;

namespace Phonebook;

/// <summary>
/// Создает телефонную книгу, класс синглтон, позволяет создать только один экземпляр.
/// </summary>
public class MyPhonebook
{
  /// <summary>
  /// Переменная типа класса для создания единственного экземпляра этого класса.
  /// </summary>
  private static MyPhonebook myPhonebook;

  /// <summary>
  /// Путь к файлу с абонентами.
  /// </summary>
  readonly string path =
    "/Users/user/Katarina/Digit/CsharpEducation/Phonebook/Phonebook/phonebook.txt";

  /// <summary>
  /// Список абонентов.
  /// </summary>
  public List<Subscriber> List { set; get; }

  /// <summary>
  /// Возвращает единственный экземпляр класса MyPhonebook.
  /// </summary>
  /// <returns></returns>
  public static MyPhonebook Instance()
  {
    if (myPhonebook == null)
      myPhonebook = new MyPhonebook();

    return myPhonebook;
  }

  #region Вывод в консоль

  /// <summary>
  /// Распечатывает абонентов списка List этого класса.
  /// </summary>
  public void Print()
  {
    List.ForEach(item =>
      Console.WriteLine(item.ToString()));
  }

  #endregion

  #region Создание и чтение.

  /// <summary>
  /// Создает ного абонента и распечатывает всех абонентов.
  /// </summary>
  /// <param name="name">Имя.</param>
  /// <param name="number">Номер.</param>
  public void Create(string name, string number)
  {
    List = ReadAll();
    Subscriber subscriber = new Subscriber(name, number);
    int index = List.FindIndex(s => s.Name == subscriber.Name);
    if (index != -1)
    {
      Console.WriteLine("Абонент уже существует");
      return;
    }

    List.Add(subscriber);
    string serializedSubscribers =
      JsonConvert.SerializeObject(List, Formatting.Indented);
    File.WriteAllText(path, serializedSubscribers);

    Console.WriteLine("Абонент добавлен");
    Print();
  }

  /// <summary>
  /// Читает всех абонентов из файла.
  /// </summary>
  /// <returns></returns>
  public List<Subscriber> ReadAll()
  {
    string book = File.ReadAllText(path);
    List = JsonConvert.DeserializeObject<List<Subscriber>>(book);
    return List;
  }


  /// <summary>
  /// Ищет абонента по имени.
  /// </summary>
  /// <param name="name">Имя абонента для поиска. </param>
  public Subscriber ReadByName(string name)
  {
    Subscriber subscriber = List.FirstOrDefault(x => x.Name == name);
    Console.WriteLine(subscriber?.ToString());
    return subscriber;
  }

  /// <summary>
  /// Ищет абонента по номеру телефона.
  /// </summary>
  /// <param name="number">Номер для поиска.</param>
  public Subscriber ReadByNumber(string number)
  {
    Subscriber subscriber = List.FirstOrDefault(x => x.Number == number);
    Console.WriteLine(subscriber?.ToString());
    return subscriber;
  }

  #endregion

  #region Методы изменения записей

  /// <summary>
  /// Изменяет имя абонента.
  /// </summary>
  /// <param name="name">Старое имя.</param>
  /// <param name="newname">Новое имя.</param>
  public void UpdateName(string name, string newname)
  {
    int index = List.FindIndex(s => s.Name == name);
    if (index != -1)
    {
      List[index].Name = newname;
      string serializedSubscribers =
        JsonConvert.SerializeObject(List, Formatting.Indented);
      File.WriteAllText(path, serializedSubscribers);
      Console.WriteLine("Изменено успешно.");
      Console.WriteLine("Name {0}, Number {1}", List[index].Name,
        List[index].Number);
    }
    else
    {
      Console.WriteLine("Нет такого абонента.");
    }
  }

  /// <summary>
  /// Изменяет номер пользователя.
  /// </summary>
  /// <param name="number">Старый Номер.</param>
  /// <param name="newnumber">Номер новый.</param>
  public void UpdatePhone(string number, string newnumber)
  {
    int index = List.FindIndex(s => s.Number == number);
    if (index != -1)
    {
      List[index].Number = newnumber;
      string serializedSubscribers =
        JsonConvert.SerializeObject(List, Formatting.Indented);
      File.WriteAllText(path, serializedSubscribers);
      Console.WriteLine("Изменено успешно.");
      Console.WriteLine("Name {0}, Number {1}", List[index].Name,
        List[index].Number);
    }
    else
    {
      Console.WriteLine("Нет такого абонента.");
    }
  }

  /// <summary>
  /// Удаляет запись абонента.
  /// </summary>
  /// <param name="name">Имя.</param>
  public void Delete(string name)
  {
    int index = List.FindIndex(s => s.Name == name);

    if (index != -1)
    {
      List.RemoveAt(index);
      string serializedSubscribers =
        JsonConvert.SerializeObject(List, Formatting.Indented);
      File.WriteAllText(path, serializedSubscribers);
      Console.WriteLine("Абонент удален.");
      Print();
    }
    else
    {
      Console.WriteLine("Нет такого абонента.");
    }
  }

  #endregion

  /// <summary>
  /// Констрктор класса, при инициализации создает лист список абонентов.
  /// </summary>
  private MyPhonebook()
  {
    List = new List<Subscriber>();
  }
}
