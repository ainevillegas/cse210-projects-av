public class BankAccount
{
    private decimal balance;

    public decimal GetBalance()
    {
        return balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
     
        }
    }