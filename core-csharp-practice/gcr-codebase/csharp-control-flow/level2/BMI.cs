using System;

class BMICalculation
{
    static void Main()
    {
        Console.WriteLine("Enter weight in kg:");
        double weight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter height in cm:");
        double height = Convert.ToDouble(Console.ReadLine());

        // Convert height from cm to meters
        double heightInMeters = height / 100;

        // Calculate BMI
        double bmi = weight / (heightInMeters * heightInMeters);

        Console.WriteLine("BMI is " + bmi);

        if (bmi < 18.5)
        {
            Console.WriteLine("Weight Status: Underweight");
        }
        else if (bmi >= 18.5 && bmi < 25)
        {
            Console.WriteLine("Weight Status: Normal");
        }
        else if (bmi >= 25 && bmi < 30)
        {
            Console.WriteLine("Weight Status: Overweight");
        }
        else
        {
            Console.WriteLine("Weight Status: Obese");
        }
    }
}
