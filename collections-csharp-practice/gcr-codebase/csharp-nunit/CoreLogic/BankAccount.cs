namespace CoreLogic;

public class BankAccount
{
    private double _balance;

    public void Deposit(double amount) => _balance += amount;

    public void Withdraw(double amount)
    {
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds");

        _balance -= amount;
    }

    public double GetBalance() => _balance;
}
