using BethanysPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
	public class BoxedProduct : Product
	{
		private int AmountPerBox { get; set; }

		public BoxedProduct(int id, string name, string? description, Price price, int maxItemsInStock, int amountPerBox) : base(id, name, description, price, UnitType.PerBox, maxItemsInStock)
		{
			AmountPerBox = amountPerBox;
		}

		public override string DisplayDetailsFull()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Boxed Product\n");
			sb.Append($"{Id} {Name} \n{Description} \n{AmountInStock} item(s) in stock");
			if(IsBelowStockTreshold)
			{
				sb.Append("\n!!STOCK LOW!!");
			}
			return sb.ToString();
		}

		public override void UseProduct(int items)
		{
			int smallestMultiple = 0;
			int batchSize;

			while (true)
			{
				smallestMultiple++;
				if (smallestMultiple * AmountPerBox > items)
				{
				batchSize = smallestMultiple * AmountPerBox;
					break;
				}
			}

			base.UseProduct(batchSize);
		}

		public override void IncreaseStock()
		{
			IncreaseStock(1);
		}

		public override void IncreaseStock(int amount)
		{

			int newStock = AmountInStock + amount * AmountPerBox;

			if (newStock <= MaxItemsInStock)
			{
				AmountInStock += amount * AmountPerBox;
			}
			else
			{
				AmountInStock = MaxItemsInStock;
				Log($"{CreateSimpleProductRepresentation} stock overflow. {newStock - AmountInStock} item(s) ordered that couldn't be stored.");
			}

			
		}




	}
}
