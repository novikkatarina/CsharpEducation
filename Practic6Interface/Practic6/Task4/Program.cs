using Task4;

//   IComparable и IComparer
//   1. Создайте класс "Book" с полями "Title" и "Author". Реализуйте интерфейс
//   IComparable для этого класса, чтобы книги можно было сравнивать по названию.

Book b1 = new Book("jnk", "njk");
Book b2 = new Book("njk", "hkn");

int result = b1.CompareTo(b2);
Console.WriteLine(result);