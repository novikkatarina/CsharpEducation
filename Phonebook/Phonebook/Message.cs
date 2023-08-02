namespace Phonebook;

/// <summary>
/// Сообщения - оповещения.
/// </summary>
public class Message
{
  /// <summary>
  /// Сообщение, срабатывающее на событие неудачного добавления. 
  /// </summary>
  public const string CreateSub = "Абонент уже существует";
  /// <summary>
  /// Сообщение, срабатывающее на событие удачного добавления. 
  /// </summary>
  public const string CreateSub2 = "Абонент добавлен";
  /// <summary>
  /// Сообщение, срабатывающее на событие удачного поиска. 
  /// </summary>
  public static string ReadSub = "Найден пользователь {0}";
  /// <summary>
  /// Сообщение, срабатывающее на событие неудачного поиска. 
  /// </summary>
  public static string ReadSub2 = "Пользователь не найден";
  /// <summary>
  /// Сообщение, срабатывающее на событие успешного изменения. 
  /// </summary>
  public static string UpdateSub= "Изменено успешно. Name {0}, Number {1}";
  /// <summary>
  /// Сообщение, срабатывающее на событие неуспешного изменения. 
  /// </summary>
  public static string UpdateSub2 = "Нет такого абонента.";
  /// <summary>
  /// Сообщение, срабатывающее на событие удачного удаления. 
  /// </summary>
  public static string Delete = "Абонент удален.";
  /// <summary>
  /// Сообщение, срабатывающее на событие неудачного удаления. 
  /// </summary>
  public static string Delete2 = "Нет такого абонента.";
}
