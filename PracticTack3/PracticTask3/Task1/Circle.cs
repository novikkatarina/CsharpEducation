namespace Task1;

public class Circle : Shape
{
  public override double CalculateArea(double D)
  {
    double S = Math.PI * Math.Pow(D, 2)/ 4;
    Console.WriteLine($"Площадь круга = {S}");
    return S;
  }
}
