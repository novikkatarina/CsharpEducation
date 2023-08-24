// See https://aka.ms/new-console-template for more information

// 1. Создайте базовый класс `Shape` (Фигура) с методом `CalculateArea()`,
// который возвращает площадь фигуры. Создайте производные классы
//   `Circle` (Круг) и `Rectangle` (Прямоугольник), которые унаследуют метод
//   `CalculateArea()`. Реализуйте эти методы в соответствии с формулами
// для вычисления площади соответствующих фигур. Создайте объекты
// каждого класса и выведите их площади

using PracticTask3.Task1;

double S1 = new Circle().CalculateArea(2);
double S2 = new Rectangle().CalculateArea(2, 3);
