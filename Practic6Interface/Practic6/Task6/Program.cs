using Task6;

// IEnumerable и IEnumerator
// Создайте класс "MyList" с полем "Items" типа List<int>. Реализуйте интерфейс
// IEnumerable для этого класса, чтобы можно было перебирать элементы списка.

MyList list = new MyList();
list.Items.AddRange(new[] { 1, 2, 38, 2, 4 });

foreach (var item in list)
{
  Console.WriteLine(( int )item);
}
