using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLogic;
using AssertM = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MSTestTests;

[TestClass]
public class UserRegistrationTests
{
    [TestMethod]
    public void Valid_User_Works()
    {
        var reg = new UserRegistration();
        reg.RegisterUser("john", "john@mail.com", "Pass1234");
    }

    [TestMethod]
    public void Invalid_User_Throws()
    {
        var reg = new UserRegistration();

        AssertM.ThrowsException<ArgumentException>(() =>
        {
            reg.RegisterUser("", "", "");
        });
    }
}
