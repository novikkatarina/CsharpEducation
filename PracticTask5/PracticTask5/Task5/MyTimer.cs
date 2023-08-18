namespace Task5;

public class MyTimer
{
  private int Interval { get; set; }

  public void Start()
  {
    while (true)
    {
      Thread.Sleep(Interval);
      Notify?.Invoke("Тик");
    }
  }

  public delegate void Tick(string message);

  public event Tick Notify;

  public MyTimer(int interval)
  {
    Interval = interval;
  }
}
