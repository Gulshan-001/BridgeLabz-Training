using System;

class BankAccount
{
    public string accountNumber;
    protected string accountHolder;
    private double balance;

    public BankAccount(string accNo, string holder, double initialBalance)
    {
        accountNumber = accNo;
        accountHolder = holder;
        balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        // Adding money safely using a public method
        if (amount > 0)
        {
            balance += amount;
        }
    }

    public void Withdraw(double amount)
    {
        // Prevent withdrawing more than available balance
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount.");
        }
    }

    public double GetBalance()
    {
        // Balance stays private, only value is shared
        return balance;
    }
}

class SavingsAccount : BankAccount
{
    double interestRate;

    public SavingsAccount(string accNo, string holder, double initialBalance, double rate)
        : base(accNo, holder, initialBalance)
    {
        interestRate = rate;
    }

    public void DisplaySavingsAccount()
    {
        Console.WriteLine("Account Number: " + accountNumber);
        Console.WriteLine("Account Holder: " + accountHolder);
        Console.WriteLine("Balance: " + GetBalance());
        Console.WriteLine("Interest Rate: " + interestRate + "%");
    }
}

class Program
{
    static void Main()
    {
        SavingsAccount savings =
            new SavingsAccount("SB1001", "Gulshan", 25000, 4.5);

        savings.DisplaySavingsAccount();

        Console.WriteLine();

        // Deposit and withdraw using public methods
        savings.Deposit(5000);
        savings.Withdraw(3000);

        Console.WriteLine("After Transactions:");
        savings.DisplaySavingsAccount();
    }
}
