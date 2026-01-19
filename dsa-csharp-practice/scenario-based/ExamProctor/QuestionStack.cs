using System;

class QuestionStack
{
    private QuestionVisitNode top;

    public void Push(int questionId)
    {
        QuestionVisitNode node = new QuestionVisitNode(questionId);
        node.Next = top;
        top = node;
    }

    public int Pop()
    {
        if (top == null)
        {
            Console.WriteLine("No questions visited");
            return -1;
        }

        int id = top.QuestionId;
        top = top.Next;
        return id;
    }

    public void DisplayHistory()
    {
        QuestionVisitNode temp = top;
        Console.WriteLine("Question Navigation History:");

        while (temp != null)
        {
            Console.WriteLine("Question " + temp.QuestionId);
            temp = temp.Next;
        }
    }
}
