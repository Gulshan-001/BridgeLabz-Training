using NUnit.Framework;
using CoreLogic;
using AssertN = NUnit.Framework.Assert;

namespace NUnitTests;

[TestFixture]
public class ParameterizedTests
{
    [TestCase(2, true)]
    [TestCase(7, false)]
    public void IsEven_Test(int num, bool expected)
    {
        var util = new NumberUtils();
        AssertN.AreEqual(expected, util.IsEven(num));
    }
}
