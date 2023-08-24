namespace Task6;

public class Cat : Animal
{
  public const int maxSpeed = 15;

  public override void Move()
  {
    base.Move();
    Console.WriteLine($"Максимальная скорость кошки {maxSpeed}.");
  }
}
