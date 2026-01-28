namespace CoreLogic;

public class PerformanceUtils
{
    public string LongRunningTask()
    {
        Thread.Sleep(3000);
        return "Done";
    }
}
