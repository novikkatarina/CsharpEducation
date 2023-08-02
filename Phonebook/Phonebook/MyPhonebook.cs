using Newtonsoft.Json;

namespace Phonebook;

/// <summary>
/// Телефонный справочник.
/// </summary>
public class MyPhonebook
{
  
  #region Вложенные типы

  public class SubscriberEventArgs
  {
    /// <summary>
    /// Сообщение.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Абонент.
    /// </summary>
    public Subscriber Subscriber { get; }

    /// <summary>
    /// Аргументы события.
    /// </summary>
    /// <param name="subscriber"></param>
    /// <param name="message"></param>
    public SubscriberEventArgs(Subscriber subscriber, string message)
    {
      Message = message;
      Subscriber = subscriber;
    }
  }

  #endregion

  #region Поля и свойства

  /// <summary>
  /// Экземпляр класса.
  /// </summary>
  private static MyPhonebook instance;

  /// <summary>
  /// Путь к файлу с абонентами.
  /// </summary>
  static string[] paths =
  {
    "/", "Users", "user", "Katarina", "Digit", "CsharpEducation", "Phonebook",
    "Phonebook", "phonebook.txt"
  };

  string fullPath = Path.Combine(paths);

  /// <summary>
  /// Список абонентов.
  /// </summary>
  private List<Subscriber> Subscribers { set; get; }

  #endregion

  #region Методы

  /// <summary>
  /// Экземпляр класса.
  /// </summary>
  /// <returns>Экземпляр класса.</returns>
  public static MyPhonebook Instance()
  {
    if (instance == null)
      instance = new MyPhonebook();

    return instance;
  }


  /// <summary>
  /// Распечатывает абонентов списка List этого класса.
  /// </summary>
  public void Print()
  {
    Subscribers.ForEach(item =>
      Console.WriteLine(item));
  }

  /// <summary>
  /// Читает всех абонентов из файла.
  /// </summary>
  /// <returns>Список абонентов.</returns>
  public List<Subscriber> ReadAll()
  {
    string book = File.ReadAllText(fullPath);
    Subscribers = JsonConvert.DeserializeObject<List<Subscriber>>(book);
    return Subscribers;
  }

  /// <summary>
  /// Создает нового абонента.
  /// </summary>
  /// <param name="name">Имя.</param>
  /// <param name="number">Номер.</param>
  public void Create(string name, string number)
  {
    Subscriber subscriber = new Subscriber(name, number);
    if (Subscribers.Contains(subscriber))
    {
      Notify?.Invoke(Message.CreateSub);
      return;
    }

    Subscribers.Add(subscriber);
    string serializedSubscribers =
      JsonConvert.SerializeObject(Subscribers, Formatting.Indented);
    File.WriteAllText(fullPath, serializedSubscribers);
    Notify?.Invoke(Message.CreateSub2);
  }

  /// <summary>
  /// Ищет абонента по имени.
  /// </summary>
  /// <param name="name">Имя абонента для поиска. </param>
  public Subscriber ReadByName(string name)
  {
    Subscriber subscriber = Subscribers.FirstOrDefault(x => x.Name == name);
    if (subscriber != null)
    {
      string message = string.Format(Message.ReadSub, subscriber);
      Notify2?.Invoke(subscriber, new SubscriberEventArgs(subscriber, message));
      return subscriber;
    }

    string message2 = string.Format(Message.ReadSub2, subscriber);
    Notify2?.Invoke(subscriber, new SubscriberEventArgs(subscriber, message2));
    return subscriber;
  }

  /// <summary>
  /// Ищет абонента по номеру телефона.
  /// </summary>
  /// <param name="number">Номер для поиска.</param>
  public Subscriber ReadByNumber(string number)
  {
    Subscriber subscriber = Subscribers.FirstOrDefault(x => x.Number == number);
    if (subscriber != null)
    {
      string message = string.Format(Message.ReadSub, subscriber);
      Notify2?.Invoke(subscriber, new SubscriberEventArgs(subscriber, message));
      return subscriber;
    }

    string message2 = string.Format(Message.ReadSub2, subscriber);
    Notify2?.Invoke(subscriber, new SubscriberEventArgs(subscriber, message2));
    return subscriber;
  }

  /// <summary>
  /// Изменяет имя абонента.
  /// </summary>
  /// <param name="name">Старое имя.</param>
  /// <param name="newname">Новое имя.</param>
  public void UpdateName(string name, string newname)
  {
    Subscriber subscriberToChange = Subscribers.Find(s => s.Name == name);
    if (subscriberToChange != null)
    {
      subscriberToChange.Name = newname;
      string serializedSubscribers =
        JsonConvert.SerializeObject(Subscribers, Formatting.Indented);
      File.WriteAllText(fullPath, serializedSubscribers);
      string message = string.Format(Message.UpdateSub, subscriberToChange.Name,
        subscriberToChange.Number);
      Notify2?.Invoke(subscriberToChange,
        new SubscriberEventArgs(subscriberToChange, message));
    }
    else
    {
      Notify2?.Invoke(subscriberToChange,
        new SubscriberEventArgs(subscriberToChange, Message.UpdateSub2));
    }
  }

  /// <summary>
  /// Изменяет номер пользователя.
  /// </summary>
  /// <param name="number">Старый Номер.</param>
  /// <param name="newnumber">Номер новый.</param>
  public void UpdatePhone(string number, string newnumber)
  {
    Subscriber subscriberToChange = Subscribers.Find(s => s.Number == number);
    if (subscriberToChange != null)
    {
      subscriberToChange.Number = newnumber;
      string serializedSubscribers =
        JsonConvert.SerializeObject(Subscribers, Formatting.Indented);
      File.WriteAllText(fullPath, serializedSubscribers);
      string message = string.Format(Message.UpdateSub, subscriberToChange.Name,
        subscriberToChange.Number);
      Notify2?.Invoke(subscriberToChange,
        new SubscriberEventArgs(subscriberToChange, message));
    }
    else
    {
      Notify2?.Invoke(subscriberToChange,
        new SubscriberEventArgs(subscriberToChange, Message.UpdateSub2));
    }
  }

  /// <summary>
  /// Удаляет запись абонента.
  /// </summary>
  /// <param name="number">Номер.</param>
  public void Delete(string number)
  {
    Subscriber subscriberToDelete = Subscribers.Find(s => s.Number == number);

    if (subscriberToDelete != null)
    {
      Subscribers.Remove(subscriberToDelete);
      string serializedSubscribers =
        JsonConvert.SerializeObject(Subscribers, Formatting.Indented);
      File.WriteAllText(fullPath, serializedSubscribers);
      Notify?.Invoke(Message.Delete);
    }
    else
    {
      Notify?.Invoke(Message.Delete2);
      ;
    }
  }

  #endregion

  #region События

  public delegate void MyPhonebookMessaging(string message);

  public event MyPhonebookMessaging Notify;

  public delegate void MyPhonebookMessaging2(Subscriber subscriber,
    SubscriberEventArgs e);


  public event MyPhonebookMessaging2 Notify2;

  #endregion

  /// <summary>
  /// Экземпляр класса.
  /// </summary>
  private MyPhonebook()
  {
    Subscribers = new List<Subscriber>();
  }
}
