using System;
namespace productReviewAPI.ViewModel
{
	public class ProductDto
	{
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string category { get; set; } = null!;
        public string desc { get; set; } = null!;
        public float price { get; set; }
        public int? discount { get; set; }
        public float? pAfterD { get; set; }
    }

}

