using Task5;



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
