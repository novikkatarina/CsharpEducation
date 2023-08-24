namespace Task6;

public class Shop
{
  public delegate void PurchaseCompleted(PurchaseEventArgs args);

  public event PurchaseCompleted Notify;
  public List<Product> Products { get; set; }

  public void Purchase(string name)
  {
    var product = Products.First(x => x.Name == name);
    bool removed = Products.Remove(product);
    if (removed)
      Notify?.Invoke(new PurchaseEventArgs(product.Name, product.Price));
  }

  public Shop()
  {
    Products = new List<Product>()
    {
      new Product("Item1", 1),
      new Product("Item2", 2),
      new Product("Item3", 3)
    };
  }
}
