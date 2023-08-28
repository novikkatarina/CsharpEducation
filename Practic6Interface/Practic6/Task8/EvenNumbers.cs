using System.Collections;

namespace Task8;

public class EvenNumbers : IEnumerable
{
  private List<int> Items { get; set; }

  public IEnumerator GetEvenNumbers()
  {
    for (int i = 0; i < this.Items.Count; i++)
    {
      if (Items[i] % 2 == 0)
        yield return Items[i];
    }
  }

  public IEnumerator GetEnumerator()
  {
    return GetEvenNumbers();
  }

  public EvenNumbers(List<int> items)
  {
    Items = items;
  }
}
