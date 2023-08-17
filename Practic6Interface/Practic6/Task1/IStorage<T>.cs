namespace Task1;

public interface IStorage<T>
{
  public void Add(T item){}
  public T Get(int index) {
    return default;
  }
  public int Count { get; }
}
