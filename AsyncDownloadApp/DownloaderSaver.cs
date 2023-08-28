using System.ComponentModel;
using System.Net;

namespace AsyncDownloadApp;

/// <summary>
/// Загрузчик-сохранитель.
/// </summary>
public class DownloaderSaver
{
  public class ExecutingAppTimeCharacteristics
  {
    public DateTime StartingTime { set; get; }
    public DateTime TimeOfFinishing { set; get; }
  }


  /// <summary>
  /// Скачивает и сохраненяет файл по ссылке.
  /// </summary>
  /// <param name="path">URL путь для скачивания файлаю</param>
  /// <param name="name">Имя файла для сохраннения.</param>
  public async Task<ExecutingAppTimeCharacteristics> AsyncDownloadSave(
    string path, string name)
  {
    var timeCharacteristics = new ExecutingAppTimeCharacteristics();
    try
    {
      using var client = new WebClient();


      timeCharacteristics.StartingTime = DateTime.Now;
      // Console.WriteLine($"Started {name} at {timeCharacteristics.StartingTime:hh:mm:ss.fff}");
      // client.DownloadFileCompleted += (sender, args) =>
      //   DownloadFileCallback(name, timeCharacteristics.StartingTime, sender, args);
      await client.DownloadFileTaskAsync(path, name);
      timeCharacteristics.TimeOfFinishing = DateTime.Now;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }

    return timeCharacteristics;
  }
}
