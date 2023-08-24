namespace Task4;

public class Distance
{
  public double distance;

  public Distance(double d)
  {
    this.distance = d;
  }
  
  //Неявное преобразование из Distance в double (из m в km). 
  public static implicit operator double(Distance d)
  {
    return d.distance * 1000;
  }

  // Явное преобразование из m в km. 
  // из double в Distance.
  public static explicit operator Distance(double d) => new Distance(
    d * 1000);

  //Неявное преобразование из Distance в float (Из km в m.). 
  public static implicit operator float(Distance d)
  {
    return ( float )( d.distance / 1000 );
  }

  // Явное преобразование из float в Distance.
  // Из km в m.
  public static explicit operator Distance(float d) => new Distance(
    d / 1000);

  public override string ToString() => $"{this.distance}";
}
