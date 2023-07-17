using System.Formats.Tar;
using Newtonsoft.Json;

namespace Phonebook;

public class MyPhonebook
{
    private static MyPhonebook _myPhonebook;
    string path = "/Users/user/Katarina/Digit/CsharpEducation/Phonebook/Phonebook/phonebook.txt";
    public List<Subscriber> List{ set; get; }
    private MyPhonebook()
    {
        List = new List<Subscriber>();
    }
    
    public static MyPhonebook Instance()
    {
        if (_myPhonebook == null)
        _myPhonebook = new MyPhonebook();
        
        return _myPhonebook;
    }

    public void Print(List<Subscriber> List)
    {
        foreach (Subscriber item in List)
        {
            Console.WriteLine(item.Name + item.Phone);
        }
    }
    
    static void Create(Subscriber subscriber, string path)
    {
        List<Subscriber> allSubscribers = ReadAll();
        allSubscribers.Add(subscriber);
        string serializedSubscribers = JsonConvert.SerializeObject(allSubscribers);
        File.WriteAllText(path, serializedSubscribers);
    }
    
    static List<Subscriber> ReadAll()
    {
        string book = File.ReadAllText(path);
        //string json = "{ \"name\": \"Man\", \"Phone\": \"29\" }";
        List<Subscriber> subscriber = JsonConvert.DeserializeObject<List<Subscriber>>(book);


        Console.WriteLine($"Name: {subscriber.ame}, Number: {subscriber.Phone}");

        // string book = File.ReadAllText(path);
        // List<Subscriber> subscribers = JsonConvert.DeserializeObject<List<Subscriber>>(book);
        // return subscribers;
    }
    
    // public void Create(Subscriber subscriber)
    // {
    //     int index = List.FindIndex(s => s.Name == subscriber.Name);
    //     if (index != -1)
    //     {
    //         Console.WriteLine("Пользователь уже существует");
    //         return;
    //     }
    //     
    //     List.Add(subscriber);
    //     Console.WriteLine("Пользователь добавлен");
    // }

    public void ReadByName(string Name)
    {
        List<Subscriber> RequestedList = new List<Subscriber>();
        foreach (Subscriber subscriber in List)
        {
            if (subscriber.Name == Name)  {
                RequestedList.Add(subscriber);
                Print(RequestedList);
                return;
            }
        }

        Console.WriteLine("Пользователей не найдено");
       
    }
    
    public void ReadByNumber(string number)
    {
        List<Subscriber> RequestedList = new List<Subscriber>();
        foreach (Subscriber subscriber in List)
        {
            if (subscriber.Phone == number)
            {
                RequestedList.Add(subscriber);
                Print(RequestedList);
                return;
            }
        }

        Console.WriteLine("Пользователей не найдено");

        
    }

    public void UpdateName(string name, string newname)
    {
        int index = List.FindIndex(s => s.Name == name);

        if (index != -1)
        {
            List[index].Name = newname;
            Console.WriteLine("Изменения проведены успешно");
        }
        else
        {
            Console.WriteLine("Нет таких абонентов");
        }
    }
    
    public void UpdatePhone(string name, string number)
    {
        int index = List.FindIndex(s => s.Name == name);

        if (index != -1)
        {
            List[index].Phone = number;
            Console.WriteLine("Изменения проведены успешно");
        }
        else
        {
            Console.WriteLine("Нет таких абонентов");
        }
    }

    public void Delete(string name)
    {
        int index = List.FindIndex(s => s.Name == name);
        
        if (index != -1)
        {List.RemoveAt(index);
            Console.WriteLine("Изменения проведены успешно");
        }
        else
        {
            Console.WriteLine("Нет таких абонентов");
        }
    }

    // Должна быть реализована CRUD функциональность:
        
        // ----Должен уметь принимать от пользователя номер и имя телефона.
        // Сохранять номер в файле phonebook.txt. (При завершении программы либо при добавлении).
        // Вычитывать из файла сохранённые номера. (При старте программы).
        // ----Удалять номера.
        // ----Получать абонента по номеру телефона.
        // ----Получать номер телефона по имени абонента.
        //  ---Обращение к Phonebook должно быть как к классу-одиночке.
        // ----Внутри должна быть коллекция с абонентами.
        // ----Для обращения с абонентами нужно завести класс Abonent. С полями «номер телефона», «имя».
        // ----Не дать заносить уже записанного абонента.
}