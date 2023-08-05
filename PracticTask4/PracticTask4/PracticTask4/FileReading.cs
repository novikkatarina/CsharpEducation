using System.Reflection;
using Newtonsoft.Json;

namespace PracticTask4;

// 4. Создайте программу, которая считывает данные из текстового файла.
// Добавьте обработку исключений для случаев, когда файл не существует
// или содержит некорректные данные. Если возникает исключение,
// программа должна вывести сообщение об ошибке и запросить у
// пользователя корректный путь к файлу или исправить данные в файле.
using System.IO;
using System.Text.Json;

public class FileReading
{
  string path = Path.Combine(
  Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
  "FileToRead.txt");
  // public const string path =
  //   "/FileReading.txt";

  public void Read()
  {
    bool isCorrect = false;
    do
    {
      Console.WriteLine("Введите путь");
      string userPath = Console.ReadLine();
      string a =
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      string userPath2 = Path.Combine(a, userPath);
      string jsonString = String.Empty;
      try
      {
        if (userPath2 != path)
        {
          throw new ArgumentException("Неправильный путь.");
        }

        //Попытка десериализовать объект по ссылке в json - если формат не совпадет из-за ошибок внутри файла - будет ошибка JsonReaderException
        string content = File.ReadAllText(path);
        var jsonObject = JsonConvert.DeserializeObject(content);
        
        using (StreamReader sr = new StreamReader(path))
        {
          string line = sr.ReadLine();
          //Continue to read until you reach end of file
          while (line != null)
          {
            //write the line to console window
            Console.WriteLine(line);
            //Read the next line
            line = sr.ReadLine();
          }
        }
      }
      catch (ArgumentException e)
      {
        Console.WriteLine(e.Message);
        continue;
      }

      catch (JsonReaderException e)
      {
        Console.WriteLine(
          "Ошибка при чтении JSON. Исправьте следующие ошибки:" + e.Message);
        continue;
      }
      catch (JsonException e)
      {
        Console.WriteLine("Ошибка при чтении JSON:" + e.Message);
        continue;
      }
      catch (FileNotFoundException)
      {
        Console.WriteLine(
          $"Файл по пути {path} не найден. Введите корректный путь.");
        continue;
      }
      catch (FormatException)
      {
        Console.WriteLine("Формат данных некорректен.");
        continue;
      }
      catch (Exception e)
      {
        Console.WriteLine($"Generic Exception Handler: {e}");
        continue;
      }

      // Console.WriteLine(jsonString);
      isCorrect = true;
    } while (!isCorrect);

    Console.WriteLine("123");
  }
}
