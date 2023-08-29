using NUnit.Framework;

namespace Phonebook;

public class RenameSubscriberTest
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
    public void Rename_OldSubscriber_OldSubscriberRenamed()
    {
        // Arrange
        PhoneNumber phoneNumber = new PhoneNumber("+1 (555) 123-4567", PhoneNumberType.Personal);
        PhoneNumbers.Add(phoneNumber);
        Subscriber subscriberToUpdate = new Subscriber(Guid.NewGuid(), "Kate", PhoneNumbers);
        Phonebook.AddSubscriber(subscriberToUpdate);
        IEnumerable<Subscriber> subscribers = Phonebook.GetAll();

        // Act
        Phonebook.RenameSubscriber(subscriberToUpdate, "newName");

        // Assert
        Assert.AreEqual((subscribers.Single(s => s.Id == subscriberToUpdate.Id)).Name, "newName");
    }
}