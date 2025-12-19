using System;
class UniFees
{
    static void Main()
    {
        int fee=125000;
        int dis=10;
        int disp=(fee*dis)/100;
        int total=fee-disp;
        Console.WriteLine("The discount amount is INR"+ dis +"and final discounted fees is INR"+ total  
        );
    }
}