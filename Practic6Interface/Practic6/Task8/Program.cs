using Task8;

//  Создайте метод "GetEvenNumbers", который будет возвращать все четные числа из
//  заданного диапазона. Используйте итератор и команду yield для реализации этого
// метода.

EvenNumbers en = new EvenNumbers(new List<int>() { 0, 1, 2, 3 });

foreach (var item in en)
{
  Console.WriteLine(item);
}
