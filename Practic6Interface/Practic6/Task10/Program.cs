//   1. Создайте метод расширения "IsPalindrome", который будет проверять, является ли
//   строка палиндромом.

string str = "anna";

bool Ext = str.IsPalindrome();
Console.WriteLine(Ext);

static class StringExtension
{
  public static bool IsPalindrome(this string str)
  {
    string palindrom = new string(str.Reverse().ToArray());

    if (str == palindrom) return true;
    return false;
  }
}
