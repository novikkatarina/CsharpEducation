using Task6;

MyList list = new MyList();
list.Items.AddRange(new []{1,2,38, 2, 4});

foreach (var item in list)
{
  Console.WriteLine((int)item);
}
