using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
	public abstract partial class Product
	{

		public void UpdateLowStock()
		{
			if (AmountInStock < 10)
			{
				IsBelowStockTreshold = true;
			}
		}


		protected void Log(string message)
		{
			Console.WriteLine(message);
		}

		protected string CreateSimpleProductRepresentation()
		{
			return $"Product {Id} ({Name})";
		}


	}
}
