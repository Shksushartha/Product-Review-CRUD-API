using System;

namespace productReviewAPI.Models
{
	public class Review
	{
		
		public int Id { get; set; }
		public string reviewerName { get; set; } = null!;
		public string review { get; set; } = null!;
		public int star { get; set; } 

		public Product product { get; set; } = null!;

		public Review()
		{
		}
	}
}

