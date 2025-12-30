using System;

class TemperatureAnalysis
{
    static void ProcessTemperatures(float[,] readings)
    {
        float highestAverage = float.MinValue;
        float lowestAverage = float.MaxValue;

        int warmestDay = 0;
        int coolestDay = 0;

        // Loop through each day of the week
        for (int day = 0; day < 7; day++)
        {
            float dailyTotal = 0;

            // Add all hourly readings for the day
            for (int hour = 0; hour < 24; hour++)
            {
                dailyTotal += readings[day, hour];
            }

            float dailyAverage = dailyTotal / 24;
            Console.WriteLine($"Day {day + 1} Average Temperature: {dailyAverage}");

            // Check for highest average temperature
            if (dailyAverage > highestAverage)
            {
                highestAverage = dailyAverage;
                warmestDay = day + 1;
            }

            // Check for lowest average temperature
            if (dailyAverage < lowestAverage)
            {
                lowestAverage = dailyAverage;
                coolestDay = day + 1;
            }
        }

        Console.WriteLine($"\nHottest Day: Day {warmestDay}");
        Console.WriteLine($"Coldest Day: Day {coolestDay}");
    }

    static void Main()
    {
        float[,] weekTemperatures = new float[7, 24];

        // Generate random temperature values for demonstration
        Random random = new Random();

        for (int d = 0; d < 7; d++)
        {
            for (int h = 0; h < 24; h++)
            {
                weekTemperatures[d, h] = random.Next(15, 40);
            }
        }

        ProcessTemperatures(weekTemperatures);
    }
}
