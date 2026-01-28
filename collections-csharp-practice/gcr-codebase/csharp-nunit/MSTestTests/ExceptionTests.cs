using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLogic;
using AssertM = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MSTestTests;

[TestClass]
public class ExceptionTests
{
    [TestMethod]
    public void Divide_By_Zero_Throws()
    {
        var math = new MathUtils();

        AssertM.ThrowsException<ArithmeticException>(() =>
        {
            math.Divide(10, 0);
        });
    }
}
