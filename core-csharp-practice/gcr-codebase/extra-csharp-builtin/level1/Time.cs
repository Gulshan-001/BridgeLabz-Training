using System;

class Time
{
    static void Main()
    {
        // Get current UTC time
        DateTimeOffset utcTime = DateTimeOffset.UtcNow;

        // Get required time zones
        TimeZoneInfo gmt = TimeZoneInfo.Utc;
        TimeZoneInfo ist = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TimeZoneInfo pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        // Convert UTC time to different time zones
        DateTimeOffset gmtTime = TimeZoneInfo.ConvertTime(utcTime, gmt);
        DateTimeOffset istTime = TimeZoneInfo.ConvertTime(utcTime, ist);
        DateTimeOffset pstTime = TimeZoneInfo.ConvertTime(utcTime, pst);

        // Display results
        Console.WriteLine("GMT Time: " + gmtTime);
        Console.WriteLine("IST Time: " + istTime);
        Console.WriteLine("PST Time: " + pstTime);
    }
}
