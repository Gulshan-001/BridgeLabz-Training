using System;

class ExamUtilityImpl : IExamOperations
{
    private QuestionStack stack = new QuestionStack();
    private CustomAnswerMap studentAnswerMap = new CustomAnswerMap(20);
    private CustomAnswerMap correctAnswerMap = new CustomAnswerMap(20);

    public void VisitQuestion(int questionId)
    {
        stack.Push(questionId);
        Console.WriteLine("Visited Question " + questionId);
    }

    public void AnswerQuestion(int questionId, string answer)
    {
        studentAnswerMap.Put(questionId, answer);
        Console.WriteLine("Answer saved for Question " + questionId);
    }

    public void EnterCorrectAnswer(int questionId, string answer)
    {
        correctAnswerMap.Put(questionId, answer);
        Console.WriteLine("Correct answer set for Question " + questionId);
    }

    public void SubmitExam(int totalQuestions)
    {
        int score = CalculateScore(totalQuestions);
        Console.WriteLine("\nExam submitted.");
        Console.WriteLine("Final Score: " + score + "/" + totalQuestions);
    }

    private int CalculateScore(int totalQuestions)
    {
        int score = 0;

        for (int qId = 1; qId <= totalQuestions; qId++)
        {
            string student = studentAnswerMap.Get(qId);
            string correct = correctAnswerMap.Get(qId);

            if (student != null && correct != null && student.Equals(correct))
            {
                score++;
            }
        }

        return score;
    }
}
