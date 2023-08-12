using Task5;

MyTimer timer = new MyTimer(1000);

timer.Notify += message => Console.WriteLine(message);
timer.Start();
