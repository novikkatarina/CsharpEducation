using NUnit.Framework;

namespace Phonebook;

public class PhonebookTests
{
    private Phonebook Phonebook { get; set; }
    private List<Subscriber> ListForChecking { get; set; }
    private List<PhoneNumber> PhoneNumbers { set; get; }
    private List<PhoneNumber> PhoneNumbers2 { set; get; }

    [SetUp]
    public void SetUp()
    {
        Phonebook = new Phonebook();
        ListForChecking = new List<Subscriber>();
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

    [Test]
    public void GetSubscriber_ExistedSubscriber_SuccessfullyFound()
    {
        //Arrange
        PhoneNumber phoneNumber = new PhoneNumber("+1 (555) 123-4567", PhoneNumberType.Personal);
        PhoneNumbers.Add(phoneNumber);
        Subscriber existedSubscriber = new Subscriber(Guid.NewGuid(), "Kate", PhoneNumbers);
        Phonebook.AddSubscriber(existedSubscriber);

        // Act
        Subscriber findedSubscriber = Phonebook.GetSubscriber(existedSubscriber.Id);

        //Assert
        Assert.AreEqual(existedSubscriber, findedSubscriber);
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