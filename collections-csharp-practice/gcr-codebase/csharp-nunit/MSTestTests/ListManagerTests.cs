using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLogic;
using System.Collections.Generic;

namespace MSTestTests;

[TestClass]
public class ListManagerTests
{
    [TestMethod]
    public void Add_Remove_Size_Works()
    {
        var list = new List<int>();
        var manager = new ListManager();

        manager.AddElement(list, 5);
        manager.AddElement(list, 10);
        manager.RemoveElement(list, 5);

        Assert.AreEqual(1, manager.GetSize(list));
    }
}
