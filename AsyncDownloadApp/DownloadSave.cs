using System.ComponentModel;
using System.Net;

namespace AsyncDownloadApp;

/// <summary>
/// Скачивает и сохраняет файл.
/// </summary>
public class DownloadSave {
  /// <summary>
  /// Асинхронная задача для скачивания и сохранения файла.
  /// </summary>
  /// <param name="path">URL путь для скачивания файлаю</param>
  /// <param name="name">Имя файла для сохраннения.</param>
  public async Task AsyncDownloadSave(string path, string name)
  {
    try
    {
      using var client = new WebClient();
      DateTime time = DateTime.Now;
      Console.WriteLine($"Started {name} at {time:hh:mm:ss.fff}");
      client.DownloadFileCompleted += (sender, args) =>
        DownloadFileCallback(name, time, sender, args);

      await client.DownloadFileTaskAsync(new Uri(path), name);
    }
    catch (Exception)
    {
      Console.WriteLine("При загрузке возникла ошибка");
    }

    /// Обработчик события.
    void DownloadFileCallback(string fileName, DateTime startTime,
      object? sender,
      AsyncCompletedEventArgs asyncCompletedEventArgs)
    {
      DateTime timeOfFinishing = DateTime.Now;
      Console.WriteLine(
        $"Finished {fileName} at {timeOfFinishing:hh:mm:ss.fff}");
      Console.WriteLine(
        $"Elapsed time for {fileName} is {timeOfFinishing - startTime}");
      if (asyncCompletedEventArgs.Cancelled)
      {
        Console.WriteLine("File download cancelled.");
      }

      if (asyncCompletedEventArgs.Error != null)
      {
        Console.WriteLine(asyncCompletedEventArgs.Error.ToString());
      }
    }
  }
}
