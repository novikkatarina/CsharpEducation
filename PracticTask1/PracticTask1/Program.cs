using System;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;

namespace PracticTask1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Любой метод вызывается по имени без аргументов, кроме следующих.

            // // Для таска 9.
            // if (args.Length != 2) return; //ввод первой строки "", символ отдельно без "".
            // string arg1 = args[0];
            // char arg2 = char.Parse(args[1]);
            // Task9_3(arg1, arg2);

            // // Для таска 10.
            // int arg1 = int.Parse(args[0]);
            // Task13(arg1);

            // // Для таска 14.
            // int arg1 = int.Parse(args[0]);
            // int arg2 = int.Parse(args[0]);
            // Task14(arg1, arg2);

            //Task15(args);
            
            //Task25.
            
            // Animal cat = new Animal("Zaika", "meow", "fish", "ball");
            // Animal dog = new Animal("Jason", "gav", "meat", "ball");
        }

        // 1. Объявите переменную следующего вида:
        // a. целочисленная переменная, обозначающая возраст.
        //     b. строковая переменная для обозначения имени.
        //     c. строковая переменная для обозначения названия компании.
        //     d. переменная логического типа.
        //     e. переменная типа с плавающей точкой для обозначения веса тела
        // человека.

        static void Task1_1()
        {
            int age;
            string name;
            string company;
            bool n;
            double weight;
        }

        // 2. Объявите и инициализируйте переменную следующего вида:
        // a. переменная для обозначения возраста человека, имеющая значение
        //     вашего возраста.
        //     b. переменная, обозначающая ваше имя.
        //     c. переменная для обозначения температуры за окном
        // d. переменная логического типа, обозначающая принадлежность к
        // женскому полу.
        
        static void Task2()
        {
            int myAge = 32;
            string myName = "Katarina";
            double temperature = 25.5;
            bool isFemale = true;
        }


        // 3. Напишите цикл следующего вида:
        // a. цикл for. Пусть он выводит в консоль значение своего же счётчика.
        //     b. цикл while. Пусть он выводит в консоль значение своего же счётчика.
        //     c. цикл do while. Пусть он выводит в консоль значение своего же счётчика.
        //     d. цикл for, в котором у пользователя запрашиваются слова, затем
        // выводится полная фраза, слова в которой разделены пробелами.
        //     e. цикл while, в котором у пользователя запрашиваются слова, затем
        // выводится полная фраза, слова в которой разделены пробелами.
        //     f. цикл do while, в котором у пользователя запрашиваются слова, затем
        // выводится полная фраза, слова в которой разделены пробелами.


        static void Task3_1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }

            int j = 0;
            while (j < 5)
            {
                Console.WriteLine(j);
                j++;
            }
        }

        static void Task3_3()
        {
            int number;
            do
            {
                Console.WriteLine("Как много слов?");
                number = int.Parse(Console.ReadLine());
            } while (!(number > 0));

            StringBuilder sentence = new StringBuilder();
            int u = 0;
            while (u < number)
            {
                Console.WriteLine("Введите слово");
                string word = (Console.ReadLine());
                sentence.Append(word + " ");
                u++;
            }

            Console.WriteLine(sentence);
        }


        static void Task3_4()
        {
            Console.WriteLine("Как много слов?");
            int number2 = int.Parse(Console.ReadLine());
            StringBuilder sentence2 = new StringBuilder();
            
            for (int u2 = 0; u2 < number2; u2++)
            {
                Console.WriteLine("Введите слово");
                string word = (Console.ReadLine());
                sentence2.Append(word + " ");
            }

            Console.WriteLine(sentence2);
        }

        static void Task3_5()
        {
            Console.WriteLine("Как много слов?");
            int number3 = int.Parse(Console.ReadLine());
            StringBuilder sentence3 = new StringBuilder();
            int u3 = 0;
            
            do
            {
                Console.WriteLine("Введите слово");
                string word = (Console.ReadLine());
                sentence3.Append(word + " ");
                u3++;
            } while (u3 < number3);

            Console.WriteLine(sentence3);
        }


        // Напишите программу, которая переводит:
        // a. метры в километры
        //     b. километры в сантиметры
        // c. м/с в км/ч
        //     d. градусы C в градусы F

        static void Task4_1()
        {
            Console.WriteLine("Сколько?");
            int meters = int.Parse(Console.ReadLine());
            int kilometers = meters * 1000;
        }

        static void Task4_2()
        {
            Console.WriteLine("Сколько?");
            int km = int.Parse(Console.ReadLine());
            int sm = km * 100000;
        }

        static void Task4_3()
        {
            Console.WriteLine("Сколько?");
            int metersPerSecond = int.Parse(Console.ReadLine());
            double kmPerHour = metersPerSecond * 3.6;
        }

        static void Task4_4()
        {
            Console.WriteLine("Сколько?");
            int degreeC = int.Parse(Console.ReadLine());
            double degreeF = 1.8 * degreeC + 32;
        }

        // 5. Напишите программу для вычисления теоремы Пифагора для разных
        // вариаций:
        // a. дано два катета
        //     b. дана гипотенуза и один катет

        static void Task5_1()
        {
            Console.WriteLine("Что дано?");
            Console.WriteLine("1 - два катета");
            Console.WriteLine("2 - гипотенуза и один катет");
            int version = int.Parse(Console.ReadLine());
            
            if (version == 1)
            {
                Console.WriteLine("Введите длину первого катета");
                int side1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите длину второго катета");
                int side2 = int.Parse(Console.ReadLine());
                double hypotenuse = Math.Sqrt(Math.Pow(side1, 2) + Math.Pow(side2, 2));
                Console.WriteLine(hypotenuse);
            }

            if (version == 2)
            {
                Console.WriteLine("Введите длину первого катета");
                int side1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите длину гипотенузы");
                int hypotenuse = int.Parse(Console.ReadLine());
                double side2 = Math.Sqrt(Math.Pow(hypotenuse, 2) - Math.Pow(side1, 2));
                Console.WriteLine(side2);
            }
        }

        //
        // 6. Напишите программу для вычисления выражения (а + b — f / а) + f * a * a — (a +
        // b). Все переменные задаются пользователем. Учтите деление на 0.

        static void Task6()
        {
            int numericA;
            int numericB;
            int numericF;

            bool isANumeric;
            bool isBNumeric;
            bool isFNumeric;

            do
            {
                Console.WriteLine("Введите a");
                var aString = Console.ReadLine();
                isANumeric = int.TryParse(aString, out numericA);

                Console.WriteLine("Введите b");
                var bString = Console.ReadLine();
                isBNumeric = int.TryParse(bString, out numericB);

                Console.WriteLine("Введите f");
                var fString = Console.ReadLine();
                isFNumeric = int.TryParse(fString, out numericF);
            } while ((isANumeric == false) || (isBNumeric == false) || (isFNumeric == false) || (numericF == 0));

            int result = (numericA + numericB - numericF / numericA) + numericF * numericA * numericA -
                         (numericA + numericB);
            Console.WriteLine($"result = {result}");
        }

        // 7. Нарисуйте прямоугольный треугольник звёздочками. Чтобы высоту
        //     треугольника можно было задавать программно. Пример:
        // a. *
        // **
        // ***
        // ****
        // и тд
        // b. *
        // **
        // ***
        // ****
        // и тд
        // c. Дайте возможность задавать символ для отрисовки программно. Т.е.
        //     вместо звёздочки может быть любой символ.

        static void Task7()
        {
            Console.WriteLine("Введите количество *");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Какой треугольник? 1 - левосторонний, 2 - правосторонний");
            int orientation = int.Parse(Console.ReadLine());
            StringBuilder lines = new StringBuilder();
            if (orientation == 1)
            {
                for (int i = 0; i < number; i++)
                {
                    lines.Append("* ");
                    Console.WriteLine(lines);
                }
            }

            if (orientation == 2)
            {
                for (int i = 0; i < number; i++)
                {
                    StringBuilder space = new StringBuilder();
                    for (int j = 0; j < number - i - 1; j++) space.Append(" ");
                    lines.Append("*");
                    Console.WriteLine($"{space}{lines}");
                }
            }
        }

        // 8. Напишите программу для сравнения двух целых чисел. Ввод осуществляйте
        // через консоль.

        static void Task8()
        {
            Console.WriteLine("Введите число");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите число");
            int b = int.Parse(Console.ReadLine());
        }

        // 9. Введите с клавиатуры строку произвольной длины и подсчитайте процент
        //     вхождения заданного символа в строку.
        //     a. строка и символ указываются программно
        // b. строка и символ указываются пользователем в консоли
        //c. строка и символ указываются через аргументы командной строки

        static void Task9_1()
        {
            string text = Console.ReadLine();
            char a = '1';
            int lenghthText = text.Length;
            int count = 0;
            foreach (char character in text)
            {
                if (character == a) count++;
            }

            double percent = (double)count / lenghthText * 100;
            Console.WriteLine(percent);
        }

        static void Task9_2()
        {
            Console.WriteLine("Insert string");
            string text = Console.ReadLine();
            Console.WriteLine("Insert char");
            char a = char.Parse(Console.ReadLine());
            int lenghthText = text.Length;
            int count = 0;
            foreach (char character in text)
            {
                if (character == a) count++;
            }

            double percent = (double)count / lenghthText * 100;
            Console.WriteLine(percent);
        }

        static void Task9_3(string text, char a)
        {
            int lenghthText = text.Length;
            int count = 0;
            foreach (char character in text)
            {
                if (character == a) count++;
            }

            double percent = (double)count / lenghthText * 100;
            Console.WriteLine(percent);
        }

        // 10. Напишите программу, которая переводит строку в разные регистры
        //     a. в верхний регистр: f -> F
        //     b. в нижний регистр: F -> f
        //     c. делает заглавную букву в слове: привет -> Привет

        static void Task10()
        {
            string text = "раз";
            Console.WriteLine(text.ToUpper());
            Console.WriteLine(text.ToLower());
            StringBuilder sb = new StringBuilder();
            sb.Append(char.ToUpper(text[0]));
            for (int i = 1; i < text.Length; i++)
            {
                sb.Append(text[i]);
            }

            Console.WriteLine(sb);
        }

        // 11. Составить алгоритм увеличения всех трех, введенных с клавиатуры,
        // переменных на 5,если среди них есть хотя бы две равные. В противном случае
        // выдать ответ «равных нет».

        static void Task11()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if ((a == b) || (b == c) || (c == a))
            {
                a += 5;
                b += 5;
                c += 5;
                Console.WriteLine($"{a},{b},{c}");
            }
            else Console.WriteLine("равных нет");
        }

        // 12. Напишите метод, который создаёт массив целых чисел и возвращает его.
        //     Размер массива нужно передавать в качестве аргумента. Вдобавок напишите
        // метод, который выводит переданный массив на экран консоли.
        static int[] Task12(int size)
        {
            int[] a = new int[size];
            for (int i = 0; i < size; i++)
            {
                Random random = new Random();
                a[i] = random.Next(1, 101);
            }

            void print(int[] array)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }

            print(a);

            return a;
        }

        // 13. Напишите программу, в которой создаётся массив и выводится на экран
        //     консоли. Размер массива передавайте в качестве первого аргумента командной
        //     строки.

        static void Task13(int size)
        {
            int[] a = new int[size];
            for (int i = 0; i < size; i++)
            {
                Random random = new Random();
                a[i] = random.Next(1, 101);
            }

            void print(int[] array)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"{array[i]} ");
                }
            }

            print(a);
        }

        // 14. Напишите программу, в которой создаётся массив и выводится на экран
        //     консоли. Размер массива передавайте в качестве первого аргумента командной
        //     строки. Число, которым будет заполняться массив передайте через второй
        //     аргумент командной строки.

        static void Task14(int size, int a)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = a;
            }

            void print(int[] array)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"{array[i]} ");
                }
            }

            print(array);
        }

        // 15. Напишите программу, в которой создаётся массив строк, который заполняется
        //     пользователем через консоль. Затем этот массив должен быть выведен на
        // экран консоли.

        static void Task15(string[] array)
        {
            void print(string[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"{array[i]} ");
                }
            }

            print(array);
        }

        // 16. Напишите метод, который создаёт двумерный массив (не зубчатый). Размеры
        //     массива передавайте через аргументы метода. Также напишите отдельный
        // метод для вывода двумерного массива в виде матрицы на экран консоли.
        //     Массив заполните случайными числами.

        static void Task16(int size)
        {
            int[,] a = new int[size, size];
            Random random = new Random();

            for (int k = 0; k < size; k++)
            {
                for (int l = 0; l < size; l++)
                {
                    a[k, l] = random.Next(1, 101);
                }
            }

            void print(int[,] array)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write($"{array[i, j]} ");
                    }

                    Console.WriteLine("");
                }
            }

            print(a);
        }


        // 17. Создайте одномерный массив целых чисел произвольной длины и заполните
        //     случайными числами от 1 до 100. Выведите на экран разницу максимального и
        // минимального значений в нём.

        static void Task17()
        {
            int[] a = new int[5];
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                a[i] = random.Next(1, 101);
            }

            int max = a.Max();
            int min = a.Min();
            Console.WriteLine(max - min);
        }

        // 18. Создайте двумерный массив целых чисел произвольной длины и заполните
        //     случайными числами от 1 до 100. Выведите на экран разницу максимального и
        // минимального значений в каждой строке массива.

        static void Task18()
        {
            int[,] a = new int[3, 3];
            Random random = new Random();
            StringBuilder sbrow = new StringBuilder();
            for (int k = 0; k < 3; k++)
            {
                for (int l = 0; l < 3; l++)
                {
                    a[k, l] = random.Next(1, 101);
                }
            }

            void print(int[,] array)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($"{array[i, j]} ");
                    }

                    Console.WriteLine("");
                }
            }

            print(a);

            int[] rowMin = new int[3];
            int[] rowMax = new int[3];


            for (int k = 0; k < 3; k++)
            {
                int max = 0;
                int min = 1000;
                for (int l = 0; l < 3; l++)
                {
                    if (a[k, l] < min) min = a[k, l];
                    if (a[k, l] > max) max = a[k, l];
                }

                rowMax[k] = max;
                rowMin[k] = min;
            }

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{rowMax[i] - rowMin[i]} ");
                Console.WriteLine("");
            }
        }

        // 19. Напишите игру Угадай число. Программа случайно генерирует число от 1 до
        // 100, а пользователь пытается угадать это число. При успешной догадке
        // выводите поздравление пользователя.

        static void Task19()
        {
            Random random = new Random();
            int n = random.Next(1, 101);
            int x;
            do
            {
                Console.WriteLine("Введите число");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine("Число неверное");
            } while (x != n);

            Console.WriteLine("Поздравляем!");
        }

        // 20. Напишите игру Угадай число. Программа случайно генерирует число от 1 до
        // 100, а пользователь пытается угадать это число. При успешной догадке
        // выводите поздравление пользователя. Также покажите количество попыток,
        //     принятых пользователем.
        //     a. Сделайте ограничение по попыткам. Например, если попыток больше 10,
        // то пользователь проиграл
        //     b. Сделайте подсказки для пользователя. Если предположенное число
        //     больше загаданного, то писать в консоль об этом. Аналогично и для
        // меньшего числа.

        static void Task20()
        {
            Random random = new Random();
            int n = random.Next(1, 101);
            Console.WriteLine(n);
            int x;
            int attempt = 0;
            do
            {
                Console.WriteLine("Введите число");
                x = int.Parse(Console.ReadLine());
                attempt++;
                Console.WriteLine($"Сделано {attempt} попыток. Осталось ");
                if (attempt > 10)
                {
                    Console.WriteLine("Вы проиграли");
                    return;
                }

                if (x > n) Console.WriteLine("Число неверное. Число больше загаданного");
                else if (x < n) Console.WriteLine("Число неверное. Число меньше загаданного");
            } while (x != n);

            Console.WriteLine("Поздравляем!");
        }

        // 21. Напишите программу для вычисления високосного года.
        // ● год, номер которого кратен 400, — високосный;
        // остальные годы, номер которых кратен 100, — невисокосные
        //     остальные годы, номер которых кратен 4, — високосный;
        // все остальные годы — невисокосные.

        static void Task21()
        {
            int year = 2023;
            int leap = year / 400 - year / 100 + year / 4;
            Console.WriteLine(leap);
        }

        enum DayOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        // 22. Создайте перечисление (enum) для дней недели. Напишите программу, которая
        // выводит на экран дни недели по названиям

        static void Task22()
        {
            foreach (DayOfWeek i in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine(i);
            }
        }


        // 23. Создайте перечисление (enum) для дней недели. Напишите программу, которая
        // считывает ввод пользователя и в зависимости от его ввода (число от 1 до 7) будет
        //     выводиться на экран консоли соответствующий день недели.

        static void Task23()
        {
            Console.WriteLine("Введите число от 1 до 7");
            int input = int.Parse(Console.ReadLine());
            if (Enum.IsDefined(typeof(DayOfWeek), input))
            {
                DayOfWeek day = (DayOfWeek)(input - 1);
                Console.WriteLine("Выбран день недели: " + day);
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Введите число от 1 до 7.");
            }
        }
    }
}