using System.ComponentModel;
using System.Net;

namespace AsyncDownloadApp;

/// <summary>
/// Загрузчик-сохранитель.
/// </summary>
public class DownloaderSaver
{
  /// <summary>
  /// Скачивает и сохраненяет файл по ссылке.
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
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }

  /// <summary>
  /// Обрабатывает событие.
  /// </summary>
  /// <param name="fileName">Имя сохраняемого файла.</param>
  /// <param name="startTime">Время начала загрузки.</param>
  /// <param name="sender">Объект, генерирующий событие.</param>
  /// <param name="asyncCompletedEventArgs">Класс, предоставляющий данные о событии.</param>
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
