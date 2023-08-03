namespace PracticTask3.Task3;

// 3. Создайте класс `Temperature` (Температура), который представляет
// температуру в градусах Цельсия. Реализуйте операторы явного и
// неявного преобразования типов для конвертации температуры в градусы
// Фаренгейта и наоборот. Создайте объекты класса `Temperature` с
// разными значениями и выполните преобразования типов между
// Цельсием и Фаренгейтом

public class Temperature
{
  public double temperature;

  public Temperature(double t)
  {
    temperature = t;
  }

  //Неявное преобразование из double в Temperature (из цельсия в Фаренгейт). 
  public static implicit operator double(Temperature t)
  {
    return ( t.temperature * ( 9.0 / 5.0 ) ) + 32;
  }

  // Явное преобразование из Temperature в double. 
  // Из Цельсия в фаренгейт.
  public static explicit operator Temperature(double b) => new Temperature(
    ( b * ( 9.0 / 5.0 ) ) + 32);
  // ( b - 32 ) * ( 5.0 / 9.0 )

  //Неявное преобразование из double в Temperature (Из фаренгейт в Цельсия.). 
  public static implicit operator float(Temperature t)
  {
    return ( float )( ( t.temperature - 32 ) * ( 5.0 / 9.0 ) );
  }

  // Явное преобразование из Temperature в double. 
  // Из фаренгейт в Цельсия.
  public static explicit operator Temperature(float b) => new Temperature(
    ( b - 32 ) * ( 5.0 / 9.0 ));

  public override string ToString() => $"{this.temperature}";
}
