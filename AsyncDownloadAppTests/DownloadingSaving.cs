using AsyncDownloadApp;

namespace AsyncDownloadAppTests;

public class Tests
{
  public DownloaderSaver downloaderSave { set; get; }

  [SetUp]
  public void Setup()
  {
    downloaderSave = new DownloaderSaver();
  }

  [Test]
  public async Task DownloadingSaving_File_SuccessfullyDownloadedAndSaved()
  {
    // Arrange
    string path = "https://youtu.be/GSItB6R7V2g";
    string name = "/Users/user/Downloads/12354.mp4";

    var path2 =
      "https://okeygeek.ru/wp-content/uploads/2019/01/%D0%A1%D0%BD%D0%B8%D0%BC%D0%BE%D0%BA-%D1%8D%D0%BA%D1%80%D0%B0%D0%BD%D0%B0-2019-01-31-%D0%B2-0.14.25.png";
    var name2 = "/Users/user/Downloads/1234.png";

    // Act
    var tasks = new List<Task<DownloaderSaver.ExecutingAppTimeCharacteristics>>
    {
      downloaderSave.AsyncDownloadSave(path, name), downloaderSave.AsyncDownloadSave(path2, name2)
    };

    await Task.WhenAll(tasks);

    var result1 = tasks[0].Result;
    var result2 = tasks[1].Result;

    //Assert
    Assert.IsTrue(result1.TimeOfFinishing > result2.StartingTime);
  }
}
