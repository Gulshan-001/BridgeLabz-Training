using NUnit.Framework;
using CoreLogic;
using AssertN = NUnit.Framework.Assert;

namespace NUnitTests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void Withdraw_Insufficient_Throws()
    {
        var acc = new BankAccount();
        AssertN.Throws<InvalidOperationException>(() => acc.Withdraw(100));
    }
}
