using System;

public class UserInterface
{
    public static void Start()
    {
        ILexicalService service = new LexicalService();

        Console.WriteLine("Enter the first word");
        string word1 = Console.ReadLine();

        Console.WriteLine("Enter the second word");
        string word2 = Console.ReadLine();

        service.ProcessWords(word1, word2);
    }
}
