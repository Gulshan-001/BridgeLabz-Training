using System;

// very simple call log class
class CallLog
{
    public string PhoneNumber;
    public string Message;
    public int Time; // simple time (minutes)

    public CallLog(string phone, string msg, int time)
    {
        PhoneNumber = phone;
        Message = msg;
        Time = time;
    }
}