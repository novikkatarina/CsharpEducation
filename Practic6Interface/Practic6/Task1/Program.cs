using Task1;

//   Интерфейсы
//   Реализуйте методы интерфейса `IStorage<T>` в классе `ListStorage<T>`:
//   Добавление элемента в хранилище должно быть реализовано с помощью метода
//   `Add()` коллекции `List<T>`.
//   Получение элемента из хранилища по индексу должно быть реализовано с
//   помощью индексатора коллекции `List<T>`.
//   Количество элементов в хранилище должно быть реализовано с помощью свойства
//   `Count` коллекции `List<T>`.

ListStorage<int> list = new ListStorage<int> { 1, 2, 3 };

list.Add(4);
var x = list.Get(2);
Console.WriteLine(x);
list.Add(4);

foreach (var item in list)
{
  Console.Write(item);
}

