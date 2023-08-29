using NUnit.Framework;

namespace Phonebook;

public class UpdateSubscriberTest
{
    private Phonebook Phonebook { set; get; }
    private List<PhoneNumber> PhoneNumbers { set; get; }
    private List<PhoneNumber> PhoneNumbers2 { set; get; }


    [SetUp]
    public void Setup()
    {
        Phonebook = new Phonebook();
        PhoneNumbers = new List<PhoneNumber>();
        PhoneNumbers2 = new List<PhoneNumber>();
    }

    [TearDown]
    public void TearDown()
    {
        PhoneNumbers.Clear();
        PhoneNumbers2.Clear();
    }

    [Test]
    public void UpdateSubscriber_OldSubscriber_SuccessfullyUpdated()
    {
        //Arrange
        PhoneNumber phoneNumber = new PhoneNumber("+1 (555) 123-4567", PhoneNumberType.Personal);
        PhoneNumbers.Add(phoneNumber);
        Subscriber subscriberToUpdate = new Subscriber(Guid.NewGuid(), "Kate", PhoneNumbers);
        Phonebook.AddSubscriber(subscriberToUpdate);

        PhoneNumber phoneNumber2 = new PhoneNumber("+123 (456) 789-0123", PhoneNumberType.Personal);
        PhoneNumbers2.Add(phoneNumber2);
        Subscriber newSubscriber = new Subscriber(Guid.NewGuid(), "Michel", PhoneNumbers2);

        // Act
        Phonebook.UpdateSubscriber(subscriberToUpdate, newSubscriber);
        IEnumerable<Subscriber> subscribers = Phonebook.GetAll();

        //Assert
        Assert.IsTrue(!subscribers.Contains(subscriberToUpdate) && subscribers.Contains(newSubscriber));
    }
}