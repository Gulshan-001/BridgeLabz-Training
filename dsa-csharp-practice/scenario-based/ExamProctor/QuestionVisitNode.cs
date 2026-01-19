class QuestionVisitNode
{
    public int QuestionId;
    public QuestionVisitNode Next;

    public QuestionVisitNode(int questionId)
    {
        QuestionId = questionId;
        Next = null;
    }
}
