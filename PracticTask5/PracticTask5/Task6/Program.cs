using Task6;

var shop = new Shop();
shop.Notify += eventArgs =>
  Console.WriteLine($"Purchased {eventArgs.Name} {eventArgs.Price}");

shop.Purchase("Item1");
shop.Purchase("Item2");
shop.Purchase("Item3");
