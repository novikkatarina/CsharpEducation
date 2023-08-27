namespace Task2;

public class Person : ICloneable
{
  public string Name { set; get; }
  public int Age { set; get; }
  public Company Company { set; get; }

  public object Clone()
  {
    return new Person(this.Name, this.Age, new Company(this.Company.Name));
  }

  public Person(string name, int age, Company company)
  {
    this.Name = name;
    this.Age = age;
    this.Company = company;
  }
}

public class Company
{
  public string Name { set; get; }

  public Company(string name)
  {
    this.Name = name;
  }
}