// 2. Создайте метод расширения "ToTitleCase", который будет преобразовывать первую
// букву каждого слова в строке в верхний регистр.

string str = "dkw wjefo cejwdo ewjoe";
string result = str.ToTitleCase();
Console.WriteLine(result);

static class StringExtension
{
  public static string ToTitleCase(this string str)
  {
    string[] words = str.Split(" ");
    List<string> newWords = new List<string>();

    foreach (var word in words)
    {
      char[] chars = word.ToCharArray();
      if (char.IsLower(chars[0]))
      {
        chars[0] = char.ToUpper(chars[0]);
      }

      newWords.Add(new string(chars));
    }

    return string.Join(" ", newWords);
  }
}
