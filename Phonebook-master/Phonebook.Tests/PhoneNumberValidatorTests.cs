using NUnit.Framework;

namespace Phonebook;

public class PhoneNumberValidatorTests
{
    [Test]
    public void ValidateNumber_InvalidNumber_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
            PhoneNumberValidator.Validate(new PhoneNumber("+123 789-0123", PhoneNumberType.Personal)));
    } 
}