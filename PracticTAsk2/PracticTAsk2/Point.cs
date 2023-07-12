using System;

namespace PracticTAsk2

    // 6. Создай структуру "Точка" с полями "X" и "Y" типа int. Напиши метод, который будет
    // принимать две точки и возвращать расстояние между ними.

{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public double distance(Point a, Point b)
        {
            double dist = Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
            return dist;
        }
    }
}