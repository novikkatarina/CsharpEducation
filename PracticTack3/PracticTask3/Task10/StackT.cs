namespace Task10;

public class Stack<T>
{
  private List<T> Container { set; get; }
  private int count;
  private int size;

  public Stack(int size)
  {
    List<T> conteiner = new List<T>();
    this.Container = conteiner;
    this.count = -1;
    this.size = size;
  }

  public void Push(T number)
  {
    count++;
    if (this.count >= size)
    {
      throw new StackOverflowException
        ("Stack overflow");
    }

    Container.Add(number);
  }

  public T Pop()
  {
    if (Container is null)
    {
      throw new InvalidOperationException("Empty stack");
    }

    T poped = Container[count];
    Container.RemoveAt(count);
    count--;
    return poped;
  }

  public T Peek()
  {
    if (Container is null)
    {
      throw new InvalidOperationException("Empty stack");
    }

    return Container[count];
  }
}
