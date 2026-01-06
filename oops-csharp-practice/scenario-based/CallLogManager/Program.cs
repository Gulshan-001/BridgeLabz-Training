using System;

class Program
{
    static void Main()
    {
        CallLogManager manager = new CallLogManager();

        manager.AddCallLog(new CallLog("9999999999", "Network problem", 10));
        manager.AddCallLog(new CallLog("8888888888", "Call dropped", 20));
        manager.AddCallLog(new CallLog("7777777777", "Recharge done", 30));

        Console.WriteLine("Search: Network");
        manager.SearchByKeyword("Network");

        Console.WriteLine("Filter time 15 to 30");
        manager.FilterByTime(15, 30);
    }
}
