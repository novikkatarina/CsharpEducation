using Task1;

ListStorage<int> list = new ListStorage<int>{1, 2, 3};

list.Add(4);
Console.WriteLine(list);
var x = list.Get(6);
Console.WriteLine(x);
list.Add(4);
Console.WriteLine(list);