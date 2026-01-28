using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLogic;

namespace MSTestTests;

[TestClass]
public class PasswordValidatorTests
{
    [DataTestMethod]
    [DataRow("Abcd1234", true)]
    [DataRow("abcd", false)]
    [DataRow("ABCDEFGH", false)]
    public void Password_Validation_Works(string password, bool expected)
    {
        var validator = new PasswordValidator();
        Assert.AreEqual(expected, validator.IsValid(password));
    }
}
