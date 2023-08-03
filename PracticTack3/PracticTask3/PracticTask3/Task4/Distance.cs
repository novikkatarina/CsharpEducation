namespace PracticTask3.Task4;

// Создайте класс `Distance` (Расстояние), который представляет
// расстояние в метрах. Реализуйте операторы явного и неявного
//   преобразования типов для конвертации расстояния в километры и
// наоборот. Создайте объекты класса `Distance` с разными значениям

public class Distance
{
  public double distance;
  
  public Distance(double d)
  {
    this.distance = d;
  }
  
  
  //Неявное преобразование из double в Temperature (из цельсия в Фаренгейт). 
  public static implicit operator double(Distance d)
  {
    return ( d.distance * ( 9.0 / 5.0 ) ) + 32;
  }

  // Явное преобразование из Temperature в double. 
  // Из Цельсия в фаренгейт.
  public static explicit operator Distance(double b) => new Distance(
    ( b * ( 9.0 / 5.0 ) ) + 32);

  //Неявное преобразование из double в Temperature (Из фаренгейт в Цельсия.). 
  public static implicit operator float(Distance t)
  {
    return ( float )( ( t.temperature - 32 ) * ( 5.0 / 9.0 ) );
  }

  // Явное преобразование из Temperature в double. 
  // Из фаренгейт в Цельсия.
  public static explicit operator Distance(float b) => new Temperature(
    ( b - 32 ) * ( 5.0 / 9.0 ));

  public override string ToString() => $"{this.temperature}";
}
