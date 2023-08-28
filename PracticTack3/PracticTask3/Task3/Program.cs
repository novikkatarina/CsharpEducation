using Task3;

Temperature t = new Temperature(10.0);

// неявное преобразование 
// implicit неявное C => F
double temp = t;
Console.WriteLine(temp);

// explicit - явное
// явное преобразование C => F
double d = 10;
Temperature t2 = ( Temperature )d;
Console.WriteLine($"{t2}");

// implicit 
// F => C 
Temperature f3 = new Temperature(50.0);
float f = f3;
Console.WriteLine(f);

//explicit
// F => C
float f2 = 50;
Temperature t3 = (Temperature)f2;
Console.WriteLine($"{t3}");
