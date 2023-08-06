namespace Task5;

public class Circle : Shape
{
  public int Radius { set; get; }

  public Circle(string Name, int radius) : base(Name)
  {
    this.Radius = radius;
  }
  public override void Draw()
  {
    base.Draw();
    Console.WriteLine($"Радиус этого круга равен {Radius}");
  }
}
