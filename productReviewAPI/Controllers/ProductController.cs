using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using productReviewAPI.Data;
using productReviewAPI.Models;
using Microsoft.EntityFrameworkCore;
using productReviewAPI.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace productReviewAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly productReviewContext _dataContext;

        public ProductController(productReviewContext Context)
        {
            _dataContext = Context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {

            return Ok(await _dataContext.Products.ToListAsync());
        }
       
        [HttpGet("getProductsByID/{id}")]
        public async Task<ActionResult<List<Product>>> Get(int id)
        {
            var sProduct = await _dataContext.Products.FindAsync(id);
            return Ok(sProduct);
        }

        [HttpGet("getProductsByName/{name}")]
        public ActionResult Get(string name)
        {
            var sproduct = (
                from p in _dataContext.Products
                where p.name == name
                select p);                            
            return Ok(sproduct);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> postByID(ProductDto p)
        {
            var prod = new Product
            {
                name = p.ProductName,
                category = p.category,
                desc = p.desc,
                price = p.price,
                discount = p.discount,
                pAfterD = (p.price - ((p.discount/100) * p.price))
            };
            _dataContext.Products.Add(prod);

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Products.ToListAsync());
        }

        [HttpGet("getReviews")]
        public async Task<ActionResult<List<Product>>> GetReviews()
        {        
            return Ok(await _dataContext.Reviews.ToListAsync());
        }

        [HttpGet("getReviews/{id}")]
        public ActionResult<List<Product>> GetReviews(int id)
        {
            //var sReviews = _dataContext.Products.Where(item=>item.Id == id).Select(item=>item.Reviews).ToList();
            var data = (from r in _dataContext.Reviews
                        join p in _dataContext.Products
                        on r.product.Id equals p.Id
                        where p.Id == id
                        select r);
            return Ok(data);
        }

        [HttpPost("reviews")]
        public async Task<ActionResult> postReviews(ReviewDto r)
        {
            var p1 = (from p in _dataContext.Products
                      where p.Id == r.pId
                      select p).First();
            var r1 = new Review
            {
                reviewerName = r.reviewerName,
                review = r.review,
                star = r.star,
                product = (Product)p1
            };
            _dataContext.Reviews.Add(r1);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

    }
}

