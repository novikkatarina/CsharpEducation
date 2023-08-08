namespace Task10;

public class Stack<T>
{
  public List<T> Conteiner { set; get; }
  public int count;
  public int size;

  public Stack(int size)
  {
    List<T> conteiner = new List<T>();
    this.Conteiner = conteiner;
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

    Conteiner.Add(number);
  }

  public T Pop()
  {
    if (Conteiner is null)
    {
      throw new InvalidOperationException("Empty stack");
    }

    T poped = Conteiner[count];
    Conteiner.RemoveAt(count);
    count--;
    return poped;
  }

  public T Peek()
  {
    if (Conteiner is null)
    {
      throw new InvalidOperationException("Empty stack");
    }

    return Conteiner[count];
  }
}
