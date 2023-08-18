using System.Collections;

namespace Task7;

public class MyDictionary : IEnumerable
{
  public Dictionary<string, int> Items { set; get; }

  public IEnumerator GetEnumerator() => new MyDictionaryEnumerator(Items);

  public MyDictionary(Dictionary<string, int> dict)
  {
    Items = dict;
  }
}

class MyDictionaryEnumerator : IEnumerator
{
  private Dictionary<string, int> dictionary;
  private IEnumerator<KeyValuePair<string, int>> enumerator;


  public bool MoveNext()
  {
    return enumerator.MoveNext();
  }

  public void Reset()
  {
    this.enumerator.Reset();
  }

  public object Current => enumerator.Current;

  public MyDictionaryEnumerator(Dictionary<string, int> items)
  {
    this.dictionary = items;
    this.enumerator = dictionary.GetEnumerator();
  }
}
