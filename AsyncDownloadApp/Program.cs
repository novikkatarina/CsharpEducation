using AsyncDownloadApp;

DownloaderSaver downloaderSaver = new DownloaderSaver();
// var url1 = "https://youtu.be/GSItB6R7V2g";
// var path1 = "/Users/user/Downloads/12354.mp4";
// var task1 = downloadSave.AsyncDownloadSave(url1, path1);
//
// var url2 =
//   "https://okeygeek.ru/wp-content/uploads/2019/01/%D0%A1%D0%BD%D0%B8%D0%BC%D0%BE%D0%BA-%D1%8D%D0%BA%D1%80%D0%B0%D0%BD%D0%B0-2019-01-31-%D0%B2-0.14.25.png";
// var path2 = "/Users/user/Downloads/1234.png";
// var task2 = downloadSave.AsyncDownloadSave(url2, path2);

// await Task.WhenAll(task1, task2);


bool flag = false;
do
{
  Console.Write("Введите URL-адрес файла: ");
  string url = Console.ReadLine();

  Console.Write("Введите путь сохранения файла: ");
  string path = Console.ReadLine();

  await downloaderSaver.AsyncDownloadSave(url, path);

  Console.WriteLine(" Для выхода - ввести 1.");
  int input = Convert.ToInt32(Console.ReadLine());
  if (input != 1) flag = true;
}while (!flag);