// 1. Создайте программу, которая принимает список чисел и сортирует его в
// порядке возрастания или убывания. Позвольте пользователю выбрать с
// помощью делегата `Comparison<T>` порядок сортировки. Создайте
//   методы, которые будут вызываться в качестве аргумента делегата для
//   сравнения чисел и передайте их в метод сортировки.

int ZeroCompare(int x, int y)
{
  return x.CompareTo(y) * 0;
}

int ReverseCompare(int x, int y)
{
  return x.CompareTo(y) * -1;
}

int DirectCompare(int x, int y)
{
  return x.CompareTo(y);
}

var orderByAscending = new Comparison<int>(DirectCompare);
var orderByDescending = new Comparison<int>(ReverseCompare);
var keepUnsorted = new Comparison<int>(ZeroCompare);

var array = new int[] { 4, 3, 2, 6, 8, 1, 0 };
string input = null;

do
{
  Console.WriteLine(
    "Выберите тип cортировки. 1 - по возратанию, 2 - по убванию");
  input = Console.ReadLine();
  switch (input)
  {
    case "1":
      Array.Sort(array, orderByAscending);
      break;
    case "2":
      Array.Sort(array, orderByDescending);
      break;
  }
} while (!( input == "1" || input == "2" ));

foreach (var number in array)
{
  Console.Write($"{number} ");
}
