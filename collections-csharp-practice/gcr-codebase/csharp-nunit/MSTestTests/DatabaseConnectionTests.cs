using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLogic;

namespace MSTestTests;

[TestClass]
public class DatabaseConnectionTests
{
    private DatabaseConnection _db;

    [TestInitialize]
    public void Setup()
    {
        _db = new DatabaseConnection();
        _db.Connect();
    }

    [TestCleanup]
    public void Cleanup()
    {
        _db.Disconnect();
    }

    [TestMethod]
    public void Connection_Is_Established()
    {
        Assert.IsTrue(_db.IsConnected);
    }
}
