namespace Task9;

// Создайте класс "Человек" (Person) с полями "Имя" (Name) и "Возраст"
//   (Age). Переопределите методы "ToString()", "Equals()" и "GetHashCode()"
// из класса Object, чтобы они возвращали информацию об объекте в виде
//   строки, проверяли эквивалентность двух объектов "Человек" и
//   генерировали уникальный хэш-код для каждого объекта, соответственно.
// Создайте несколько экземпляров класса "Человек" и проверьте работу
// переопределенных методов, например, сравнивая объекты на
// эквивалентность и выводя информацию о каждом объекте с помощью
//   метода "ToString()".

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
    return base.ToString($"Имя: {Name}");
  }

  public override bool Equals(object? obj)
  {
    return base.Equals(obj);
  }

  public override int GetHashCode()
  {
    return base.GetHashCode();
  }
}
