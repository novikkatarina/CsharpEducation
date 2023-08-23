using System.Net;

Console.Write("Введите URL-адрес файла: ");
string url = Console.ReadLine();

Console.Write("Введите путь сохранения файла: ");
string path = Console.ReadLine();

await AsyncDownloadSave(url, path);

Console.WriteLine("Файл был успешно загружен и сохранен.");

static async Task AsyncDownloadSave(string path,string name)
{
  try{
    using (var client = new WebClient())
    {
      client.DownloadFile(path,name);
    }
  }
  catch (Exception e)
  {
    Console.WriteLine(e);
    throw;
  }
}