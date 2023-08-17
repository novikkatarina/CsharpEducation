using Task7;

var dict = new Dictionary<string, int>
{
  { "one", 1 }, { "two", 2 }, { "three", 3 }
};

MyDictionary myDictionary = new MyDictionary(dict);
//myDictionary.Items;

foreach (KeyValuePair<string, int> item in myDictionary)
{
  Console.WriteLine($"{item.Key} {item.Value}");
}