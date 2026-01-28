using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLogic;
using AssertM = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MSTestTests;

[TestClass]
public class BankAccountTests
{
    [TestMethod]
    public void Deposit_Works()
    {
        var acc = new BankAccount();
        acc.Deposit(200);
        AssertM.AreEqual(200, acc.GetBalance());
    }

    [TestMethod]
    public void Withdraw_Insufficient_Throws()
    {
        var acc = new BankAccount();

        AssertM.ThrowsException<InvalidOperationException>(() =>
        {
            acc.Withdraw(100);
        });
    }
}
