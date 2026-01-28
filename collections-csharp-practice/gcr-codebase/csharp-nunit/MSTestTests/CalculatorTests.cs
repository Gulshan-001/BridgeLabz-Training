using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLogic;
using AssertM = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MSTestTests;

[TestClass]
public class CalculatorTests
{
    private Calculator _calc;

    [TestInitialize]
    public void Setup() => _calc = new Calculator();

    [TestMethod]
    public void Add_Works() =>
        AssertM.AreEqual(5, _calc.Add(2, 3));

    [TestMethod]
    public void Divide_By_Zero_Throws()
    {
        AssertM.ThrowsException<ArithmeticException>(() =>
        {
            _calc.Divide(4, 0);
        });
    }
}
