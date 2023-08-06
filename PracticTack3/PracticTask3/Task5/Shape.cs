namespace Task5;

// 5. Создайте базовый класс `Shape` (Фигура) с виртуальным методом
// `Draw()`, который выводит информацию о фигуре. Создайте производные
// классы `Circle` (Круг) и `Rectangle` (Прямоугольник), которые
// переопределят метод `Draw()` и добавят свою специфичную
// информацию. Создайте объекты каждого класса и вызовите их методы
// `Draw()`.

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
  public virtual void Draw(){
    Console.WriteLine($"Красивая фигура {this.Name}.");
  }
}