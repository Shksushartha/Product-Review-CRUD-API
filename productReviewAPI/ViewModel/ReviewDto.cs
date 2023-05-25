using System;
using productReviewAPI.Models;
namespace productReviewAPI.ViewModel
{
	public class ReviewDto
	{
		public ReviewDto()
		{
		}
        public int Id { get; set; }
        public string reviewerName { get; set; } = null!;
        public string review { get; set; } = null!;
        public int star { get; set; }
        public int pId { get; set; } 
    }
}

