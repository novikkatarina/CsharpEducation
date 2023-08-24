using System;
using System.Runtime.InteropServices;
using ClassLibrary1;

namespace PracticTAsk2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Task 1, 2, 9.
            // Student st = new Student("Barbara", 33);
            // st.Gta = 4;
            // st.ChangeName(st);
            // st.GetStudent();

            //Task 3.
            // int x = Calculator.addition(1, 3);
            // Console.WriteLine(x);

            //Task7.
            // int x = Months.Days(Month.June);
            // Console.WriteLine(x);

            //Task8.
            // Rectangle r = new Rectangle(2, 4);
            // Console.WriteLine(r.Square());
            
            //Task 10.

            // Car c = new Car();
            // c.Brand = "Volvo";
            // c.GetInfo(c);
            
            //Task11.

            // Book b = new Book("DayOfJoy", "Jone");
            // Console.WriteLine(b.GetInfo());

            //Task 12,13.
            
            // int a = 10;
            // int b = 5;
            // int sum = MathHelper.Add(a, b);
            // Console.WriteLine("Sum: " + sum);
            
            //Task 14.

            PersonLib.Person1 man = new PersonLib.Person1();
            man.name = "Jon";
            man.age = 13;
            man.GetInfo();
        }
    }
}