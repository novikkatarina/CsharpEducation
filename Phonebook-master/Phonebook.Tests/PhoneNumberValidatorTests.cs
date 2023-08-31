using NUnit.Framework;

namespace Phonebook;

public class PhoneNumberValidatorTests
{
    [Test]
    public void ValidateNumber_InvalidNumber_ThrowsException()
    {
        // try
        // {
        // PhoneNumberValidator.Validate(new PhoneNumber("123", PhoneNumberType.Personal));
        //     Assert.Fail();
        // }
        // catch (ArgumentException)
        // {
        Assert.Throws<ArgumentException>(() =>
            PhoneNumberValidator.Validate(new PhoneNumber("+123 789-0123", PhoneNumberType.Personal)));
    }
}