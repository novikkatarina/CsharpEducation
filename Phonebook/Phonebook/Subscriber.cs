namespace Phonebook;

public class Subscriber
{
    public string Name { set; get; }
    public string Phone { set; get; }

    public Subscriber(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }

    public override string ToString()
    {
        string str = $"{Name} {Phone}";
        return str;
    }
}