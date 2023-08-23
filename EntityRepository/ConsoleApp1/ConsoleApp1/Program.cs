class Program
{
  static Task Main(string[] args)
  {
    Await().PrintAsync();   // вызов асинхронного метода
    Console.WriteLine("Некоторые действия в методе Main");
 
 
    void Print()
    {
      Thread.Sleep(3000);     // имитация продолжительной работы
      Console.WriteLine("Hello METANIT.COM");
    }
 
    // определение асинхронного метода
    async Task PrintAsync()
    {
      Console.WriteLine("Начало метода PrintAsync"); // выполняется синхронно
      Task.Run(() => Print()).Wait();                // выполняется асинхронно
      Console.WriteLine("Конец метода PrintAsync");
    }

    return Task.CompletedTask;
  }

}
