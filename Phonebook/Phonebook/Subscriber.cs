namespace Phonebook;

public class Subscriber
{
    // public static string name;
    public string Name { set; get; }
    public string Number { set; get; }

    public Subscriber(string name, string number)
    {
        Name = name;
        Number = number;
    }

    public override string ToString()
    {
        string str = $"{Name} {Number}";
        return str;
    }
}