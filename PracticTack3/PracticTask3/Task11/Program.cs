
// Если передавать индекс - то поменяется лист. Вариант если мы знаем индексы
static void Swap2<T>(List<T> list, int index, int index2)
{
  T temp = list[index];
  list[index] = list[index2];
  list[index2] = temp;
}

//Найти индексы
static void Swap3<T>(List<T> list, T value1, T value2)
{
  int index = list.IndexOf(value1);
  int index2 = list.IndexOf(value2);
  // int index = list.IndexOf(value1);
  // int index2 = list.IndexOf(value1); // еслт ввести в неправильном порядке - индексы тоже будт не в том порядке
  T temp = list[index];
  list[index] = list[index2];
  list[index2] = temp;
}

static void Print<T>(List<T> list)
{
  foreach (var value in list)
  {
    Console.Write($" {value}");
  }
  Console.WriteLine();
}

List<int> list = new List<int>(5);
list.Add(6);
list.Add(8);
Print(list);
Swap2<int>(list, 0, 1);
Print(list);
Swap3(list, 6, 8);
Print(list);

List<string> list2 = new List<string>(5) { "cat", "dog" };
Print(list2);
Print(list);
Swap2<string>(list2, 0, 1);
Print(list2);
Swap3<string>(list2, "cat", "dog");
Print(list);
