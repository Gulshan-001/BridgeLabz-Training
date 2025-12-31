using System;

public class BankAccount
{
    public int AccNumber;
    public string HolderName;
    private string secretKey;
    private double currentBalance;

    public BankAccount(int number, string name, string password, double startBalance)
    {
        // Values are assigned once when the account is created
        AccNumber = number;
        HolderName = name;
        secretKey = password;
        currentBalance = startBalance;
    }

    public bool VerifyPassword(string inputPassword)
    {
        // Simple match check before allowing sensitive actions
        return secretKey == inputPassword;
    }

    public void Deposit(double amount)
    {
        // Balance is updated only if the amount makes sense
        if (amount > 0)
        {
            currentBalance += amount;
            Console.WriteLine("Deposited: " + amount);
        }
        else
        {
            Console.WriteLine("Deposit amount not valid.");
        }
    }

    public void Withdraw(double amount)
    {
        // Withdrawal is allowed only when balance is enough
        if (amount > 0 && amount <= currentBalance)
        {
            currentBalance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
        }
        else
        {
            Console.WriteLine("Cannot withdraw this amount.");
        }
    }

    public void CheckBalance()
    {
        // Just displays whatever the current balance is
        Console.WriteLine("Available Balance: " + currentBalance);
    }

    public void ShowAccountInfo()
    {
        // No password shown, only safe account details
        Console.WriteLine("Account Number: " + AccNumber);
        Console.WriteLine("Account Holder: " + HolderName);
        Console.WriteLine("Balance: " + currentBalance);
    }
}