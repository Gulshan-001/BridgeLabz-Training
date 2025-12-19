using System;

class UniFees2
{
    static void Main()
    {
        Console.Write("Enter the university fee amount: ");
        int fee = int.Parse(Console.ReadLine());

        Console.Write("Enter the discount percentage: ");
        int dis = int.Parse(Console.ReadLine());

        int disp = (fee * dis) / 100;
        int total = fee - disp;

        Console.WriteLine("The discount amount is INR " + disp + 
                          " and final discounted fees is INR " + total);
    }
}
