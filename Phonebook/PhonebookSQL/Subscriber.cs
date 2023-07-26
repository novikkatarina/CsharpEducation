namespace PhonebookSQL;

public class Subscriber
{
  public string? Name { set; get; }
  public string? Number { set; get; }
  
  public Subscriber(string name, string number)
  {
    Name = name;
    Number = number;
  }
  
}
