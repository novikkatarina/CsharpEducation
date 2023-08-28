namespace Task5;

public class Car
{
  public string Mark { set; get; }
  public string Model { set; get; }

  public Car(string mark, string model)
  {
    this.Mark = mark;
    this.Model = model;
  }
}

public class CompareMark : IComparer<Car>
{
  public int Compare(Car? x, Car? y)
  {
    return x.Mark.CompareTo(y.Mark);
  }
}

public class CompareModel : IComparer<Car>
{
  public int Compare(Car? x, Car? y)
  {
    return x.Model.CompareTo(y.Model);
  }
}
