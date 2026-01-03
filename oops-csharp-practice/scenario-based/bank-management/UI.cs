using System;

public class UI
{
    private AccountDatabase accountData;

    public UI(AccountDatabase data)
    {
        // keeping a reference so UI can read/write accounts
        accountData = data;
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Welcome to Banking App =====");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            string userChoice = Console.ReadLine();

            if (userChoice == "3")
                break;

            switch (userChoice)
            {
                case "1":
                    HandleRegistration();
                    break;

                case "2":
                    HandleLogin();
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    Console.ReadKey();
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Banking App!");
    }

    private void HandleRegistration()
    {
        Console.Clear();
        Console.WriteLine("===== Register =====");

        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();

        Console.Write("Enter password: ");
        string userPassword = Console.ReadLine();

        Console.Write("Enter initial deposit: ");
        double startBalance;

        // keeps asking until a valid non-negative amount is entered
        while (!double.TryParse(Console.ReadLine(), out startBalance) || startBalance < 0)
        {
            Console.Write("Invalid amount! Enter again: ");
        }

        BankAccount createdAccount =
            accountData.AddAccount(userName, userPassword, startBalance);

        if (createdAccount != null)
        {
            Console.WriteLine("Registration successful!");
            Console.WriteLine("Your account number is: " + createdAccount.AccountNumber);
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void HandleLogin()
    {
        Console.Clear();
        Console.WriteLine("===== Login =====");

        Console.Write("Enter account number: ");
        int accNumber;

        // ensures only numbers are accepted
        while (!int.TryParse(Console.ReadLine(), out accNumber))
        {
            Console.Write("Invalid input! Enter account number again: ");
        }

        BankAccount account = accountData.FindAccount(accNumber);

        // stops login flow if account doesn’t exist
        if (account == null)
        {
            Console.WriteLine("Account not found!");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter password: ");
        string enteredPassword = Console.ReadLine();

        if (account.VerifyPassword(enteredPassword))
        {
            Console.WriteLine("Login successful!");
            Console.ReadKey();
            ShowBankingMenu(account);
        }
        else
        {
            Console.WriteLine("Incorrect password!");
            Console.ReadKey();
        }
    }

    private void ShowBankingMenu(BankAccount userAccount)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Banking Menu =====");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Account Info");
            Console.WriteLine("5. Logout");
            Console.Write("Enter choice: ");

            string option = Console.ReadLine();

            if (option == "5")
                break;

            switch (option)
            {
                case "1":
                    Console.Write("Enter deposit amount: ");
                    double depositAmount;

                    while (!double.TryParse(Console.ReadLine(), out depositAmount) || depositAmount <= 0)
                    {
                        Console.Write("Invalid amount! Enter again: ");
                    }

                    userAccount.Deposit(depositAmount);
                    break;

                case "2":
                    Console.Write("Enter withdraw amount: ");
                    double withdrawAmount;

                    while (!double.TryParse(Console.ReadLine(), out withdrawAmount) || withdrawAmount <= 0)
                    {
                        Console.Write("Invalid amount! Enter again: ");
                    }

                    userAccount.Withdraw(withdrawAmount);
                    break;

                case "3":
                    userAccount.CheckBalance();
                    break;

                case "4":
                    userAccount.ShowAccountInfo();
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}