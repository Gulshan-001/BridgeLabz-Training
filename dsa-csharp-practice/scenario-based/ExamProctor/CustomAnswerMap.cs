class CustomAnswerMap
{
    private AnswerNode[] table;
    private int size;

    public CustomAnswerMap(int size)
    {
        this.size = size;
        table = new AnswerNode[size];
    }

    private int GetHash(int key)
    {
        return key % size;
    }

    public void Put(int questionId, string answer)
    {
        int index = GetHash(questionId);

        AnswerNode node = table[index];

        if (node == null)
        {
            table[index] = new AnswerNode(questionId, answer);
            return;
        }

        AnswerNode current = node;
        while (current != null)
        {
            if (current.QuestionId == questionId)
            {
                current.Answer = answer;
                return;
            }

            if (current.Next == null)
                break;

            current = current.Next;
        }

        current.Next = new AnswerNode(questionId, answer);
    }

    public string Get(int questionId)
    {
        int index = GetHash(questionId);
        AnswerNode current = table[index];

        while (current != null)
        {
            if (current.QuestionId == questionId)
                return current.Answer;

            current = current.Next;
        }

        return null;
    }
}
