// See https://aka.ms/new-console-template for more information

namespace Phonebook;

internal class Program
{
  static void Main()
  {
    var ph = MyPhonebook.Instance();
    string input;
    int intInput;
    ph.ReadAll();
    ph.Print();
    ph.Notify += message => Console.WriteLine(message);
    var subscriber = new Subscriber("name", "number");

    void DisplayMessage(Subscriber subscriber, MyPhonebook.SubscriberEventArgs e)
    {
      Console.WriteLine(e.Message);
    }

    ph.Notify2 += DisplayMessage;
    while (true)
    {
      do
      {
        Console.WriteLine(
          "1-create, 2- find by name, 3- find by number, 4 - update by name, 5 - update by number, 6 - delete, 7 - print, 8- exit");
        input = Console.ReadLine();
      } while (!int.TryParse(input, out intInput));

      switch (intInput)
      {
        case 1:
          Console.WriteLine("Enter name");
          string name = Console.ReadLine();
          Console.WriteLine("Enter number");
          string number = Console.ReadLine();
          ph.Create(name, number);
          break;
        case 2:
          Console.WriteLine("Enter name");
          input = Console.ReadLine();
          ph.ReadByName(input);
          break;
        case 3:
          Console.WriteLine("Enter number");
          input = Console.ReadLine();
          ph.ReadByNumber(input);
          break;
        case 4:
          Console.WriteLine("Enter current name");
          string inputCurrentName = Console.ReadLine();
          Console.WriteLine("Enter new name");
          string inputNewName = Console.ReadLine();
          ph.UpdateName(inputCurrentName, inputNewName);
          break;
        case 5:
          Console.WriteLine("Enter current number");
          string inputCurrentNumber = Console.ReadLine();
          Console.WriteLine("Enter new number");
          string inputNewNumber = Console.ReadLine();
          ph.UpdatePhone(inputCurrentNumber, inputNewNumber);
          break;
        case 6:
          Console.WriteLine("Enter subscriber's number to delete");
          input = Console.ReadLine();
          ph.Delete(input);
          break;
        case 7:
          ph.Print();
          break;
        case 8:
          return;
      }
    }
  }
}
