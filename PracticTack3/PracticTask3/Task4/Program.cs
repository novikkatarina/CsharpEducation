using Task4;

Distance dist = new Distance(10.0);

//Неявное преобразование из Distance в double (из m в km).
double d = dist;
Console.WriteLine(d);

// Явное преобразование из m в km. 
// из double в Distance.
double dist2 = 10.0;
Distance d2 = ( Distance )dist2;
Console.WriteLine($"{d2}");

Distance distkm = new Distance(1000);
//Неявное преобразование из Distance в float (Из km в m.). 
float distance = distkm;
Console.WriteLine(distance);

// Явное преобразование из float в Distance.
// Из km в m.
Distance distance2 = ( Distance )distance;
Console.WriteLine($"{distance2}");
