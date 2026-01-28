using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLogic;

namespace MSTestTests;

[TestClass]
public class StringUtilsTests
{
    private StringUtils _utils;

    [TestInitialize]
    public void Setup() => _utils = new StringUtils();

    [TestMethod]
    public void Reverse_Works()
        => Assert.AreEqual("cba", _utils.Reverse("abc"));

    [TestMethod]
    public void Palindrome_Works()
        => Assert.IsTrue(_utils.IsPalindrome("madam"));

    [TestMethod]
    public void Uppercase_Works()
        => Assert.AreEqual("HELLO", _utils.ToUpperCase("hello"));
}
