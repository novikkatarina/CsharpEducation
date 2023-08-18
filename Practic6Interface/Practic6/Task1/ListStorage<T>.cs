using System.Collections;
using System.Text;

namespace Task1;

public class ListStorage<T> : IStorage<T>, IEnumerable<int>
{
  public List<T> List { set; get; }

  public void Add(T item)
  {
    List.Add(item);
    Count++;
  }

  public T Get(int index)
  {
    var items = List;
    if (index > Count)
    {
      Console.WriteLine("Индекс больше допустимого.");
      return default;
    }

    T item = items.ElementAt(index);
    return item;
  }

  public int Count { get; set; }

  public ListStorage()
  {
    this.Count = 0;
    this.List = new List<T>();
  }

  public override string ToString()
  {
    StringBuilder sb = new StringBuilder();
    foreach (var item in List)
    {
      sb.Append(item);
    }

    return sb.ToString();
  }

  public IEnumerator<int> GetEnumerator()
  {
    throw new NotImplementedException();
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }
}
