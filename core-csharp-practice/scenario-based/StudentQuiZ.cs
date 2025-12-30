using System;
class StudentQuiZ
{
    static int calculateScore(string[]correctanswers, string[] studentanswers)
    {
        int score=0;
        for(int i = 0; i < 10; i++)
        {
            if (string.Equals(correctanswers[i], studentanswers[i], StringComparison.OrdinalIgnoreCase)
)
            {
               score++;
               Console.WriteLine($"Question {i+1} Correct");
            }
            else
            {
                Console.WriteLine($"Question {i+1} Incorrect");
            }
            
        }
        return score;
    }
    static void Main()
    {
        string[] corrects={"A","B","C","A","D","B","A","C","D","C"};
        string[] inputs=new string[10];
        for (int j = 0; j < 10; j++)
        {
            Console.WriteLine($"Enter The Answer of Question {j+1}");
            String currans=Console.ReadLine();
            inputs[j]=currans;
        }
        int x=calculateScore(corrects,inputs);
        Console.WriteLine($"The Score of Student is {x}");
        Console.Write($"Percentage :-{x*10}% ");
        if (x > 3)
        {
            Console.WriteLine("PASS");
        }
        else
        {
            Console.WriteLine("FAIL");
        }
    }
}