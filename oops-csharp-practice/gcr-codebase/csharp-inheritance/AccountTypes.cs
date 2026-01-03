using System;

// Superclass
class BankAccount
{
    public int AccountNumber;
    public double Balance;

    public BankAccount(int accountNumber, double balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public virtual void DisplayAccountType()
    {
        Console.WriteLine("Bank Account");
    }
}

// Savings Account
class SavingsAccount : BankAccount
{
    public double InterestRate;

    public SavingsAccount(int accountNumber, double balance, double interestRate)
        : base(accountNumber, balance)
    {
        InterestRate = interestRate;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("Savings Account");
    }
}

// Checking Account
class CheckingAccount : BankAccount
{
    public int WithdrawalLimit;

    public CheckingAccount(int accountNumber, double balance, int limit)
        : base(accountNumber, balance)
    {
        WithdrawalLimit = limit;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("Checking Account");
    }
}

// Fixed Deposit Account
class FixedDepositAccount : BankAccount
{
    public int LockInPeriod; // in months

    public FixedDepositAccount(int accountNumber, double balance, int lockInPeriod)
        : base(accountNumber, balance)
    {
        LockInPeriod = lockInPeriod;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("Fixed Deposit Account");
    }
}

class Program
{
    static void Main()
    {
        BankAccount a1 = new SavingsAccount(101, 50000, 4.5);
        BankAccount a2 = new CheckingAccount(102, 30000, 5);
        BankAccount a3 = new FixedDepositAccount(103, 100000, 24);

        a1.DisplayAccountType();
        a2.DisplayAccountType();
        a3.DisplayAccountType();
    }
}
