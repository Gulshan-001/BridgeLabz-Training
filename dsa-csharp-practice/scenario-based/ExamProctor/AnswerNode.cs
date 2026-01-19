class AnswerNode
{
    public int QuestionId;
    public string Answer;
    public AnswerNode Next;

    public AnswerNode(int questionId, string answer)
    {
        QuestionId = questionId;
        Answer = answer;
        Next = null;
    }
}
