namespace Task3;

public class BankAccount
{
  public double Deposit { set; get; }

  public void AddDeposit(double money)
  {
    if (money < 0)
    {
      throw new ArgumentException("Депозит не может быть отрицательным");
    }

    this.Deposit += money;
    Notify?.Invoke($"Cчет пополнен. На счету {Deposit}");
  }

  public void WithdrawalDeposit(double money)
  {
    if (money < 0 || money > Deposit)
    {
      throw new ArgumentException(
        "Сумма снятия не может быть отрицательной или больше баланса");
    }

    this.Deposit -= money;
    Console.WriteLine($"На счету {Deposit}");
    Notify?.Invoke("Деньги сняты со счета");
  }

  public delegate void BankAccountMessaging(string message);

  public event BankAccountMessaging Notify;

  public BankAccount()
  {
    this.Deposit = 0;
  }

  public delegate void AccountTransactionDelegate(double money);
}
