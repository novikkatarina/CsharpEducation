using System.Text;

namespace Task12;

public class MyDictionary<T, K>
{
  public List<KeyValuePair<T, K>> List { set; get; }
  public KeyValuePair<T, K> Pair { set; get; }

  public MyDictionary()
  {
    this.List = new List<KeyValuePair<T, K>>();
  }

  public void Add(T key, K value)
  {
    Pair = new KeyValuePair<T, K>(key, value);
    List.Add(Pair);
  }

  public bool Remove(T key, K value)
  {
    int countRemoved = List.RemoveAll(pair =>
      pair.Key.Equals(key) && pair.Value.Equals(value));
    if (countRemoved == 0)
    {
      Console.WriteLine("No such element");
      return false;
    }

    return true;
  }


  public bool ContainsKey(T key)
  {
    return List.Exists(pair => pair.Key.Equals(key));
  }

  public K TryGetValue(T key, out K value)
  {
    foreach (var pair in List)
    {
      if (EqualityComparer<T>.Default.Equals(pair.Key, key))
      {
        value = pair.Value;
        return value;
      }
    }

    value = default(K);
    return default(K);
  }

  public override string ToString()
  {
    var stringBuilder = new StringBuilder();
    foreach (var pair in List)
    {
      stringBuilder.Append($"({pair.Key} {pair.Value})");
    }

    return stringBuilder.ToString();
  }
}
