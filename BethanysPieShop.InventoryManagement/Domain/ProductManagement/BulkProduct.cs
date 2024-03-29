﻿using BethanysPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
	internal class BulkProduct : Product
	{
		public BulkProduct(int id, string name, string? description, Price price, int maxItemsInStock) :
			base(id, name, description, price, UnitType.PerKg, maxItemsInStock)
		{
		}

		public override void IncreaseStock()
		{
			AmountInStock++;
		}
	}
}
