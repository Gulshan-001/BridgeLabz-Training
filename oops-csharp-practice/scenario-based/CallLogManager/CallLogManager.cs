using System;

// manages call logs using array
class CallLogManager
{
    CallLog[] logs = new CallLog[5];
    int count = 0;

    // add log
    public void AddCallLog(CallLog log)
    {
        logs[count] = log;
        count++;
    }

    // search message
    public void SearchByKeyword(string word)
    {
        for (int i = 0; i < count; i++)
        {
            if (logs[i].Message.Contains(word))
            {
                Show(logs[i]);
            }
        }
    }

    // filter by time
    public void FilterByTime(int start, int end)
    {
        for (int i = 0; i < count; i++)
        {
            if (logs[i].Time >= start && logs[i].Time <= end)
            {
                Show(logs[i]);
            }
        }
    }

    void Show(CallLog log)
    {
        Console.WriteLine(log.PhoneNumber);
        Console.WriteLine(log.Message);
        Console.WriteLine(log.Time);
        Console.WriteLine("----");
    }
}
