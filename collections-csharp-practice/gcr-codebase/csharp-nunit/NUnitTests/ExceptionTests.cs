using NUnit.Framework;
using CoreLogic;
using AssertN = NUnit.Framework.Assert;

namespace NUnitTests;

[TestFixture]
public class ExceptionTests
{
    [Test]
    public void Divide_By_Zero_Throws()
    {
        var math = new MathUtils();
        AssertN.Throws<ArithmeticException>(() => math.Divide(5, 0));
    }
}
