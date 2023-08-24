namespace Тask7;

public class Triangle : Shape
{
  private double length;
  private double height;

  public Triangle(double length, double height)
  {
    this.length = length;
    this.height = height;
  }

  public override double CalculateArea()
  {
    return 0.5 * length * height;
  }
}
