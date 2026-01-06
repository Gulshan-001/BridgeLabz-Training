using System;
using System.Collections.Generic;

// Loan interface
interface ILoanable
{
    void ApplyForLoan();
    double CalculateLoanEligibility();
}

// Abstract BankAccount class
abstract class BankAccount
{
    // Encapsulation (private data)
    private double balance;

    protected string accountNumber;
    protected string holderName;

    public BankAccount(string accNo, string name, double initialBalance)
    {
        accountNumber = accNo;
        holderName = name;
        balance = initialBalance;
    }

    // deposit money
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
        }
    }

    // withdraw money
    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
        }
    }

    // protected access to balance
    protected double GetBalance()
    {
        return balance;
    }

    // abstract interest method
    public abstract double CalculateInterest();

    // common display
    public void DisplayDetails()
    {
        Console.WriteLine("Account Number: " + accountNumber);
        Console.WriteLine("Holder Name: " + holderName);
        Console.WriteLine("Balance: " + balance);
        Console.WriteLine("Interest: " + CalculateInterest());
        Console.WriteLine("------------------------");
    }
}

// Savings Account
class SavingsAccount : BankAccount, ILoanable
{
    public SavingsAccount(string accNo, string name, double bal)
        : base(accNo, name, bal) { }

    public override double CalculateInterest()
    {
        return GetBalance() * 0.04; // 4% interest
    }

    public void ApplyForLoan()
    {
        Console.WriteLine("Loan applied from Savings Account");
    }

    public double CalculateLoanEligibility()
    {
        return GetBalance() * 2;
    }
}

// Current Account
class CurrentAccount : BankAccount, ILoanable
{
    public CurrentAccount(string accNo, string name, double bal)
        : base(accNo, name, bal) { }

    public override double CalculateInterest()
    {
        return GetBalance() * 0.02; // 2% interest
    }

    public void ApplyForLoan()
    {
        Console.WriteLine("Loan applied from Current Account");
    }

    public double CalculateLoanEligibility()
    {
        return GetBalance() * 3;
    }
}

class Program
{
    static void Main()
    {
        List<BankAccount> accounts = new List<BankAccount>();

        accounts.Add(new SavingsAccount("SAV101", "Rahul", 50000));
        accounts.Add(new CurrentAccount("CUR202", "Anita", 100000));

        // Polymorphism here
        foreach (BankAccount acc in accounts)
        {
            acc.DisplayDetails();
        }
    }
}
