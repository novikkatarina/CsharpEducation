using NUnit.Framework;

namespace Phonebook;

public class PhoneNumberValidatorTests
{
    [SetUp]
    public void SetUp()
    {
    }

    [TearDown]
    public void TearDown()
    {
    }

    [Test]
    public void ValidateNumber_Number_NumberIsValid()
    {
        PhoneNumberValidator.Validate(new PhoneNumber("+123 (456) 789-0123", PhoneNumberType.Personal));
        PhoneNumberValidator.Validate(new PhoneNumber("+123 (426) 789-0123", PhoneNumberType.Work));
    }

    [Test]
    public void ValidateNumber_InvalidNumber_ThrowsException()
    {
        try
        {
            PhoneNumberValidator.Validate(new PhoneNumber("123", PhoneNumberType.Personal));
            Assert.Fail();
        }
        catch (ArgumentException)
        {
            Assert.Pass();
        }
    }
}