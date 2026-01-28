using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLogic;
using AssertM = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MSTestTests;

[TestClass]
public class DateFormatterTests
{
    [TestMethod]
    public void Valid_Date_Works()
    {
        var df = new DateFormatter();
        AssertM.AreEqual("15-08-2024", df.FormatDate("2024-08-15"));
    }

    [TestMethod]
    public void Invalid_Date_Throws()
    {
        var df = new DateFormatter();

        AssertM.ThrowsException<FormatException>(() =>
        {
            df.FormatDate("invalid-date");
        });
    }
}
