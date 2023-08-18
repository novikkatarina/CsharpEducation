// 1/. Напишите программу, которая принимает два числа от пользователя и
// делит их, выводя результат. Добавьте код для обработки возможных
//   исключений, которые могут возникнуть при делении на ноль или вводе
// неправильных данных. При возникновении исключения, программа
// должна вывести сообщение об ошибке и попросить пользователя ввести
//   корректные данные.

// // Task1 
// double dev = 0;
// bool flag = false;
// do
// {
//   try
//   {
//     Console.WriteLine("Введите число a");
//     int a = Convert.ToInt32(Console.ReadLine());
//     Console.WriteLine("Введите число b");
//     int b = Convert.ToInt32(Console.ReadLine());
//     dev = ( double )a / b;
//     if (b == 0)
//     {
//       throw new DivideByZeroException();
//     }
//   }
//   catch ( Exception ex) when(ex is DivideByZeroException ||
//                              ex is FormatException)
//   {
//     Console.WriteLine("Числа введены неверно!");
//     continue;
//   }
//
//   flag = true;
// } while (!flag);
//
// Console.WriteLine(dev);

// //Task2
//
// using PracticTask4;
//
// BankAccount b = new BankAccount();
// bool flag2 = false;
// do
// {
//   int choice = 0;
//   try
//   {
//     Console.WriteLine("Следующее действие : 1-Положить деньги, 2-Снять деньги");
//     string inputChoice = Console.ReadLine();
//     choice = Int32.Parse(inputChoice);
//   }
//   catch (FormatException)
//   {
//     Console.WriteLine("Неправильный формат ввода");
//     continue;
//   }
//
//   if (choice == 1) b.AddDeposit();
//   if (choice == 2) b.WithdrawalDeposit();
// } while (!flag2);

//Task3.

// using PracticTask4;
//
// Person p = new Person();
// p.CheckAge();

//Task4

using PracticTask4;

FileReading file = new FileReading();
file.Read();


// using System.Reflection;

// string path =
//   Path.Combine(
//     Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "FileToRead.txt");
//
// // string jsonString = JsonSerializer.Serialize(path);
//
//  using (StreamReader sr = new StreamReader(path))
//  {
//    string line = sr.ReadLine();
//    //Continue to read until you reach end of file
//    while (line != null)
//    {
//      //write the line to console window
//      Console.WriteLine(line);
//      //Read the next line
//      line = sr.ReadLine();
//    }
//
//    //close the file
//    sr.Close();
//  }