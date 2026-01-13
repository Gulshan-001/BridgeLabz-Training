using System;

// Home loan class
class HomeLoan : LoanApplication
{
    public HomeLoan(Applicant applicant, int term)
        : base(applicant, term, 8.5) { }

    public override double CalculateEMI()
    {
        double P = applicant.LoanAmount;
        double R = (interestRate / 12) / 100;
        int N = term;

        return (P * R * Math.Pow(1 + R, N)) /
               (Math.Pow(1 + R, N) - 1);
    }
}
