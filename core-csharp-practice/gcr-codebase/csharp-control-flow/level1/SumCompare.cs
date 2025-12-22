using System;
class SumCompare
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number:");
        int number1 = Convert.ToInt32(Console.ReadLine());
        int sum=0;
        while(number1 > 0)
        {
            sum=sum+number1;
            number1--;
        }
        int sum2=number1*(number1+1)/2;
        if(sum==sum2)
        {
            Console.WriteLine("The sums are equal");
        }
        else
        {
            Console.WriteLine("The sums are not equal");
        }
    }
}