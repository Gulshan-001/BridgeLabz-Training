using System;

class BMIArray
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of persons:");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] weight = new double[n];
        double[] height = new double[n];
        double[] bmi = new double[n];
        string[] status = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter weight (kg) of person " + (i + 1));
            weight[i] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter height (meters) of person " + (i + 1));
            height[i] = Convert.ToDouble(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            bmi[i] = weight[i] / (height[i] * height[i]);

            if (bmi[i] < 18.5)
                status[i] = "Underweight";
            else if (bmi[i] < 25)
                status[i] = "Normal";
            else if (bmi[i] < 30)
                status[i] = "Overweight";
            else
                status[i] = "Obese";
        }

        Console.WriteLine("\nHeight\tWeight\tBMI\tStatus");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(height[i] + "\t" + weight[i] + "\t" + bmi[i].ToString("0.00") + "\t" + status[i]);
        }
    }
}
