using System.ComponentModel;
using System.Net;

bool flag = false;


string url = "https://youtu.be/GSItB6R7V2g";
string path = "/Users/user/Downloads/1234.mp4";
await AsyncDownloadSave(url, path);
Thread.Sleep(5000);

url = 
    "https://okeygeek.ru/wp-content/uploads/2019/01/%D0%A1%D0%BD%D0%B8%D0%BC%D0%BE%D0%BA-%D1%8D%D0%BA%D1%80%D0%B0%D0%BD%D0%B0-2019-01-31-%D0%B2-0.14.25.png";
path = "/Users/user/Downloads/123.png";
await AsyncDownloadSave(url, path);
// do
// {
//     Console.Write("Введите URL-адрес файла: ");
//     string url = Console.ReadLine();
//
//
//     Console.Write("Введите путь сохранения файла: ");
//     string path = Console.ReadLine();
//     //2. "/Users/user/Downloads/1234.png";
//
//
//     if (url != null) await AsyncDownloadSave(url, path);
//
//     Console.WriteLine(" Для выхода - ввести 1. Продолжить - 2.");
//     int input = Convert.ToInt32(Console.ReadLine());
//     if (input == 1) return;
//     if(input == 2) continue;
//     {
//         throw new Exception("Неправильный ввод.");
//     }
// } while (!flag);

//1 https://youtu.be/GSItB6R7V2g
//"/Users/user/Downloads/1234.mp4"


//2
// string remoteUri =
//   "https://okeygeek.ru/wp-content/uploads/2019/01/%D0%A1%D0%BD%D0%B8%D0%BC%D0%BE%D0%BA-%D1%8D%D0%BA%D1%80%D0%B0%D0%BD%D0%B0-2019-01-31-%D0%B2-0.14.25.png";
// string fileName = "/Users/user/Downloads/123.png";

static async Task AsyncDownloadSave(string path, string name)
{
    try
    {
        using var client = new WebClient();
        DateTime time = DateTime.Now;
        Console.WriteLine($"{name} started at {time}");
        client.DownloadFileCompleted += DownloadFileCallback2;
        
        await client.DownloadFileTaskAsync(new Uri(path), name);
    }
    catch (Exception)
    {
        Console.WriteLine(("При загрузке возникла ошибка"));
    }

    // Sample call : DownLoadFileInBackground2 ("http://www.contoso.com/logs/January.txt");
    // void DownLoadFileInBackground2(string address, WebClient client)
    // {
    //     Console.WriteLine("1");
    //     // WebClient client = new WebClient();
    //     Uri uri = new Uri(address);
    //
    //     // Call DownloadFileCallback2 when the download completes.
    //     client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback2);
    //     Console.WriteLine("2");
    //
    //     // Specify a progress notification handler here ...
    //
    //     // client.DownloadFileAsync(uri, "serverdata.txt");
    // }

    void DownloadFileCallback2(object? sender, System.ComponentModel.AsyncCompletedEventArgs asyncCompletedEventArgs)
    {
        DateTime timeOfFinishing = DateTime.Now;
        Console.WriteLine($"Finished.{timeOfFinishing}" );
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