using NUnit.Framework;
using CoreLogic;
using AssertN = NUnit.Framework.Assert;

namespace NUnitTests;

[TestFixture]
public class StringUtilsTests
{
    private StringUtils _utils;

    [SetUp]
    public void Setup() => _utils = new StringUtils();

    [Test]
    public void Reverse_Works() =>
        AssertN.AreEqual("cba", _utils.Reverse("abc"));

    [Test]
    public void Palindrome_Works() =>
        AssertN.IsTrue(_utils.IsPalindrome("madam"));

    [Test]
    public void Uppercase_Works() =>
        AssertN.AreEqual("HELLO", _utils.ToUpperCase("hello"));
}
