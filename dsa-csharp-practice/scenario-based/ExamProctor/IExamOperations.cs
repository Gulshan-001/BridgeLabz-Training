interface IExamOperations
{
    void VisitQuestion(int questionId);
    void AnswerQuestion(int questionId, string answer);
    void EnterCorrectAnswer(int questionId, string answer);
    void SubmitExam(int totalQuestions);
}
