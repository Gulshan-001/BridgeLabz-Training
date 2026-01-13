using System;

// Base loan class
abstract class LoanApplication : IApprovable
{
    protected Applicant applicant;
    protected int term;                // months
    protected double interestRate;
    protected bool approved;

    protected LoanApplication(Applicant applicant, int term, double interestRate)
    {
        this.applicant = applicant;
        this.term = term;
        this.interestRate = interestRate;
    }

    // Internal eligibility check
    protected bool CheckEligibility()
    {
        return applicant.CreditScore >= 650 && applicant.Income > 20000;
    }

    public bool ApproveLoan()
    {
        approved = CheckEligibility();
        return approved;
    }

    public abstract double CalculateEMI();
}
