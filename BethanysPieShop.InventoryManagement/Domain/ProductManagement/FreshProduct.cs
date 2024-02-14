using BethanysPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
	internal class FreshProduct : Product
	{
		public DateTime ExpiryDateTime { get; set; }
		public string? StorageInstructions { get; set; }


		public FreshProduct(int id, string name, string? description, Price price, UnitType unitType, int maxItemsInStock) : base(id, name, description, price, unitType, maxItemsInStock)
		{
		}



		public override string DisplayDetailsFull()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Fresh Product\n");
			sb.Append($"{Id} {Name} \n{Description} \n{AmountInStock} item(s) in stock");
			if (IsBelowStockTreshold)
			{
				sb.Append("\n!!STOCK LOW!!");
			}

			sb.AppendLine("Storage Instructions: " + StorageInstructions);
			sb.AppendLine("Expiry Date: " + ExpiryDateTime.ToShortDateString());


			return sb.ToString();
		}

		public override void IncreaseStock()
		{
			AmountInStock++;
		}


	}


}
