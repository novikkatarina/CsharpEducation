using Тask7;

Rectangle r = new Rectangle(10, 5);
Circle c = new Circle(3);
Triangle t = new Triangle(6, 4);

List<Shape> shapes = new List<Shape> { r, c, t };

foreach (var shape in shapes)
{
  Console.WriteLine($"Площадь фигуры {shape.GetType().Name} : {shape.CalculateArea()}");
}
