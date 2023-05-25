using System;
namespace productReviewAPI.Models
{
	public class Product
	{
		public Product()
		{
		}
		public int Id { get; set; }
        public string name { get; set; } = null!;
		public string category { get; set; } = null!;
		public string desc { get; set; } = null!;
		public float price { get; set; }
        public int? discount { get; set; }
		public float? pAfterD { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}

