using NUnit.Framework;
using CoreLogic;
using AssertN = NUnit.Framework.Assert;

namespace NUnitTests;

[TestFixture]
public class TemperatureConverterTests
{
    [Test]
    public void Celsius_To_Fahrenheit()
    {
        var t = new TemperatureConverter();
        AssertN.AreEqual(32, t.CelsiusToFahrenheit(0));
    }
}
