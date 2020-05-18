using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpowerHealthyStudents.Data;
using EmpowerHealthyStudents.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using Microsoft.Extensions.Configuration.UserSecrets;
using NuGet.Frameworks;

namespace EmpowerHealthyStudents.Controllers
{
    public class ProductReviewsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductReviewsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: ProductReviews
        public async Task<ActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var ProductReviews = await _context.ProductReview
                .Include(c => c.User)
                .ToListAsync();
            return View(ProductReviews);
        }

        //// GET: ProductReviews/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();
            var productReviews = await _context.ProductReview
                .Include(c => c.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (productReviews == null)
            {
                return NotFound();
            }

            return View(productReviews);
        }

        //// GET: ProductReviews/Create
        [HttpGet]
        [Route("ProductReviews/Create/{id}")]
        public async Task<ActionResult> Create(int id)
        {
            var user = await GetCurrentUserAsync();

            var product = await _context.Product.FirstOrDefaultAsync(b => b.Id == id);

            var view = new ProductReview
            {
                
                ProductId = product.Id
            };

            if (user != null)

            {
                return View(view);

            }

            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ProductReviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Comment,UserId,ProductId")] ProductReview productReview, int id)
        {
            try
            {
                //gets the current user, uses custom method created at bottom
                //you will plug in the user.Id in the product
                var user = await GetCurrentUserAsync();
                var product = await _context.Product.FindAsync(id);


                //builds up our new product using the data submitted from the form, 
                //represented here as "productViewModel"
                var productReviews = new ProductReview
                {
                    Date = DateTime.Now,
                    Comment = productReview.Comment,
                    UserId = user.Id,
                    ProductId = id

                };

                _context.ProductReview.Add(productReviews);
                await _context.SaveChangesAsync();


                return RedirectToAction("Details", "Products", new { id = id }); ;

            }
            catch
            {
                return View();
            }
        }



        // GET: ProductReviews/Edit/5
        [HttpGet]
        [Route("ProductReviews/Edit/{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            var user = await GetCurrentUserAsync();


            var reviews = await _context.ProductReview.FirstOrDefaultAsync(pr => pr.Id == id);

            var view = new ProductReview()
            {
                Comment = reviews.Comment,
                ProductId = reviews.ProductId
            };

            if (user != null)

            {
                return View(reviews);

            }

            else
            {
                return RedirectToAction(nameof(Index));
            }
        }


        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Comment,BlogPostId,UserId")]ProductReview productReview, int id)
        {
            try
            {
                var reviews = await _context.ProductReview.FirstOrDefaultAsync(c => c.Id == id);


                reviews.Id = productReview.Id;
                reviews.Comment = productReview.Comment;
                reviews.ProductId = reviews.ProductId;
                reviews.UserId = productReview.UserId;
                



                var user = await GetCurrentUserAsync();
                reviews.UserId = user.Id;

                _context.ProductReview.Update(reviews);
                await _context.SaveChangesAsync();


                return RedirectToAction("Details", "Products", new { id = reviews.ProductId });
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        //// GET: ProductReviews/Delete/5
        [HttpGet]
        [Route("ProductReviews/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {


            var user = await GetCurrentUserAsync();
            var productReview = await _context.ProductReview
                .Include(c => c.User)
                   .ThenInclude(c => c.Products)
                   .Where(c => c.Id == id)
                   .FirstOrDefaultAsync();


            if (user != null)

            {
                return View(productReview);

            }

            if (id == null)
            {
                return NotFound();
            }


            //if (ProductReview == null)
            //{
            //    return NotFound();
            //}

            //if (ProductReview.UserId != user.Id)
            //{
            //    return NotFound();
            //}



            return RedirectToAction(nameof(Index));

        }



        //// POST: ProductReviews/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productReview = await _context.ProductReview.FindAsync(id);
            _context.ProductReview.Remove(productReview);
            await _context.SaveChangesAsync();


            return RedirectToAction("Details", "Products", new { id = productReview.ProductId });
        }


        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}