using BethanysPieShop.InventoryManagement.Domain.General;
using BethanysPieShop.InventoryManagement.Domain.ProductManagement;
using System.Collections.Concurrent;




Price price = new Price(100.88, Currency.Euro);

var price2 = new Price() { ItemPrice = 88.23, Currency = Currency.Euro };


Product product1 = new(1, "Sugar", "Stuffwords", price, UnitType.PerKg, 100);

var product2 = new Product(2, "Chocolate", "DescriptionStuffwords", price2, UnitType.PerKg, 100);

product1.IncreaseStock();

product1.Description = "New Product Description";

Console.WriteLine(product1.DisplayDetailsFull());

Console.WriteLine("*******************");

Console.WriteLine(product2.DisplayDetailsFull()	);