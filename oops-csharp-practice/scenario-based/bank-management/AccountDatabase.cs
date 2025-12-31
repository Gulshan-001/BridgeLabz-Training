using System;

public class AccountDatabase
{
    public BankAccount[] accountList;
    public int totalAccounts;
    private int accountSeed;

    public AccountDatabase(int maxSize)
    {
        accountList = new BankAccount[maxSize];
        totalAccounts = 0;

        // Starting from a fixed number so every account looks realistic
        accountSeed = 1001;
    }

    public BankAccount AddAccount(string userName, string userPassword, double openingBalance)
    {
        // Before creating anything, make sure there is space left
        if (totalAccounts >= accountList.Length)
        {
            Console.WriteLine("No space left in database.");
            return null;
        }

        // Use the current seed as account number, then move it forward
        BankAccount account = new BankAccount(
            accountSeed,
            userName,
            userPassword,
            openingBalance
        );

        // Store the new account at the next free position
        accountList[totalAccounts] = account;

        // Move index and account number for the next entry
        totalAccounts++;
        accountSeed++;

        return account;
    }

    public BankAccount FindAccount(int accountNumber)
    {
        // Only loop through accounts that actually exist
        for (int i = 0; i < totalAccounts; i++)
        {
            // As soon as the number matches, return that account
            if (accountList[i].AccountNumber == accountNumber)
            {
                return accountList[i];
            }
        }

        // If nothing matched, it simply means account doesn't exist
        return null;
    }
}
