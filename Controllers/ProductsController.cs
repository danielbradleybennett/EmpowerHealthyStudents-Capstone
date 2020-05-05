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


namespace EmpowerHealthyStudents.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index(bool IsAdmin)
        {

            
            var user = await GetCurrentUserAsync();
            var products = await _context.Product
             .ToListAsync();

            if (user != null)
            {
                if (user.IsAdmin == true)
                {
                    return RedirectToAction(nameof(AdminIndex));
                }

                else if (user.IsAdmin == false)
                {
                    return RedirectToAction(nameof(FollowerIndex));
                }

                else
                {
                    return View(products);

                }   
            } 
            else
            {
                return View(products);
            }
        }

        public async Task<ActionResult> AdminIndex()
        {

            var user = await GetCurrentUserAsync();
            var products = await _context.Product
                .Where(p => p.UserId == user.Id)
                .ToListAsync();
            
            return View(products);
        }

        public async Task<ActionResult> FollowerIndex()
        {

            var user = await GetCurrentUserAsync();
            var products = await _context.Product
                .ToListAsync();

            return View(products);
        }



        // GET: Products
        //public async Task<ActionResult> AdminIndex()
        //{

        //    var user = await GetCurrentUserAsync();
        //    if(user.IsAdmin == false)
        //        {

        //        return NotFound();
        //        }

        //         var products = await _context.Product
        //        .Where(p => p.UserId == user.Id)
        //        .ToListAsync();
        //        return View(products);

        //}



        //// GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();
            var products = await _context.Product
                .FirstOrDefaultAsync(p => p.Id == id);

            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        //// GET: AdminProducts/Create
        public async Task<ActionResult> Create()
        {
           
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                if (user.IsAdmin == true)

                {
                    return View();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Name,Description,UserId,File,ImagePath")] Product product)
        {
            try
            {
                //gets the current user, uses custom method created at bottom
                //you will plug in the user.Id in the product
                var user = await GetCurrentUserAsync();

                //builds up our new product using the data submitted from the form, 
                //represented here as "productViewModel"
                var products = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    UserId = user.Id

                };
                //if (product.File != null && product.File.Length > 0)
                //{
                //    //creates the file name and makes it unique by generating a Guid and adding that to the file name
                //    var fileName = Guid.NewGuid().ToString() + Path.GetFileName(product.File.FileName);
                //    //defines the filepath by adding the fileName above and combines it with the wwwroot directory 
                //    //which is where our images are stored
                //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                //    //adds the newly created fileName to the product object we built up above to be stored in 
                //    //the database as the ImagePath
                //    products.ImagePath = fileName;

                //    //what actually allows us to save the file to the folder path
                //    using (var stream = new FileStream(filePath, FileMode.Create))
                //    {
                //        await product.File.CopyToAsync(stream);
                //    }

                //}

                //adds the newly built product object to the Product table using _context.Product.Add
                _context.Product.Add(products);
                //You have to used SaveChangesAsync in order to actually submit the data to the database
                await _context.SaveChangesAsync();

                //returns user to the product Details view of the newly created product
                return RedirectToAction("Details", new { id = products.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Prducts/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await GetCurrentUserAsync();
            var product = new Product();
            var book = await _context.BlogPost.FirstOrDefaultAsync(c => c.Id == id);


            product.Name = product.Name;
            product.Description = product.Description;

            if(user.IsAdmin == false)
            {
                return RedirectToAction(nameof(Index));
            }


            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product product)
        {
            try
            {
                var productToUpdate = new Product()
                {
                    Id = product.Id,
                    Description = product.Description,
                    Name = product.Description

                };

                var user = await GetCurrentUserAsync();
                productToUpdate.UserId = user.Id;

                _context.Product.Update(productToUpdate);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //// GET: Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            
            var user = await GetCurrentUserAsync();
            if(user.IsAdmin == false)
            
                if (user.IsAdmin == false)
                {
                    return RedirectToAction(nameof(Index));
                }
            
            
            var product = await _context.Product
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            if (product.UserId != user.Id)
            {
                return NotFound();
            }

            return View(product);
        }

        

        //// POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}