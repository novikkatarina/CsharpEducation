using PhonebookSQL;

var ph = Phonebook.Instance();

Console.WriteLine("Adding new subscribers...");
// создаем два объекта и добавляем их в бд и добавляем их в бд
ph.AddSubscriber("John Doe", "1234567890");
ph.AddSubscriber("Christian Malfoy", "678365920905");
ph.AddSubscriber("Mary", "45678");

ph.UpdateName("Mary", "Arnold");
ph.UpdateNumber("1234567890", "839473920");

Subscriber sub = ph.ReadByName("herf");
ph.DeleteByNumber("839473920");
