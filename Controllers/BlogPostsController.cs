using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpowerHealthyStudents.Data;
using EmpowerHealthyStudents.Models;
using EmpowerHealthyStudents.Models.ViewModels;
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
            var blogPosts = await _context.BlogPost
                .Include(bg => bg.Comments)
                    
                .ToListAsync();
           
            if (user != null)
            {
                if (user.IsAdmin == true)
                {
                    return RedirectToAction(nameof(AdminIndex));
                }

                else
                {
                    return View(blogPosts);

                }
            }
            else
            {
                return View(blogPosts);
            }


        }

        public async Task<ActionResult> AdminIndex()
        {
            var user = await GetCurrentUserAsync();
            var BlogPosts = await _context.BlogPost
                .Include(bg => bg.Comments)
                    
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
                .Include(bg => bg.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(p => p.Id == id);
                
           

            if (BlogPosts == null)
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

            return View(BlogPosts);
        }

        //// GET: BlogPosts/Create
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
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: BlogPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Title,Blog,Date,UserId")] BlogPost blogPost)
        {
            try
            {
                //gets the current user, uses custom method created at bottom
                //you will plug in the user.Id in the BlogPost
                var user = await GetCurrentUserAsync();

                //builds up our new BlogPost using the data submitted from the form, 
                //represented here as "BlogPos"
                var blogPosts = new BlogPost
                {
                    Id = blogPost.Id,
                    Title = blogPost.Title,
                    Blog = blogPost.Blog,
                    UserId = user.Id,
                    Date = blogPost.Date

                };
                _context.BlogPost.Add(blogPosts);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return View();
            }
        }

       
        // GET: BlogPosts/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await GetCurrentUserAsync();
            var blogPost = await _context.BlogPost.FirstOrDefaultAsync(b => b.Id == id);

            blogPost.Title = blogPost.Title;
            blogPost.Blog = blogPost.Blog;
            blogPost.Date = blogPost.Date;
            if (user != null)
            {

                if (user.IsAdmin == true)
                {
                    return View(blogPost);
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

        // POST: BlogPosts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BlogPost blogPost)
        {
            try
            {
               

                var blogPostToUpdate = new BlogPost()
                {
                    Id = blogPost.Id,
                    Title = blogPost.Title,
                    Blog = blogPost.Blog,
                    Date = blogPost.Date

                };

                var user = await GetCurrentUserAsync();
                blogPostToUpdate.UserId = user.Id;

                _context.BlogPost.Update(blogPostToUpdate);
                await _context.SaveChangesAsync();


                return RedirectToAction("Details", "BlogPosts", new { id = id });
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //// GET: BlogPost/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();
            var blogPost = await _context.BlogPost
                .Include(p => p.User)
                .Include(c => c.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            if (user != null)
            {
                if (user.IsAdmin == true)
                {
                    return View(blogPost);
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