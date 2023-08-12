string[] arr = new string[] { new("one"), new("two"), new("six"), };

int LengthCompare(string x, string y)
{
  return x.Length.CompareTo(y.Length);
}

int FirstLetterCompare(string x, string y)
{
  return x[0].CompareTo(y[0]);
}

string input = null;

var sortByLength = new Comparison<string>(LengthCompare);

do
{
  Console.WriteLine(
    "Выберите тип cортировки. 1 - по длине, 2 - по алфавиту");
  input = Console.ReadLine();
  switch (input)
  {
    case "1":
      Array.Sort(arr, sortByLength);
      break;
    case "2":
      Array.Sort(arr, FirstLetterCompare);
      break;
  }
} while (!( input == "1" || input == "2" ));

foreach (var word in arr)
{
  Console.Write($"{word} ");
}
