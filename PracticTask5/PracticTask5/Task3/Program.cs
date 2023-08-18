using Task3;

// Создайте класс, представляющий банковский счет. Добавьте свойство
// для хранения баланса и методы для снятия и пополнения денег. Затем
// создайте свой собственный делегат `AccountTransactionDelegate`,
// который принимает в качестве параметров сумму транзакции и тип
// операции (пополнение или снятие). Используйте созданный делегат для
// регистрации и вызова обработчиков транзакций.

BankAccount ba = new BankAccount();

ba.Notify += message => Console.WriteLine(message);

bool flag = false;
var money = 0.0;
var transaction = 0;

do
{
  Console.WriteLine("Введите операцию. 1 - Пополнить счет. 2 - Снять деньги.");
  string input = Console.ReadLine();

  Console.WriteLine("Введите сумму");
  string input2 = Console.ReadLine();

  try
  {
    bool isInt = Int32.TryParse(input, out transaction);
    bool isDouble = double.TryParse(input2, out money);

    if (transaction != 1 & transaction != 2)
    {
      throw new FormatException("Неверный формат транзакции.");
    }

    if (!isDouble || !isInt)
    {
      throw new FormatException(
        "Введенное значение не число.");
    }

    if (money < 0)
    {
      throw new ArgumentOutOfRangeException("Сумма должна быть больше нуля.");
    }
  }
  catch (Exception ex) when (ex is ArgumentException ||
                             ex is FormatException)
  {
    Console.WriteLine(ex.Message);
    continue;
  }

  flag = true;
  BankAccount.AccountTransactionDelegate accountTransactionDelegate;
  switch (transaction)
  {
    case 1:
      accountTransactionDelegate = ba.AddDeposit;
      accountTransactionDelegate(money);
      break;
    case 2:
      accountTransactionDelegate = ba.WithdrawalDeposit;
      accountTransactionDelegate(money);
      break;
  }
} while (!flag);
