string[] words = new string[] { "one", "two", "six" };

string[] Transition(string[] words, Func<string[], string[]> operation)
{
  return operation(words);
}

string[] ReverseWords(string[] words)
{
  var result = new List<string>();
  foreach (var word in words)
  {
    char[] charArray = word.ToCharArray();
    Array.Reverse(charArray);
    string reversedWord = new string(charArray);
    result.Add(reversedWord);
  }

  return result.ToArray();
}

string[] DoubleWords(string[] words)
{
  var result = new List<string>();
  foreach (var word in words)
  {
    result.Add(word + word);
  }

  return result.ToArray();
}

string input = "";

do
{
  Console.WriteLine("1 - Reverse Words. 2 - Double Words. 3 - exit.");
  input = Console.ReadLine();

  if (input == "1")
  {
    var reversedWords = Transition(words, ReverseWords);
    foreach (var word in reversedWords)
    {
      Console.WriteLine(word);
    }
  }

  if (input == "2")
  {
    var doubledWords = Transition(words, DoubleWords);
    foreach (var word in doubledWords)
    {
      Console.WriteLine(word);
    }
  }
} while (input != "3");
