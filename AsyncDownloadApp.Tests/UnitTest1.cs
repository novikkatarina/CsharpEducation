using System.Diagnostics;

namespace CsharpEducation;

using AsyncDownloadApp;

public class Tests
{
  private DownloaderSaver DownloaderSaver { get; set; }
  [SetUp]
  public void Setup()
  {
    DownloaderSaver = new DownloaderSaver();
  }

  [Test]
  public async Task AsyncDownloadSave_DownloadedFiles_SuccessfullySavedAsynchronously()
  {
    //Arrange
    
    string path = "https://youtu.be/GSItB6R7V2g";
    string name = "/Users/user/Downloads/12354.mp4";
    var task1 = DownloaderSaver.AsyncDownloadSave(path, name);

    var path2 =
      "https://okeygeek.ru/wp-content/uploads/2019/01/%D0%A1%D0%BD%D0%B8%D0%BC%D0%BE%D0%BA-%D1%8D%D0%BA%D1%80%D0%B0%D0%BD%D0%B0-2019-01-31-%D0%B2-0.14.25.png";
    var name2 = "/Users/user/Downloads/1234.png";
    var task2 = DownloaderSaver.AsyncDownloadSave(path2, name2);

    // Act
    var sw0 = new Stopwatch();
    sw0.Start();
    var sw1 = new Stopwatch();
    sw1.Start();
    await task1;
    sw1.Stop();
    
    var sw2 = new Stopwatch();
    sw2.Start();
    await task1;
    sw2.Stop();
    sw0.Stop();

     bool h = (sw0.Elapsed) < ( sw1.Elapsed + sw2.Elapsed);

     //Assert
    Assert.IsTrue(h);
  }
}
