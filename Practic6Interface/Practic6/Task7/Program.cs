using Task7;

// Создайте класс "MyDictionary" с полем "Items" типа Dictionary<string, int>. Реализуйте
// интерфейс IEnumerator для этого класса, чтобы можно было перебирать элементы
// словаря.

var dict = new Dictionary<string, int>
{
  { "one", 1 }, { "two", 2 }, { "three", 3 }
};

MyDictionary myDictionary = new MyDictionary(dict);

foreach (KeyValuePair<string, int> item in myDictionary)
{
  Console.WriteLine($"{item.Key} {item.Value}");
}