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
    public class BlogPostsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BlogPostsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: BlogPosts
        public async Task<ActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var BlogPosts = await _context.BlogPost
                .Where(p => p.UserId == user.Id)
                .ToListAsync();
            return View(BlogPosts);
        }

        //// GET: BlogPosts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();
            var BlogPosts = await _context.BlogPost
                .FirstOrDefaultAsync(p => p.Id == id);

            if (BlogPosts == null)
            {
                return NotFound();
            }

            return View(BlogPosts);
        }

        //// GET: BlogPosts/Create
        public async Task<ActionResult> Create()
        {
            var BlogPostTypeOptions = await _context.BlogPost
                .Select(bp => new SelectListItem()
                {
                    Text = base[.Label,
                    Value = pt.BlogPost.ToString()
                })
                .ToListAsync();

            var viewModel = new BlogPost();
            viewModel.BlogPostOptions = BlogPostOptions;

            return View(viewModel);
        }

        // POST: BlogPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Name,Description,UserId,File,ImagePath")] BlogPost blogPost)
        {
            try
            {
                //gets the current user, uses custom method created at bottom
                //you will plug in the user.Id in the BlogPost
                var user = await GetCurrentUserAsync();

                //builds up our new BlogPost using the data submitted from the form, 
                //represented here as "BlogPostViewModel"
                var BlogPosts = new BlogPost
                {
                    Id = blogPost.Id,
                    Name = blogPost.Name,
                    Description = blogPost.Description,
                    UserId = user.Id

                };
                if (blogPost.File != null && blogPost.File.Length > 0)
                {
                    //creates the file name and makes it unique by generating a Guid and adding that to the file name
                    var fileName = Guid.NewGuid().ToString() + Path.GetFileName(blogPost.File.FileName);
                    //defines the filepath by adding the fileName above and combines it with the wwwroot directory 
                    //which is where our images are stored
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                    //adds the newly created fileName to the BlogPost object we built up above to be stored in 
                    //the database as the ImagePath
                    BlogPosts.ImagePath = fileName;

                    //what actually allows us to save the file to the folder path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await blogPost.File.CopyToAsync(stream);
                    }

                }

                //adds the newly built BlogPost object to the BlogPost table using _context.BlogPost.Add
                _context.BlogPost.Add(BlogPosts);
                //You have to used SaveChangesAsync in order to actually submit the data to the database
                await _context.SaveChangesAsync();

                //returns user to the BlogPost Details view of the newly created BlogPost
                return RedirectToAction("Details", new { id = BlogPosts.Id });
            }
            catch
            {
                return View();
            }
        }

        //// GET: BlogPosts/Edit/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();
            var BlogPost = await _context.BlogPost
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (BlogPost == null)
            {
                return NotFound();
            }

            if (BlogPost.UserId != user.Id)
            {
                return NotFound();
            }

            return View(BlogPost);
        }

        //// GET: BlogPosts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //// POST: BlogPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var BlogPost = await _context.BlogPost.FindAsync(id);
            _context.BlogPost.Remove(BlogPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}