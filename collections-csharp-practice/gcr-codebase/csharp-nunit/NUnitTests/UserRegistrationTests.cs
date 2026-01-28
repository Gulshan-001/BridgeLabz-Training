using NUnit.Framework;
using CoreLogic;
using AssertN = NUnit.Framework.Assert;

namespace NUnitTests;

[TestFixture]
public class UserRegistrationTests
{
    [Test]
    public void Invalid_User_Throws()
    {
        var reg = new UserRegistration();
        AssertN.Throws<ArgumentException>(() => reg.RegisterUser("", "", ""));
    }
}
