class Applicant
{
    private string name;
    private int creditScore;
    private double income;
    private double loanAmount;

    public Applicant(string name, int creditScore, double income, double loanAmount)
    {
        this.name = name;
        this.creditScore = creditScore;
        this.income = income;
        this.loanAmount = loanAmount;
    }

    public string Name
    {
        get { return name; }
    }

    public int CreditScore
    {
        get { return creditScore; }
    }

    public double Income
    {
        get { return income; }
    }

    public double LoanAmount
    {
        get { return loanAmount; }
    }
}
