namespace Тask7;

public class Rectangle : Shape
{
  private double length;
  private double width;

  public Rectangle(double length, double width)
  {
    this.length = length;
    this.width = width;
  }

  public override double CalculateArea()
  {
    return length * width;
  }
}
