using Task12;

MyDictionary<int, string> dict1 = new MyDictionary<int, string>();
MyDictionary<int, string> dict2 = new MyDictionary<int, string>();

dict1.Add(1, "One");
dict1.Add(2, "Two");
dict1.Add(22, "Twotwo");
dict2.Add(3, "Three");
dict2.Add(4, "Four");
dict2.Add(33, "Three");
dict2.Add(44, "Fourfour");

Console.WriteLine(dict1);
Console.WriteLine(dict2);

dict2.Remove(33, "Three");
dict2.Remove(34, "Threefour");

Console.WriteLine(dict2);
Console.WriteLine(dict2.ContainsKey(3));
dict2.TryGetValue(3, out string k);
Console.WriteLine(k);
