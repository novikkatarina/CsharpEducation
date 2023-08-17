namespace Task4;

public class Book : IComparable
{
  public string Title { get; set; }
  public string Author { get; set; }
  
  public int CompareTo(object? obj)
  {
    if (obj is Book book)
    {
      return this.Title.CompareTo(book.Title);
    }
    throw new ArgumentException("Объект должен быть типа Book.");
  }

  public Book(string title, string author)
  {
    this.Title = title;
    this.Author = author;
  }
}
