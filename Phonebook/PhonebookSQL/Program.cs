using PhonebookSQL;

var ph = Phonebook.Instance();

Console.WriteLine("Adding new subscribers...");
// создаем два объекта и добавляем их в бд и добавляем их в бд
ph.AddSubscriber("John Doe", "1234567890");
ph.AddSubscriber("Christian Malfoy", "678365920905");
ph.AddSubscriber("hui", "45678");

ph.UpdateName("hbje", "Alph");
ph.ReadByName("huiув");
ph.UpdateNumber("1234567890", "123");

ph.DeleteByNumber("123");

