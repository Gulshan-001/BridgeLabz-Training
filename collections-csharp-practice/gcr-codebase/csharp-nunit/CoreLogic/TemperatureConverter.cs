namespace CoreLogic;

public class TemperatureConverter
{
    public double CelsiusToFahrenheit(double c) => (c * 9 / 5) + 32;
    public double FahrenheitToCelsius(double f) => (f - 32) * 5 / 9;
}
