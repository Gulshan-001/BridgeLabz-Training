using NUnit.Framework;
using CoreLogic;
using AssertN = NUnit.Framework.Assert;

namespace NUnitTests;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calc;

    [SetUp]
    public void Setup() => _calc = new Calculator();

    [Test]
    public void Add_Works() =>
        AssertN.AreEqual(5, _calc.Add(2, 3));

    [Test]
    public void Subtract_Works() =>
        AssertN.AreEqual(1, _calc.Subtract(3, 2));

    [Test]
    public void Multiply_Works() =>
        AssertN.AreEqual(6, _calc.Multiply(2, 3));

    [Test]
    public void Divide_By_Zero_Throws() =>
        AssertN.Throws<ArithmeticException>(() => _calc.Divide(4, 0));
}
