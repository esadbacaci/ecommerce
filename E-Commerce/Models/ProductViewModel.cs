using EntityLayer.Concrete;

namespace E_Commerce.Models
{
	public class ProductViewModel
	{
		public IEnumerable<Product>? Products { get; set; }
		public Category? Category { get; set; }
		public IEnumerable<Category>? Categories { get; set; }
	}
}
