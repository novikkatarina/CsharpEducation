// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using System.Net;
using System.Threading.Channels;
using System.Xml.Schema;
using Newtonsoft.Json;
using Phonebook;
using System;


internal class Program
{
    static void Main(string[] args)
    {
        var ph = MyPhonebook.Instance();
        List<Subscriber> ss = new List<Subscriber>();
        string input;
        int intInput;
        do
        {
            Console.WriteLine("1-create, 2- find, 3 - modify, 4 - delete");
            input = Console.ReadLine();
        } while (!int.TryParse(input, out intInput));

        switch (intInput)
        {
            case 1:
                ReadAll(path);
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }

        ph.Print(ss);
    }


// var ph = MyPhonebook.Instance();

// string text = "Hello World\nHello METANIT.COM";
// // Вычитывать из файла сохранённые номера. (При старте программы).
// StreamWriter writer = new StreamWriter(path, true) ;
//     writer.Write("ushaxi");

    // static List<Subscriber> Delete(Subscriber subscriber)
    //  {
    //      
    //  }

    static void UpdatePhone(string name, string number)
    {
    }


    // static List<Subscriber> ReadByName(Subscriber subscriber)
    // {
    //     return list<Subscriber>;
    // }
}


// {
//     await writer.WriteLineAsync("Addition");
//     await writer.WriteAsync("4,5");
// }
//
// Console.WriteLine("1-create, 2- find, 3 - modify, 4 - delete");
//
// Subscriber ss = new Subscriber("Ivan", "20");
// ph.Create(ss);
// Subscriber sss = new Subscriber("Ivan2", "21");
// ph.Create(sss);
// // ph.Create("Ivan", "21");
// // ph.Create("Ivan2", "22");
//
// ph.Print(ph.List);
//
// ph.ReadByName("Ivan");
// ph.ReadByNumber("22");
//
// ph.UpdateName("Ivan", "Ivan3");
// Console.WriteLine("update");
// ph.Print(ph.List);
//
// ph.Delete("Ivan");
//
// ph.Print(ph.List);
//
//
//
// // ph.Create(new Subscriber("vasya", "123"));
// //
// // // option 2
// // MyPhonebook.Instance().Create(new Subscriber("vasya", "123"));