using BethanysPieShop.InventoryManagement.Domain.General;
using BethanysPieShop.InventoryManagement.Domain.ProductManagement;

namespace BethanysPieShop.InventoryManagement.Tests
{
	public class ProductTests
	{
		[Fact]
		public void UseProduct_Reduces_AmountInStock()
		{
			// ARRANGE
			Product product = new Product(1, "Sugar", "Some Sugar", new Price() {ItemPrice = 10, Currency = Currency.Dollar}, UnitType.PerKg, 100);
			product.IncreaseStock(100);

			// ACT
			product.UseProduct(20);

			// ASSERT
			Assert.Equal(80, product.AmountInStock);
		}


		[Fact]
		public void UseProduct_ItemsHigherThanStock_NoChangeToStock()
		{
			// ARRANGE
			Product product = new Product(1, "Sugar", "Some Sugar", new Price() { ItemPrice = 10, Currency = Currency.Dollar }, UnitType.PerKg, 100);
			product.IncreaseStock(10);

			// ACT
			product.UseProduct(20);

			// ASSERT
			Assert.Equal(10, product.AmountInStock);
		}



	}
}
