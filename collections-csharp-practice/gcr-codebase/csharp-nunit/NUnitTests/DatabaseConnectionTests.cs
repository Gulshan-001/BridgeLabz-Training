using NUnit.Framework;
using CoreLogic;
using AssertN = NUnit.Framework.Assert;

namespace NUnitTests;

[TestFixture]
public class DatabaseConnectionTests
{
    private DatabaseConnection _db;

    [SetUp]
    public void Setup() => _db = new DatabaseConnection();

    [TearDown]
    public void Cleanup() => _db.Disconnect();

    [Test]
    public void Connect_Works()
    {
        _db.Connect();
        AssertN.IsTrue(_db.IsConnected);
    }
}
