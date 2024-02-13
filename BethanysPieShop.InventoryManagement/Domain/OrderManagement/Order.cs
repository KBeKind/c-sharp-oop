﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement.Domain.OrderManagement
{
	public class Order
	{

		public Guid Id { get; set; }
		public DateTime OrderFulfilmentDate { get; private set; }

		public List<OrderItem> OrderItems { get;}

		public bool Fulfilled { get; set; } = false;


		public Order()
		{
			Id = new Guid();

			int numberOfSeconds = new Random().Next(100);

			OrderFulfilmentDate = DateTime.Now.AddSeconds(numberOfSeconds);

			OrderItems = new List<OrderItem>();
		}


	}
}
