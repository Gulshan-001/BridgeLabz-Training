using System;
using System.Collections.Generic;

class Bank
{
    public string BankName;

    public Bank(string bankName)
    {
        BankName = bankName;
    }

    // Bank opens an account for a customer
    public void OpenAccount(Customer customer, double initialBalance)
    {
        customer.AddAccount(this, initialBalance);
        Console.WriteLine($"Account opened for {customer.Name} in {BankName}");
    }
}

class Account
{
    public Bank Bank;
    public double Balance;

    public Account(Bank bank, double balance)
    {
        Bank = bank;
        Balance = balance;
    }
}

class Customer
{
    public string Name;
    private List<Account> accounts;

    public Customer(string name)
    {
        Name = name;
        accounts = new List<Account>();
    }

    public void AddAccount(Bank bank, double balance)
    {
        Account account = new Account(bank, balance);
        accounts.Add(account);
    }

    // Customer communicates with bank via account
    public void ViewBalance()
    {
        Console.WriteLine($"\nBalances for {Name}:");

        foreach (Account account in accounts)
        {
            Console.WriteLine($"{account.Bank.BankName}: ₹{account.Balance}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Bank exists independently
        Bank sbi = new Bank("State Bank of India");
        Bank hdfc = new Bank("HDFC Bank");

        // Customer exists independently
        Customer alice = new Customer("Alice");

        // Association in action
        sbi.OpenAccount(alice, 5000);
        hdfc.OpenAccount(alice, 12000);

        // Customer checks balances
        alice.ViewBalance();
    }
}
