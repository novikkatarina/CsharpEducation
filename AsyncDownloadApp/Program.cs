using System.Net;

bool flag = false;
do
{
  Console.Write("Введите URL-адрес файла: ");
  string url = Console.ReadLine();

  Console.Write("Введите путь сохранения файла: ");
  string path = Console.ReadLine();

  await AsyncDownloadSave(url, path);
  
  Console.WriteLine(" Для выхода - ввести 1.");
  int input = Convert.ToInt32(Console.ReadLine());
  if (input != 1) flag = true;

  Console.WriteLine("Файл был успешно загружен и сохранен.");
} while (!flag);

string remoteUri =
  "https://okeygeek.ru/wp-content/uploads/2019/01/%D0%A1%D0%BD%D0%B8%D0%BC%D0%BE%D0%BA-%D1%8D%D0%BA%D1%80%D0%B0%D0%BD%D0%B0-2019-01-31-%D0%B2-0.14.25.png";
string fileName = "/Users/user/Downloads/123.png";
await AsyncDownloadSave(remoteUri, fileName);

static async Task AsyncDownloadSave(string path, string name)
{
  try
  {
    using var client = new WebClient();
    Console.WriteLine("start");
    await client.DownloadFileTaskAsync(path, name);
    Console.WriteLine(name, path);
  }
  catch (Exception)
  {
    Console.WriteLine(( "При загрузке возникла ошибка" ));
  }
}
