using NUnit.Framework;
using CoreLogic;
using AssertN = NUnit.Framework.Assert;

namespace NUnitTests;

[TestFixture]
public class DateFormatterTests
{
    [Test]
    public void Format_Date_Works()
    {
        var df = new DateFormatter();
        AssertN.AreEqual("01-01-2024", df.FormatDate("2024-01-01"));
    }
}
