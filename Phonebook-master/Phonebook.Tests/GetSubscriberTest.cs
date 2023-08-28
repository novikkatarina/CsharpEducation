using NUnit.Framework;
using Phonebook;
using Phonebook = Phonebook.Phonebook;

namespace PhonebookTest;

public class Tests
{
    private List<PhoneNumber> PhoneNumber { set; get; }
    private List<Subscriber> Subscribers { set; get; }
    private Phonebook.Phonebook Phonebook { set; get; }
    
    [SetUp]
    public void Setup()
    {
        Phonebook = new Phonebook();
       Subscribers = new List<Subscriber>();
       PhoneNumber = new List<PhoneNumber>();
    }
    
    [Test]
    public void GetSubscriber_ExistedSubscriber_SuccessfullyFound()
    {
        //Arrange
        PhoneNumber phoneNumber = new PhoneNumber("13452", PhoneNumberType.Personal);
        PhoneNumber.Add(phoneNumber);
        Subscriber existedSubscriber = new Subscriber(Guid.NewGuid(), "DFR", PhoneNumber); 
        // Phonebook.Phonebook ph = new Phonebook.Phonebook();
        
        ph.AddSubscriber(existedSubscriber);
        
        // Act

        Subscriber findedSubscriber = ph.GetSubscriber(existedSubscriber.Id);
        
        //Assert
        Assert.AreEqual(existedSubscriber,findedSubscriber);
    }

}