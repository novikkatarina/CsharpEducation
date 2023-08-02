namespace PracticTask3.Task1;

public class Rectangle : Shape
{
  public override double CalculateArea(double a, double b)
  {
    double S = a * b;
    Console.WriteLine($"Площадь прямоугольника = {S}");
    return S;
  }
}
