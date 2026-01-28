using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLogic;

namespace MSTestTests;

[TestClass]
public class ParameterizedTests
{
    [DataTestMethod]
    [DataRow(2, true)]
    [DataRow(4, true)]
    [DataRow(7, false)]
    [DataRow(9, false)]
    public void IsEven_Test(int number, bool expected)
    {
        var util = new NumberUtils();
        Assert.AreEqual(expected, util.IsEven(number));
    }
}
