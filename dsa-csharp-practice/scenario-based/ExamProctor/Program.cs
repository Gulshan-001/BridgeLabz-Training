using System;

class Program
{
    static void Main()
    {
        IExamOperations exam = new ExamUtilityImpl();

        Console.Write("Enter total number of questions: ");
        int totalQuestions = int.Parse(Console.ReadLine());

        while (true)
        {
            Console.WriteLine("\n--- ExamProctor Menu ---");
            Console.WriteLine("1. Visit Question");
            Console.WriteLine("2. Answer Question");
            Console.WriteLine("3. Enter Correct Answer");
            Console.WriteLine("4. Submit Exam");
            Console.WriteLine("5. Exit");
            Console.Write("Choose option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Question ID: ");
                    int visitId = int.Parse(Console.ReadLine());
                    exam.VisitQuestion(visitId);
                    break;

                case 2:
                    Console.Write("Enter Question ID: ");
                    int qId = int.Parse(Console.ReadLine());
                    Console.Write("Enter your answer: ");
                    string ans = Console.ReadLine();
                    exam.AnswerQuestion(qId, ans);
                    break;

                case 3:
                    Console.Write("Enter Question ID: ");
                    int cqId = int.Parse(Console.ReadLine());
                    Console.Write("Enter correct answer: ");
                    string correct = Console.ReadLine();
                    exam.EnterCorrectAnswer(cqId, correct);
                    break;

                case 4:
                    exam.SubmitExam(totalQuestions);
                    return;

                case 5:
                    Console.WriteLine("Exiting ExamProctor...");
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
