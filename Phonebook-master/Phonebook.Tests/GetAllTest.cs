using NUnit.Framework;

namespace Phonebook;

public class GetAllTest
{
    private Phonebook Phonebook { set; get; }
    private List<Subscriber> ListForChecking { get; set; }
    private List<PhoneNumber> PhoneNumbers { set; get; }
    private List<PhoneNumber> PhoneNumbers2 { set; get; }


    [SetUp]
    public void Setup()
    {
        ListForChecking = new List<Subscriber>();
        Phonebook = new Phonebook();
        PhoneNumbers = new List<PhoneNumber>();
        PhoneNumbers2 = new List<PhoneNumber>();
    }

    [TearDown]
    public void TearDown()
    {
        ListForChecking.Clear();
        PhoneNumbers.Clear();
    }

    [Test]
    public void GetAll_AllSubscribers_SuccessfullyReceived()
    {
        //Arrange
        PhoneNumber phoneNumber = new PhoneNumber("+1 (555) 123-4567", PhoneNumberType.Personal);
        PhoneNumbers.Add(phoneNumber);
        Subscriber subscriber1 = new Subscriber(Guid.NewGuid(), "Make", PhoneNumbers);
        Phonebook.AddSubscriber(subscriber1);

        PhoneNumber phoneNumber2 = new PhoneNumber("+123 (456) 789-0123", PhoneNumberType.Personal);
        PhoneNumbers2.Add(phoneNumber2);
        Subscriber subscriber2 = new Subscriber(Guid.NewGuid(), "Kate", PhoneNumbers2);
        Phonebook.AddSubscriber(subscriber2);

        ListForChecking.Add(subscriber1);
        ListForChecking.Add(subscriber2);

        // Act

        IEnumerable<Subscriber> subscribers = Phonebook.GetAll();

        //Assert
        Assert.AreEqual(subscribers, ListForChecking);
    }
}