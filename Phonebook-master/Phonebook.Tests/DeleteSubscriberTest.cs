using NUnit.Framework;

namespace Phonebook;

public class DeleteSubscriberTest
{
    private Phonebook Phonebook { set; get; }
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
    public void DeleteSubscriber_subscriberToDelete_SubscriberDeted()
    {
        //Arrange
        PhoneNumber phoneNumber = new PhoneNumber("+1 (555) 123-4567", PhoneNumberType.Personal);
        PhoneNumbers.Add(phoneNumber);
        Subscriber subscriberToDelete = new Subscriber(Guid.NewGuid(), "DFR", PhoneNumbers);
        Phonebook.AddSubscriber(subscriberToDelete);
        IEnumerable<Subscriber> subscribers = Phonebook.GetAll();

        //Act
        Phonebook.DeleteSubscriber(subscriberToDelete);

        //Assert
        Assert.IsTrue(!subscribers.Contains(subscriberToDelete));
    }
}