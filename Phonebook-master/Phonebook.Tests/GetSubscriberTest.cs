using NUnit.Framework;

namespace Phonebook.Tests;

public class Tests
{
    private List<PhoneNumber> PhoneNumber { set; get; }
    private Phonebook Phonebook { set; get; }

    [SetUp]
    public void Setup()
    {
        Phonebook = new Phonebook();
        PhoneNumber = new List<PhoneNumber>();
    }

    [TearDown]
    public void TearDown()
    {
    }
    
    
    [Test]
    public void GetSubscriber_ExistedSubscriber_SuccessfullyFound()
    {
        //Arrange
        PhoneNumber phoneNumber = new PhoneNumber("13452", PhoneNumberType.Personal);
        PhoneNumber.Add(phoneNumber);
        Subscriber existedSubscriber = new Subscriber(Guid.NewGuid(), "DFR", PhoneNumber);
        Phonebook.AddSubscriber(existedSubscriber);
        
        // Act

        Subscriber findedSubscriber = Phonebook.GetSubscriber(existedSubscriber.Id);
        
        //Assert
        Assert.AreEqual(existedSubscriber,findedSubscriber);
    }

}