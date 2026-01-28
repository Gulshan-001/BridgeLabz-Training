using NUnit.Framework;
using CoreLogic;
using System.Collections.Generic;
using AssertN = NUnit.Framework.Assert;

namespace NUnitTests;

[TestFixture]
public class ListManagerTests
{
    [Test]
    public void Add_Remove_Size_Works()
    {
        var list = new List<int>();
        var mgr = new ListManager();

        mgr.AddElement(list, 10);
        mgr.RemoveElement(list, 10);

        AssertN.AreEqual(0, mgr.GetSize(list));
    }
}
