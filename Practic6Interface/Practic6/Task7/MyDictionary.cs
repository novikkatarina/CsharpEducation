using System.Collections;

namespace Task7;

public class MyDictionary : IEnumerable
{
  public Dictionary<string, int> Items { set; get; }


  public MyDictionary(Dictionary<string, int> dict)
  {
    Items = dict;
  }


  public IEnumerator GetEnumerator() => new MyDictionaryEnumerator(Items);
}

class MyDictionaryEnumerator : IEnumerator
{
  private Dictionary<string, int> dictionary;
  private IEnumerator<KeyValuePair<string, int>> enumerator;

  public MyDictionaryEnumerator(Dictionary<string, int> items)
  {
    dictionary = items;
    enumerator = dictionary.GetEnumerator();
  }

  public bool MoveNext()
  {
    return enumerator.MoveNext();
  }

  public void Reset()
  {
    this.enumerator.Reset();
  }

  public object Current => enumerator.Current;
}
