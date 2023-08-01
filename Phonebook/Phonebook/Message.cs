namespace Phonebook;

public class Message
{
  public const string CreateSub = "Абонент уже существует";
  public const string CreateSub2 = "Абонент добавлен";
  public static string ReadSub = "Найден пользователь {0}";
  public static string ReadSub2 = "Пользователь не найден";
  public static string UpdateSub= "Изменено успешно. Name {0}, Number {1}";
  public static string UpdateSub2 = "Нет такого абонента.";
  public static string Delete = "Абонент удален.";
  public static string Delete2 = "Нет такого абонента.";
}
