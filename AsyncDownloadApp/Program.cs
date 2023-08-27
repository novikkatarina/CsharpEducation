using AsyncDownloadApp;

DownloaderSaver downloaderSaver = new DownloaderSaver();

var tasks = new List<Task>();
bool flag = false;
do
{
  Console.Write("Введите URL-адрес файла: ");
  string url = Console.ReadLine();

  Console.Write("Введите путь сохранения файла: ");
  string path = Console.ReadLine();

  tasks.Add(downloaderSaver.AsyncDownloadSave(url, path));

  Console.WriteLine(" Для выхода - ввести 1.");
  int input = Convert.ToInt32(Console.ReadLine());
  if (input != 1) flag = true;
} while (!flag);

await Task.WhenAll(tasks);
