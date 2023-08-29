using NUnit.Framework;

namespace Phonebook.Tests;

public class Tests
{
    private List<PhoneNumber> PhoneNumbers { set; get; }
    private Phonebook Phonebook { set; get; }

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
}