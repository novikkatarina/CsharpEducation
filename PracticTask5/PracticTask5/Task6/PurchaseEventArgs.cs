namespace Task6;

public class PurchaseEventArgs : EventArgs
{
  public string Name { get; set; }
  public decimal Price { get; set; }

  public PurchaseEventArgs(string name, decimal price)
  {
    Name = name;
    Price = price;
  }
}
