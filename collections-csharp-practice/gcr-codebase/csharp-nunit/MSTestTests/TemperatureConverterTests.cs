using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLogic;

namespace MSTestTests;

[TestClass]
public class TemperatureConverterTests
{
    [TestMethod]
    public void Celsius_To_Fahrenheit_Works()
    {
        var converter = new TemperatureConverter();
        Assert.AreEqual(32, converter.CelsiusToFahrenheit(0));
    }

    [TestMethod]
    public void Fahrenheit_To_Celsius_Works()
    {
        var converter = new TemperatureConverter();
        Assert.AreEqual(0, converter.FahrenheitToCelsius(32));
    }
}
