using NUnit.Framework;

namespace Phonebook;

public class AddSubscriberTest
{
    private Phonebook Phonebook { get; set; }
    private List<PhoneNumber> PhoneNumbers { set; get; }

    [SetUp]
    public void Setup()
    {
        Phonebook = new Phonebook();
        PhoneNumbers = new List<PhoneNumber>();
    }

    [TearDown]
    public void TearDown()
    {
        PhoneNumbers.Clear();
    }

    [Test]
    public void AddSubscriber_NewSubscriber_ItExistsInPhonebook()
    {
        // Arrange
        PhoneNumber phoneNumber = new PhoneNumber("+1 (555) 123-4567", PhoneNumberType.Personal);
        PhoneNumbers.Add(phoneNumber);
        Subscriber subscriber = new Subscriber(Guid.NewGuid(), "DFR", PhoneNumbers);

        // Act
        Phonebook.AddSubscriber(subscriber);
        Subscriber fromPhonebook = Phonebook.GetSubscriber(subscriber.Id);

        // Assert
        Assert.IsTrue(Equals(subscriber, fromPhonebook));
    }
}