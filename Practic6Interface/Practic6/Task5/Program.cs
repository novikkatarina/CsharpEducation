using Task5;

//  Создайте класс "Car" с полями "Make" и "Model". Реализуйте интерфейс IComparer
//  для этого класса, чтобы можно было сравнивать машины по марке и модели. В
//  задании требуется реализовать несколько вариантов сравнения.

CompareMark cmark = new CompareMark();
CompareModel cmodel = new CompareModel();

List<Car> cars = new List<Car>
{
  new Car("Ati", "Dati"), new Car("Bti", "Cati"),
};

cars.Sort(cmark);
foreach (Car car in cars)
{
  Console.WriteLine($"Mark: {car.Mark}, Model: {car.Model}");
}
cars.Sort(cmodel);

foreach (Car car in cars)
{
  Console.WriteLine($"Mark: {car.Mark}, Model: {car.Model}");
}
