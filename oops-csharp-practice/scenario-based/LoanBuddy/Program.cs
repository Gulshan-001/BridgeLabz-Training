using System;

class Program
{
    static void Main()
    {
        Applicant applicant = new Applicant(
            "Rahul",
            720,
            50000,
            500000
        );

        LoanApplication loan;

        // Change loan type here
        loan = new HomeLoan(applicant, 240);
        // loan = new AutoLoan(applicant, 60);

        if (loan.ApproveLoan())
        {
            Console.WriteLine("Loan Approved!");
            Console.WriteLine("Monthly EMI: ₹" + loan.CalculateEMI());
        }
        else
        {
            Console.WriteLine("Loan Rejected!");
        }
    }
}
