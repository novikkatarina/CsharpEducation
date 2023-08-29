using NUnit.Framework;

namespace Phonebook;

public class AddSubscriberPhoneNumberTest
{
    private Phonebook Phonebook { get; set; }
    public List<PhoneNumber> PhoneNumbers { set; get; }

    [SetUp]
    public void SetUp()
    {
        PhoneNumbers = new List<PhoneNumber>();
        Phonebook = new Phonebook();
    }

    [TearDown]
    public void TearDown()
    {
        PhoneNumbers.Clear();
    }

    [Test]
    public void AddPhoneNumberToSubscriber_NewNumber_ItSuccessfully_Added()
    {
        // Arrange
        PhoneNumber phoneNumber = new PhoneNumber("+1 (555) 123-4567", PhoneNumberType.Personal);
        PhoneNumbers.Add(phoneNumber);
        Subscriber subscriber = new Subscriber(Guid.NewGuid(), "DFR", PhoneNumbers);
        string testNumber = "+123 (456) 789-0123";
        Phonebook.AddSubscriber(subscriber);
        List<PhoneNumber> PhoneNumbersToCheck = new List<PhoneNumber>()
        {
            new("+1 (555) 123-4567", PhoneNumberType.Personal),
            new(testNumber, PhoneNumberType.Personal),
        };

        // Act
        Phonebook.AddNumberToSubscriber(subscriber, new PhoneNumber(testNumber, PhoneNumberType.Personal));
        Subscriber fromPhonebook = Phonebook.GetSubscriber(subscriber.Id);

        // Assert
        Assert.IsTrue(PhoneNumbersToCheck.All(fromPhonebook.PhoneNumbers.Contains));
    }
}