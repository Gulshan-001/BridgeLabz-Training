using System;
using System.Collections;

class Program
{
    static void Main()
    {
#pragma warning disable CS0618   // Suppress obsolete / non-generic warnings

        ArrayList list = new ArrayList();
        list.Add(10);
        list.Add("Hello");

#pragma warning restore CS0618

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}
