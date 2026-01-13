using System;

class AutoLoan : LoanApplication
{
    public AutoLoan(Applicant applicant, int term)
        : base(applicant, term, 10.0) { }

    public override double CalculateEMI()
    {
        double P = applicant.LoanAmount;
        double R = (interestRate / 12) / 100;
        int N = term;

        double emi = (P * R * Math.Pow(1 + R, N)) /
                     (Math.Pow(1 + R, N) - 1);

        return emi + 500;
    }
}
