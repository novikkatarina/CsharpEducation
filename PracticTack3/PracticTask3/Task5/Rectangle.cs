namespace Task5;

public class Rectangle : Shape
{
  public int Square { set; get; }

  public Rectangle(string Name, int square) : base(Name)
  {
    this.Square = square;
  }

  public override void Draw()
  {
    base.Draw();
    Console.WriteLine($"Площадь этого прямоугольника равна {Square}");
  }
}
