using NUnit.Framework;
using CoreLogic;
using AssertN = NUnit.Framework.Assert;

namespace NUnitTests;

[TestFixture]
public class PasswordValidatorTests
{
    [Test]
    public void Valid_Password_Works()
    {
        var pv = new PasswordValidator();
        AssertN.IsTrue(pv.IsValid("Abcd1234"));
    }
}
