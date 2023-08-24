using Task9;

Person person1 = new Person("Klian", 25);
Person person2 = new Person("Sutya", 34);
Person person3 = new Person("Klian", 25);
Console.WriteLine(person1);
bool l = person1.Equals(person3);
Console.WriteLine(l);
Console.WriteLine(person1.GetHashCode());
Console.WriteLine(person3.GetHashCode());
