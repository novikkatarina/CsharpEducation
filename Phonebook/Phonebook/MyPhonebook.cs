using Newtonsoft.Json;

namespace Phonebook;

public class MyPhonebook
{
    private static MyPhonebook _myPhonebook;
    readonly string _path = "/Users/user/Katarina/Digit/CsharpEducation/Phonebook/Phonebook/phonebook.txt";
    public List<Subscriber> List { set; get; }

    /// <summary>
    /// Constructor
    /// </summary>
    private MyPhonebook()
    {
        List = new List<Subscriber>();
    }

    /// <summary>
    /// Return single instance of MyPhonebook.
    /// </summary>
    /// <returns></returns>
    public static MyPhonebook Instance()
    {
        if (_myPhonebook == null)
            _myPhonebook = new MyPhonebook();

        return _myPhonebook;
    }
    
    /// <summary>
    /// Prints all subscribers.
    /// </summary>
    public void Print()
    {
        List.ForEach(item => Console.WriteLine("Name: {0}  Number: {1}", item.Name, item.Number));
    }
    
    /// <summary>
    /// Prints given list of subscribers.
    /// </summary>
    /// <param name="list">list of subscribers</param>
    public void Print(List<Subscriber> list)
    {
        foreach (Subscriber item in list)
        {
            Console.WriteLine("Name: {0}  Number: {1}", item.Name, item.Number);
        }
    }

    /// <summary>
    /// Creates new subscriber.
    /// </summary>
    /// <param name="name">name</param>
    /// <param name="number">number</param>
    public void Create(string name, string number)
    {
        List = ReadAll();
        Subscriber subscriber = new Subscriber(name, number);
        int index = List.FindIndex(s => s.Name == subscriber.Name);
        if (index != -1)
        {
            Console.WriteLine("Subscriber already exists");
            return;
        }

        List.Add(subscriber);
        string serializedSubscribers = JsonConvert.SerializeObject(List, Formatting.Indented);
        File.WriteAllText(_path, serializedSubscribers);

        Console.WriteLine("Subscriber added");
        Print();
    }

    /// <summary>
    /// Read all subscribers from file.
    /// </summary>
    /// <returns></returns>
    public List<Subscriber> ReadAll()
    {
        string book = File.ReadAllText(_path);
        List = JsonConvert.DeserializeObject<List<Subscriber>>(book);
        return List;
    }


    /// <summary>
    /// Search subscriber by name.
    /// </summary>
    /// <param name="name">name to look for</param>
    public void ReadByName(string name)
    {
        List<Subscriber> subscribersFound = new List<Subscriber>();
        foreach (Subscriber subscriber in List)
        {
            if (subscriber.Name == name)
            {
                subscribersFound.Add(subscriber);
            }
        }

        if (subscribersFound.Count > 0)
        {
            Print(subscribersFound);
            return;
        }

        Console.WriteLine("There is no such subscribers");
    }

    /// <summary>
    /// Searches subscriber by number.
    /// </summary>
    /// <param name="number">number to look for</param>
    public void ReadByNumber(string number)
    {
        List<Subscriber> subscribersFound = new List<Subscriber>();
        foreach (Subscriber subscriber in List)
        {
            if (subscriber.Number == number)
            {
                subscribersFound.Add(subscriber);
            }
        }

        if (subscribersFound.Count > 0)
        {
            Print(subscribersFound);
            return;
        }

        Console.WriteLine("There is no such subscribers");
    }
    
    /// <summary>
    /// Updates subscriber by name.
    /// </summary>
    /// <param name="name">old name</param>
    /// <param name="newname">new name</param>
    public void UpdateName(string name, string newname)
    {
        int index = List.FindIndex(s => s.Name == name);
        if (index != -1)
        {
            List[index].Name = newname;
            string serializedSubscribers = JsonConvert.SerializeObject(List, Formatting.Indented);
            File.WriteAllText(_path, serializedSubscribers);
            Console.WriteLine("Changed Successfully");
            Console.WriteLine("Name {0}, Number {1}", List[index].Name, List[index].Number);
        }
        else
        {
            Console.WriteLine("There is no such subscribers");
        }
    }

    /// <summary>
    /// Updates subscriber by phone number.
    /// </summary>
    /// <param name="number">old phone number</param>
    /// <param name="newnumber">new phone number</param>
    public void UpdatePhone(string number, string newnumber)
    {
        int index = List.FindIndex(s => s.Number == number);
        if (index != -1)
        {
            List[index].Number = newnumber;
            string serializedSubscribers = JsonConvert.SerializeObject(List, Formatting.Indented);
            File.WriteAllText(_path, serializedSubscribers);
            Console.WriteLine("Changed Successfully");
            Console.WriteLine("Name {0}, Number {1}", List[index].Name, List[index].Number);
        }
        else
        {
            Console.WriteLine("There is no such subscribers");
        }
    }

    /// <summary>
    /// Deletes subscriber.
    /// </summary>
    /// <param name="name">name</param>
    public void Delete(string name)
    {
        int index = List.FindIndex(s => s.Name == name);

        if (index != -1)
        {
            List.RemoveAt(index);
            string serializedSubscribers = JsonConvert.SerializeObject(List, Formatting.Indented);
            File.WriteAllText(_path, serializedSubscribers);
            Console.WriteLine("Changed Successfully");
            Print();
        }
        else
        {
            Console.WriteLine("There is no such subscribers");
        }
    }
}