using System;

class YoungestOfThree
{
    static void Main(string[] args )
    {
        Console.WriteLine("Enter age of Amar:");
        int amarAge = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter age of Akbar:");
        int akbarAge = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter age of Anthony:");
        int anthonyAge = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter height of Amar:");
        double amarHeight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter height of Akbar:");
        double akbarHeight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter height of Anthony:");
        double anthonyHeight = Convert.ToDouble(Console.ReadLine());

        if (amarAge < akbarAge && amarAge < anthonyAge)
            Console.WriteLine("Amar is the youngest");
        else if (akbarAge < amarAge && akbarAge < anthonyAge)
            Console.WriteLine("Akbar is the youngest");
        else
            Console.WriteLine("Anthony is the youngest");

        if (amarHeight > akbarHeight && amarHeight > anthonyHeight)
            Console.WriteLine("Amar is the tallest");
        else if (akbarHeight > amarHeight && akbarHeight > anthonyHeight)
            Console.WriteLine("Akbar is the tallest");
        else
            Console.WriteLine("Anthony is the tallest");
    }
}
