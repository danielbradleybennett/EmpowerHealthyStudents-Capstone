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
using EmpowerHealthyStudents.Models.ViewModels;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using Microsoft.EntityFrameworkCore.Internal;

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

        public async Task<ActionResult> Index(string searchString)
        {

           
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                if (user.IsAdmin == true)
                {
                    return RedirectToAction(nameof(AdminIndex));
                }

                if (string.IsNullOrWhiteSpace(searchString))
                {
                    var products = await _context.Product
                   .ToListAsync();
                    return View(products);
                }
                else
                {
                    var products = await _context.Product
                     .Where(p => p.Name.Contains(searchString) || p.Grade.Contains(searchString) || p.Subject.Contains(searchString))
                     .ToListAsync();
                    return View(products);
                }
            }

            if(user == null)
            {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                var products = await _context.Product
               .ToListAsync();
                return View(products);
            }
            else
            {
                var products = await _context.Product
                 .Where(p => p.Name.Contains(searchString) || p.Grade.Contains(searchString) || p.Subject.Contains(searchString))
                 .ToListAsync();
                return View(products);
            }

            }
            else
            {
                return View();
            }
        
        }















           

            public async Task<ActionResult> AdminIndex(string searchString)
            {

            var user = await GetCurrentUserAsync();
         

            if (string.IsNullOrWhiteSpace(searchString))
            {
                var adminProducts = await _context.Product
                 .ToListAsync();
                return View(adminProducts);
            }
            else
            {
                var adminProducts = await _context.Product
                 .Where(p => p.Name.Contains(searchString) || p.Grade.Contains(searchString) || p.Subject.Contains(searchString))
                 .ToListAsync();
                return View(adminProducts);
            }

          
        }

        //// GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();
            var products = await _context.Product
                .Include(p => p.ProductReviews)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (products == null)
            {
                return NotFound();
            }

            if (user != null)
            {
                ViewBag.IsAdmin = user.IsAdmin;
            }

            else
            {
                ViewBag.IsAdmin = false;
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
        public async Task<ActionResult> Create([Bind("Id,Name,Description,UserId,FileType,File,Image,Grade,Type,Subject")] ProductViewModels productViewModel)
        {
            try
            {
                //gets the current user, uses custom method created at bottom
                //you will plug in the user.Id in the product
                var user = await GetCurrentUserAsync();

                //builds up our new product using the data submitted from the form, 
                //represented here as "productViewModel"
                var product = new Product
                {
                    Id = productViewModel.Id,
                    Name = productViewModel.Name,
                    Description = productViewModel.Description,
                    UserId = user.Id,
                    Grade = productViewModel.Grade,
                    FileType = productViewModel.FileType,
                    Subject = productViewModel.Subject
                    
                    
                    

                };
                if (productViewModel.Image != null && productViewModel.Image.Length > 0)
                {
                    //creates the file name and makes it unique by generating a Guid and adding that to the file name
                    var fileName = Guid.NewGuid().ToString() + Path.GetFileName(productViewModel.Image.FileName);
                    //defines the filepath by adding the fileName above and combines it with the wwwroot directory 
                    //which is where our images are stored
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                    //adds the newly created fileName to the product object we built up above to be stored in 
                    //the database as the ImagePath
                    product.Image = fileName;

                    //what actually allows us to save the file to the folder path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await productViewModel.Image.CopyToAsync(stream);
                    }

                }

                if (productViewModel.File != null && productViewModel.File.Length > 0)
                {
                    //creates the file name and makes it unique by generating a Guid and adding that to the file name
                    var fileName = Guid.NewGuid().ToString() + Path.GetFileName(productViewModel.File.FileName);
                    //defines the filepath by adding the fileName above and combines it with the wwwroot directory 
                    //which is where our images are stored
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", fileName);

                    //adds the newly created fileName to the product object we built up above to be stored in 
                    //the database as the ImagePath
                    product.File = fileName;

                    //what actually allows us to save the file to the folder path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await productViewModel.File.CopyToAsync(stream);
                    }

                }

                //adds the newly built product object to the Product table using _context.Product.Add
                _context.Product.Add(product);
                //You have to used SaveChangesAsync in order to actually submit the data to the database
                await _context.SaveChangesAsync();

                //returns user to the product Details view of the newly created product
                return RedirectToAction("Details", new { id = product.Id });
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
            var product = await _context.Product.FirstOrDefaultAsync(p => p.Id == id);

            ProductViewModels pvm = new ProductViewModels();
            pvm.Name = product.Name;
            pvm.Id = product.Id;
            pvm.Description = product.Description;
            pvm.UserId = product.UserId;
            pvm.FilePath = product.File;
            pvm.ImagePath = product.Image;
            pvm.Grade = product.Grade;
            pvm.Subject = product.Subject;
            pvm.FileType = product.FileType;





            product.Name = product.Name;
            product.Description = product.Description;

            if (user != null)
            {

                if (user.IsAdmin == true)
                {
                    return View(pvm);
                }
                else
                {

                    return RedirectToAction(nameof(Index));
                }

            }

            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("Id,Name,Description,UserId,File,Image")] ProductViewModels productViewModel)
        {
            try
            {
                var product = await _context.Product
                    .FirstOrDefaultAsync(p => p.Id == productViewModel.Id);


                var user = await GetCurrentUserAsync();


                product.UserId = user.Id;
                product.Name = productViewModel.Name;
                product.Description = productViewModel.Description;
                product.Grade = productViewModel.Grade;
                product.FileType = productViewModel.FileType;
                product.Subject = productViewModel.Subject;

                if (productViewModel.Image != null && productViewModel.Image.Length > 0)
                {
                    //creates the file name and makes it unique by generating a Guid and adding that to the file name
                    var fileName = Guid.NewGuid().ToString() + Path.GetFileName(productViewModel.Image.FileName);
                    //defines the filepath by adding the fileName above and combines it with the wwwroot directory 
                    //which is where our images are stored
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                    //adds the newly created fileName to the product object we built up above to be stored in 
                    //the database as the ImagePath
                    product.Image = fileName;

                    //what actually allows us to save the file to the folder path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await productViewModel.Image.CopyToAsync(stream);
                    }

                }

                if (productViewModel.File != null && productViewModel.File.Length > 0)
                {
                    //creates the file name and makes it unique by generating a Guid and adding that to the file name
                    var fileName = Guid.NewGuid().ToString() + Path.GetFileName(productViewModel.File.FileName);
                    //defines the filepath by adding the fileName above and combines it with the wwwroot directory 
                    //which is where our images are stored
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", fileName);

                    //adds the newly created fileName to the product object we built up above to be stored in 
                    //the database as the ImagePath
                    product.File = fileName;

                    //what actually allows us to save the file to the folder path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await productViewModel.File.CopyToAsync(stream);
                    }

                }


                _context.Product.Update(product);
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
            var product = await _context.Product
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

           
            if (user != null)
            {
                if (user.IsAdmin == true)
                {
                    return View(product);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }


            }

            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        

        //// POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", product.Image));
            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", product.File));


            return RedirectToAction(nameof(Index));
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}