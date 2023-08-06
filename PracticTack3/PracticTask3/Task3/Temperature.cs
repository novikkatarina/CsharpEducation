namespace Task3;

public class Temperature
{
  public double temperature;

  public Temperature(double t)
  {
    temperature = t;
  }

  //Неявное преобразование из Temperature в double (из цельсия в Фаренгейт). 
  public static implicit operator double(Temperature t)
  {
    return ( t.temperature * ( 9.0 / 5.0 ) ) + 32;
  }

  // Явное преобразование из double в Temperature. 
  // Из Цельсия в фаренгейт.
  public static explicit operator Temperature(double b) => new Temperature(
    ( b * ( 9.0 / 5.0 ) ) + 32);

  //Неявное преобразование из Temperature в float (Из фаренгейт в Цельсия.). 
  public static implicit operator float(Temperature t)
  {
    return ( float )( ( t.temperature - 32 ) * ( 5.0 / 9.0 ) );
  }

  // Явное преобразование из float в Temperature.
  // Из фаренгейт в Цельсия.
  public static explicit operator Temperature(float b) => new Temperature(
    ( b - 32 ) * ( 5.0 / 9.0 ));

  public override string ToString() => $"{this.temperature}";
}
