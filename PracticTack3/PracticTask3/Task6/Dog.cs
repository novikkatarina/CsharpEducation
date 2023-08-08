namespace Task6;

public class Dog : Animal
{
  public const int maxSpeed = 20;

  public override void Move()
  {
    base.Move();
    Console.WriteLine($"Максимальная скорость cобаки {maxSpeed}.");
  }
}
