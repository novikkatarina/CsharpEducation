namespace Task5;

public abstract class Shape
{
  public Shape()
  {
  }

  public string Name { set; get; }

  public Shape(string name)
  {
    this.Name = name;
  }

  public virtual void Draw()
  {
    Console.WriteLine($"Красивая фигура {this.Name}.");
  }
}
