//
// 1. Создайте метод расширения "IsPalindrome", который будет проверять, является ли
//   строка палиндромом.



string str = "anna";

bool IsExt = str.IsPalindromeExtension();
Console.WriteLine(IsExt);

static class StringExtension
{

  public static bool IsPalindromeExtension(this string str)
  {
    string palindrom = new string(str.Reverse().ToArray());

    if (str == palindrom) return true;
    return false;
  }
}
