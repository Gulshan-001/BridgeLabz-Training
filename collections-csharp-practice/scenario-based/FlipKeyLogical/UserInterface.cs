using System;

public class UserInterface
{
    public static void Start()
    {
        IFlipKeyService service = new FlipKeyService();

        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();

        string result = service.CleanseAndInvert(input);

        if (string.IsNullOrEmpty(result))
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine("The generated key is - " + result);
        }
    }
}
