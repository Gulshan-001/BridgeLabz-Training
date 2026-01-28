using NUnit.Framework;
using CoreLogic;

namespace NUnitTests;

[TestFixture]
public class PerformanceTests
{
    [Test, Timeout(2000)]
    public void Long_Task_Times_Out()
    {
        var perf = new PerformanceUtils();
        perf.LongRunningTask();
    }
}
