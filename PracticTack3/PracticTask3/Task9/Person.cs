namespace Task9;

public class Person
{
  public string Name { set; get; }
  public int Age { set; get; }

  public Person(string name, int age)
  {
    this.Name = name;
    this.Age = age;
  }

  public override string ToString()
  {
    return $"Name: {this.Name}, Age: {this.Age}";
  }

  public override bool Equals(object? obj)
  {
    if (obj is Person)
    {
      Person person2 = ( Person )obj;
      if (( person2.Name == this.Name ) & ( person2.Age == this.Age ))
      {
        return true;
      }
    }

    return false;
  }

  public override int GetHashCode()
  {
    return HashCode.Combine(Name, Age);
  }
}
