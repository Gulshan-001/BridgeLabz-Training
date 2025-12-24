using System;

class BMI
{
    // method to calculate BMI for each person and store it in the 3rd column
    static void CalculateBMI(double[,] data)
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            double weight = data[i, 0];
            double heightInMeters = data[i, 1] / 100; // convert cm to meters
            data[i, 2] = weight / (heightInMeters * heightInMeters);
        }
    }

    // method to determine BMI status for each person
    static string[] DetermineBMIStatus(double[,] data)
    {
        string[] status = new string[data.GetLength(0)];

        for (int i = 0; i < data.GetLength(0); i++)
        {
            double bmi = data[i, 2];

            if (bmi <= 18.4)
                status[i] = "Underweight";
            else if (bmi <= 24.9)
                status[i] = "Normal";
            else if (bmi <= 39.9)
                status[i] = "Overweight";
            else
                status[i] = "Obese";
        }

        return status;
    }

    static void Main(string[] args)
    {
        double[,] data = new double[10, 3];

        // take weight and height input for 10 persons
        for (int i = 0; i < 10; i++)
        {
            Console.Write("Enter weight (kg) of person " + (i + 1) + ": ");
            data[i, 0] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter height (cm) of person " + (i + 1) + ": ");
            data[i, 1] = Convert.ToDouble(Console.ReadLine());
        }

        // calculate BMI for all persons
        CalculateBMI(data);

        // get BMI status for all persons
        string[] bmiStatus = DetermineBMIStatus(data);

        Console.WriteLine("\nHeight(cm)\tWeight(kg)\tBMI\t\tStatus");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(
                data[i, 1] + "\t\t" +
                data[i, 0] + "\t\t" +
                data[i, 2].ToString("F2") + "\t\t" +
                bmiStatus[i]
            );
        }
    }
}
