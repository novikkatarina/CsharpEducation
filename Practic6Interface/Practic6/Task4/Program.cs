using Task4;

Book b1 = new Book("jnk", "njk");
Book b2 = new Book("njk", "hkn");

int result = b1.CompareTo(b2);
Console.WriteLine(result);