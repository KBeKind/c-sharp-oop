using System.Reflection.Metadata.Ecma335;
using System.Text;
using BethanysPieShop.InventoryManagement.Domain.General;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public partial class Product
    {
        public static int StockThreshold { get; private set; } = 10;

        private int Id { get; set; }
        private string Name { get; set; }
        public string? Description { get; set; }

        private int MaxItemsInStock { get; set; }

        private UnitType UnitType { get; set; }
        private int AmountInStock { get; set; } = 0;
        private bool IsBelowStockTreshold { get; set; } = false;

        private Price Price { get; set; }

        public Product(int id) : this(id, string.Empty, new Price(0, Currency.Euro)) { }


        public Product(int id, string name, Price price)
        {
            Id = id;
            MaxItemsInStock = 100;
            Name = name;
            Price = price;
        }

        public Product(int id, string name, string? description, Price price, UnitType unitType, int maxItemsInStock)
        {
            Id = id;
            Name = name;
            Description = description;
            UnitType = unitType;
            MaxItemsInStock = maxItemsInStock;
            Price = price;

            UpdateLowStock();
        }


        public void UseProduct(int items)
        {
            if (items <= AmountInStock)
            {
                AmountInStock -= items;

                UpdateLowStock();

                Log($"Amount in stock updated. Now {AmountInStock} items in stock.");
            }
            else
            {
                Log($"Not enough items in stock for {CreateSimpleProductRepresentation()}.  {AmountInStock} available but {items} requested.");
            }
        }

        public void IncreaseStock()
        {
            AmountInStock++;
        }

        public void IncreaseStock(int amount)
        {
            int newStock = AmountInStock + amount;

            if (newStock <= MaxItemsInStock)
            {
                AmountInStock += amount;
            }
            else
            {
                AmountInStock = MaxItemsInStock;
                Log($"{CreateSimpleProductRepresentation} stock overflow.  {newStock - AmountInStock} item(s) ordered that couldn't be stored.");
            }

            if (AmountInStock > StockThreshold)
            {
                IsBelowStockTreshold = false;
            }
        }

        public void DecreaseStock(int items, string reason)
        {
            if (items <= AmountInStock)
            {
                AmountInStock -= items;
            }
            else
            {
                AmountInStock = 0;
            }
            UpdateLowStock();
            Log(reason);
        }

        public string DisplayDetailsShort()
        {
            return $"{Id}. {Name} \n {AmountInStock} items in stock.";
        }

        public string DisplayDetailsFull()
        {
            return DisplayDetailsFull("");
        }

        public string DisplayDetailsFull(string extraDetails)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Id} {Name} \n{Description}\n{Price}\n{AmountInStock} item(s) in stock.");

            sb.Append(extraDetails);

            if (IsBelowStockTreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }
            return sb.ToString();
        }


        public static void ChangeStockThreshold(int threshold)
        {
            if (threshold > 0)
            {
                StockThreshold = threshold;
            }
        }


    }
}
