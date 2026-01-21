using System;
using System.Collections.Generic;

class WithdrawalRequest
{
    public int AccountNo;
    public double Amount;

    public WithdrawalRequest(int accNo, double amount)
    {
        AccountNo = accNo;
        Amount = amount;
    }
}

class Program
{
    static void Main()
    {
        // Stores account number → balance
        Dictionary<int, double> accounts = new Dictionary<int, double>();

        // Queue for withdrawal requests (FIFO)
        Queue<WithdrawalRequest> withdrawalQueue = new Queue<WithdrawalRequest>();

        // Create accounts
        AddAccount(101, 5000);
        AddAccount(102, 12000);
        AddAccount(103, 7000);
        AddAccount(104, 12000);

        // Add withdrawal requests
        withdrawalQueue.Enqueue(new WithdrawalRequest(101, 2000));
        withdrawalQueue.Enqueue(new WithdrawalRequest(103, 8000));
        withdrawalQueue.Enqueue(new WithdrawalRequest(102, 3000));

        Console.WriteLine("\nProcessing Withdrawals:");
        ProcessWithdrawals();

        Console.WriteLine("\nAccounts Sorted by Balance:");
        DisplaySortedByBalance();

        // ---------- LOCAL FUNCTIONS ----------

        void AddAccount(int accNo, double balance)
        {
            accounts[accNo] = balance;
        }

        void ProcessWithdrawals()
        {
            while (withdrawalQueue.Count > 0)
            {
                var request = withdrawalQueue.Dequeue();

                if (!accounts.ContainsKey(request.AccountNo))
                {
                    Console.WriteLine($"Account {request.AccountNo} not found.");
                    continue;
                }

                if (accounts[request.AccountNo] >= request.Amount)
                {
                    accounts[request.AccountNo] -= request.Amount;
                    Console.WriteLine(
                        $"Withdrawal successful → Account {request.AccountNo}, Remaining Balance: {accounts[request.AccountNo]}"
                    );
                }
                else
                {
                    Console.WriteLine(
                        $"Insufficient balance → Account {request.AccountNo}"
                    );
                }
            }
        }

        void DisplaySortedByBalance()
        {
            // Balance → list of accounts (to handle equal balances)
            SortedDictionary<double, List<int>> sorted =
                new SortedDictionary<double, List<int>>();

            foreach (var pair in accounts)
            {
                if (!sorted.ContainsKey(pair.Value))
                    sorted[pair.Value] = new List<int>();

                sorted[pair.Value].Add(pair.Key);
            }

            foreach (var entry in sorted)
            {
                foreach (var acc in entry.Value)
                {
                    Console.WriteLine($"Account {acc} → Balance: ₹{entry.Key}");
                }
            }
        }
    }
}
