using System.Collections;

namespace Task1;

public class ListStorage<T> : IStorage<T>, IEnumerable
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
      throw new ArgumentException("Индекс больше допустимого.");
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

  public IEnumerator GetEnumerator()
  {
    for (int i = 0; i < this.List.Count; i++)
    {
      yield return List[i];
    }
  }

}
