using BethanysPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
	public class RegularProduct : Product
	{
		public RegularProduct(int id, string name, string? description, Price price, UnitType unitType, int maxItemsInStock) : base(id, name, description, price, unitType, maxItemsInStock)
		{
		}


		public override void IncreaseStock()
		{
			AmountInStock++;
		}
	}
}
