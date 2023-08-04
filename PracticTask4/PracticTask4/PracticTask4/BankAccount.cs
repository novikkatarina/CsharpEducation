namespace PracticTask4;

// 2. Создайте класс, представляющий банковский счет. Добавьте методы для
// депозита и снятия денег с этого счета. Добавьте проверки на возможные
// исключения, такие как недостаточный баланс или отрицательная сумма.
// Если возникает исключение, студенты должны создать пользовательское
// исключение и выбросить его с соответствующим сообщением.

public class BankAccount
{
  public double Deposit { set; get; }
  public double Money { set; get; }

  public void AddDeposit()
  {
    bool flag = false;
    var money = 0.0;
    do
    {
      Console.WriteLine("Введите сумму");
      string input = Console.ReadLine();

      try
      {
        bool isDouble = double.TryParse(input, out money);
        if (!isDouble)
        {
          throw new FormatException(
            "Введенное значение не число.");
        }

        if (money < 0)
        {
          throw new ArgumentException("Сумма должна быть больше нуля.");
        }
      }
      catch (Exception ex) when (ex is ArgumentException ||
                                 ex is FormatException)
      {
        continue;
      }
      this.Deposit += money;
      flag = true;
    } while (!flag);

    Console.WriteLine(Deposit);
  }

  public void WithdrawalDeposit()
  {
    bool flag = false;
    var money = 0.0;
    do
    {
      Console.WriteLine("Введите сумму");
      string input = Console.ReadLine();

      try
      {
        bool isDouble = double.TryParse(input, out money);
        if (!isDouble)
        {
          throw new FormatException(
            "Введенное значение не число.");
        }

        if (Deposit < money)
        {
          throw new ArgumentException(
            "Недостаточно средств на счету.");
        }

        if (money < 0)
        {
          throw new DepositMyException("Сумма должна быть больше нуля.");
        }
      }
      catch (Exception ex) when (ex is ArgumentException ||
                                 ex is FormatException)
      {
        Console.WriteLine(ex.Message);
        continue;
      }
      this.Deposit -= money;
      flag = true;
      Console.WriteLine($"На счету {Deposit}");
    } while (!flag);
  }

  public BankAccount()
  {
    this.Deposit = 0;
  }
}
