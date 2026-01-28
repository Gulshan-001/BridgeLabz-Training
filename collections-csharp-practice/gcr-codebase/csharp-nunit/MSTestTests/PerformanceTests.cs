using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLogic;

namespace MSTestTests;

[TestClass]
public class PerformanceTests
{
    [TestMethod]
    [Timeout(2000)]
    public void LongRunningTask_TimesOut()
    {
        var perf = new PerformanceUtils();
        perf.LongRunningTask();
    }
}
