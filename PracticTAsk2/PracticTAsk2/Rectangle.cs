namespace PracticTAsk2
{
    // 8. Cоздай структуру "Прямоугольник" с полями "Ширина" и "Высота" типа double.
    // Напиши метод, который будет вычислять площадь прямоугольника.
    
    public struct Rectangle
    {
        public double width;
        public double height;

        public Rectangle(double width, double height)
        {
            this.height = height;
            this.width = width;
        }

        public double Square()
        {
            double sq = height * width;
            return sq;
        }
    }
}