using System;
class UniFees2
{
    static void Main()
    {
        int fee=Console.ReadLine("Enter the university fee amount: ")   ;
        int dis=Console.ReadLine("Enter the discount percentage: ");
        int disp=(fee*dis)/100;
        int total=fee-disp;
        Console.WriteLine("The discount amount is INR"+ dis +"and final discounted fees is INR"+ total  
        );
    }
}