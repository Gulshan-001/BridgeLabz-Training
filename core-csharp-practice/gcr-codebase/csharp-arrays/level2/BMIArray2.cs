using System;

class BMICalculation2D
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of persons:");
        int number = Convert.ToInt32(Console.ReadLine());

        // personData[row][0] -> weight
        // personData[row][1] -> height
        // personData[row][2] -> BMI
        double[][] personData = new double[number][];
        string[] weightStatus = new string[number];

        for (int i = 0; i < number; i++)
        {
            personData[i] = new double[3];

            Console.WriteLine("Enter weight (kg) for person " + (i + 1));
            double weight = Convert.ToDouble(Console.ReadLine());

            while (weight <= 0)
            {
                Console.WriteLine("Weight must be positive. Enter again:");
                weight = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Enter height (meters) for person " + (i + 1));
            double height = Convert.ToDouble(Console.ReadLine());

            while (height <= 0)
            {
                Console.WriteLine("Height must be positive. Enter again:");
                height = Convert.ToDouble(Console.ReadLine());
            }

            personData[i][0] = weight;
            personData[i][1] = height;
        }

        for (int i = 0; i < number; i++)
        {
            double weight = personData[i][0];
            double height = personData[i][1];

            double bmi = weight / (height * height);
            personData[i][2] = bmi;

            if (bmi < 18.5)
                weightStatus[i] = "Underweight";
            else if (bmi < 25)
                weightStatus[i] = "Normal";
            else if (bmi < 30)
                weightStatus[i] = "Overweight";
            else
                weightStatus[i] = "Obese";
        }

        Console.WriteLine("\nHeight\tWeight\tBMI\tStatus");

        for (int i = 0; i < number; i++)
        {
            Console.WriteLine(
                personData[i][1] + "\t" +
                personData[i][0] + "\t" +
                personData[i][2].ToString("0.00") + "\t" +
                weightStatus[i]
            );
        }
    }
}
