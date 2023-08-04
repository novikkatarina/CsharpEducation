namespace PracticTask4;

// 4. Создайте программу, которая считывает данные из текстового файла.
// Добавьте обработку исключений для случаев, когда файл не существует
// или содержит некорректные данные. Если возникает исключение,
// программа должна вывести сообщение об ошибке и запросить у
// пользователя корректный путь к файлу или исправить данные в файле.
using System.IO;

public class FileReading
{
  public const string path =
    "/Users/user/Katarina/Digit/CsharpEducation/PracticTask4/PracticTask4/PracticTask4/FileReading.txt";

  public string Read()
  {
    Console.WriteLine("Введите путь");
    string UserPath = Console.ReadLine();
    string line;
    try
    {
      if (UserPath != path)
      {
        throw new ArgumentException("Неправильный путь");
      }

      using (StreamReader sr = new StreamReader(UserPath))
      {
        line = sr.ReadLine();
        //Continue to read until you reach end of file
        while (line != null)
        {
          //write the line to console window
          Console.WriteLine(line);
          //Read the next line
          line = sr.ReadLine();
        }

        //close the file
        sr.Close();
      }
    }
    catch (FileNotFoundException)
    {
      Console.WriteLine($"Файл по пути {path} не найден. Введите корректный путь.");
    }
    catch (FormatException)
    {
      Console.WriteLine("Формат данных некорректен.");
    }
    catch (Exception e)
         {
         }
    string text = "";
    return text;
  }
}
