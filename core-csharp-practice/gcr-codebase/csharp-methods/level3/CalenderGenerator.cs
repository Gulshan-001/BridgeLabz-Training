using System;


    class Calendar
    {
        // a. Get month name
        public static string GetMonthName(int month)
        {
            string[] months =
            {
                "January","February","March","April","May","June",
                "July","August","September","October","November","December"
            };
            return months[month - 1];
        }

        // b. Get number of days in month
        public static int GetDaysInMonth(int month, int year)
        {
            int[] days =
            {
                31,28,31,30,31,30,31,31,30,31,30,31
            };

            if (month == 2 && IsLeapYear(year))
                return 29;

            return days[month - 1];
        }

        // Leap year check
        public static bool IsLeapYear(int year)
        {
            return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
        }

        // c. Get first day of month (0=Sun, 1=Mon...)
        public static int GetFirstDay(int month, int year)
        {
            int y0 = year - (14 - month) / 12;
            int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
            int m0 = month + 12 * ((14 - month) / 12) - 2;
            int d0 = (1 + x + (31 * m0) / 12) % 7;
            return d0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter month (1-12): ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());

            string monthName = CalendarUtility.GetMonthName(month);
            int daysInMonth = CalendarUtility.GetDaysInMonth(month, year);
            int firstDay = CalendarUtility.GetFirstDay(month, year);

            Console.WriteLine();
            Console.WriteLine(monthName + " " + year);
            Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

            // e. Print spaces for first day
            for (int i = 0; i < firstDay; i++)
            {
                Console.Write("    ");
            }

            // f. Print days
            for (int day = 1; day <= daysInMonth; day++)
            {
                Console.Write(day.ToString().PadLeft(3) + " ");
                if ((day + firstDay) % 7 == 0)
                    Console.WriteLine();
            }
        
    }
}
