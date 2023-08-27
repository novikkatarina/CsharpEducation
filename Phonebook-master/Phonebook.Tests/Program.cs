using NUnit.Framework;
using Phonebook;

namespace PhonebookTest;

public class Tests
{
    [SetUp]
    public void Setup(){}
    
    [TearDown]
    public void TearDown(){}
    
    [OneTimeSetUp]
    public void OneTimeSetUp(){}
    
    [OneTimeTearDown]
    public void OneTimeTearDown(){}

    [Test]
    public void GetSubscriber_ExistedSubscriber_SuccessfullyFound()
    {
 
        List<PhoneNumber> list = new List<PhoneNumber>();
        PhoneNumber phoneNumber = new PhoneNumber("13452", PhoneNumberType.Personal);
        list.Add(phoneNumber);
        Subscriber existedSubscriber = new Subscriber(Guid.NewGuid(), "DFR", list); 
        Phonebook.Phonebook ph = new Phonebook.Phonebook();
        
        ph.AddSubscriber(existedSubscriber);

        Subscriber findedSubscriber = ph.GetSubscriber(existedSubscriber.Id);
        
        Assert.AreEqual(existedSubscriber,findedSubscriber);
    }

    [Test]
    public void GetAll_AllSubscribers_SuccessfullyReceived()
    {
        
    }
    
}