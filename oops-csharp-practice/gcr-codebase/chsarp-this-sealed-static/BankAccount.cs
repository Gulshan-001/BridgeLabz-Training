using System;

class BankAccount
{
    // Static variable shared by all accounts
    public static string bankName = "National Bank";

    static int totalAccounts = 0;

    public string accountHolderName;
    public readonly string accountNumber;

    public BankAccount(string accountHolderName, string accountNumber)
    {
        // Using this to clearly assign values to current object
        this.accountHolderName = accountHolderName;
        this.accountNumber = accountNumber;

        // Count increases whenever a new account is created
        totalAccounts++;
    }

    public void DisplayAccountDetails()
    {
        Console.WriteLine("Bank Name: " + bankName);
        Console.WriteLine("Account Holder: " + accountHolderName);
        Console.WriteLine("Account Number: " + accountNumber);
    }

    public static void GetTotalAccounts()
    {
        Console.WriteLine("Total Accounts Created: " + totalAccounts);
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc1 = new BankAccount("Gulshan", "ACC1001");
        BankAccount acc2 = new BankAccount("Amit", "ACC1002");

        Console.WriteLine("Checking object type before display:");
        
        // Using is operator to ensure correct type
        if (acc1 is BankAccount)
        {
            acc1.DisplayAccountDetails();
        }

        Console.WriteLine();

        if (acc2 is BankAccount)
        {
            acc2.DisplayAccountDetails();
        }

        Console.WriteLine();

        // Calling static method using class name
        BankAccount.GetTotalAccounts();
    }
}
