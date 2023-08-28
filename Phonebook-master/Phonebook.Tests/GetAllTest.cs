using NUnit.Framework;
using Phonebook;

namespace PhonebookTest;

public class GetAllTest
{
    private List<PhoneNumber> PhoneNumber { set; get; }
    // private List<Subscriber> Subscribers { set; get; }
    private Phonebook.Phonebook Phonebook { set; get; }
    
    [Test]
    public void GetAll_AllSubscribers_SuccessfullyReceived()
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