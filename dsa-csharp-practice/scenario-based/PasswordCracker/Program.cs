using System;

class Program
{
    static void Main()
    {
        char[] characters =
        {
        'a','b','c','d','e','f','g','h','i','j',
        'k','l','m','n','o','p','q','r','s','t',
        'u','v','w','x','y','z'
        };


        Console.Write("Enter password length: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Enter password to crack: ");
        string password = Console.ReadLine();

        Backtracking cracker = new Backtracking();
        cracker.Crack(characters, length, password);
    }
}
