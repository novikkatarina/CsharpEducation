using Task6;

//  Создайте программу, которая имитирует работу магазина. Создайте
//  класс `Product`, который представляет товар с определенным названием
//  и ценой. Затем создайте класс `PurchaseEventArgs`, который наследуется
//  от `EventArgs` и содержит информацию о покупке (например, название
//  товара и сумма покупки). Добавьте событие `PurchaseCompleted`,
//  которое будет генерироваться при каждой покупке, и передавать объект
//  `PurchaseEventArgs` с информацией о покупке.

var shop = new Shop();
shop.Notify += eventArgs =>
  Console.WriteLine($"Purchased {eventArgs.Name} {eventArgs.Price}");

shop.Purchase("Item1");
shop.Purchase("Item2");
shop.Purchase("Item3");
