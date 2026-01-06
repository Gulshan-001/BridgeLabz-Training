using System;

// ================= CALL LOG =================
class CallLog
{
    public string PhoneNumber;
    public string Message;
    public string Time;   // simple time as string

    public CallLog(string phoneNumber, string message, string time)
    {
        PhoneNumber = phoneNumber;
        Message = message;
        Time = time;
    }
}

// ================= MANAGER =================
class CallLogManager
{
    CallLog[] logs = new CallLog[10];
    int count = 0;

    // Add log
    public void AddCallLog(CallLog log)
    {
        if (count < logs.Length)
        {
            logs[count] = log;
            count++;
        }
    }

    // Search by keyword
    public void SearchByKeyword(string keyword)
    {
        Console.WriteLine("\n🔍 Search Results:");
        for (int i = 0; i < count; i++)
        {
            if (logs[i].Message.Contains(keyword))
            {
                PrintLog(logs[i]);
            }
        }
    }

    // Filter by time (simple string comparison)
    public void FilterByTime(string startTime, string endTime)
    {
        Console.WriteLine("\n⏰ Filtered Logs:");
        for (int i = 0; i < count; i++)
        {
            if (logs[i].Time.CompareTo(startTime) >= 0 &&
                logs[i].Time.CompareTo(endTime) <= 0)
            {
                PrintLog(logs[i]);
            }
        }
    }

    void PrintLog(CallLog log)
    {
        Console.WriteLine("Phone: " + log.PhoneNumber);
        Console.WriteLine("Message: " + log.Message);
        Console.WriteLine("Time: " + log.Time);
        Console.WriteLine();
    }
}

// ================= MAIN =================
class Program
{
    static void Main()
    {
        CallLogManager manager = new CallLogManager();

        // Add logs
        manager.AddCallLog(new CallLog("9876543210", "Network issue", "10:00"));
        manager.AddCallLog(new CallLog("9123456789", "Billing problem", "11:00"));
        manager.AddCallLog(new CallLog("9988776655", "Internet not working", "12:30"));

        // Search keyword
        manager.SearchByKeyword("Internet");

        // Filter by time range
        manager.FilterByTime("10:30", "12:30");
    }
}