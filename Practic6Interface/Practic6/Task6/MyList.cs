using System.Collections;

namespace Task6;

public class MyList : IEnumerable
{
  public List<int> Items { set; get; }
  
  public IEnumerator GetEnumerator()
  {
    for (int i = 0; i < this.Items.Count; i++)
    {
      yield return Items[i];
    }
  }

  public MyList()
  {
    this.Items = new List<int>();
  }
}
