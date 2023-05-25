using System;
using Microsoft.EntityFrameworkCore;
using productReviewAPI.Models;
namespace productReviewAPI.Data
{
	public class productReviewContext : DbContext
	{
		public DbSet<Product> Products { get; set; } = null!;
		public DbSet<Review> Reviews { get; set; } = null!;

        public  productReviewContext(DbContextOptions<productReviewContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
    }
}

