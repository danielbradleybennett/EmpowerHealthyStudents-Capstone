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
    public class CommentsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: Comments
        public async Task<ActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var comments = await _context.Comment
                .ToListAsync();
            return View(comments);
        }

        //// GET: Comments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();
            var comments = await _context.Comment
                .FirstOrDefaultAsync(p => p.Id == id);

            if (comments == null)
            {
                return NotFound();
            }

            return View(comments);
        }

        //// GET: Comments/Create
        [HttpGet]
        [Route("Comments/Create/{id}")]
        public async Task<ActionResult> Create(int id)
        {
            var user = await GetCurrentUserAsync();
            
            var blogPost = await _context.BlogPost.FirstOrDefaultAsync(b => b.Id == id);

            var view = new Comment
            {
                Date = DateTime.Now,
                BlogPostId = blogPost.Id
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

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddComment([Bind("Id,Text,Date,UserId")] Comment comment, int id)
        {
            try
            {
                //gets the current user, uses custom method created at bottom
                //you will plug in the user.Id in the product
                var user = await GetCurrentUserAsync();
                var blogPost = await _context.BlogPost.FindAsync(id);
                

                //builds up our new product using the data submitted from the form, 
                //represented here as "productViewModel"
                var comments = new Comment
                {
                    
                    Text = comment.Text,
                    Date = comment.Date,
                    UserId = user.Id,
                    BlogPostId = id

                };

                _context.Comment.Add(comments);
                await _context.SaveChangesAsync();


                return RedirectToAction("Details", "BlogPosts", new { id = id }); ;

            }
            catch
            {
                return View();
            }
        }

       

        // GET: Comments/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await GetCurrentUserAsync();
            var comment = await _context.Comment.FirstOrDefaultAsync(c => c.Id == id);
            comment.Text = comment.Text;
            comment.Date = comment.Date;

            if (user != null)

            {
                return View(comment);

            }

            else
            {
                return RedirectToAction(nameof(Index));
            }

        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Comment comment)
        {
            try
            {
                var commentToUpdate = new Comment()
                {
                    Id = comment.Id,
                    Text = comment.Text,
                   
                };

                var user = await GetCurrentUserAsync();
                commentToUpdate.UserId = user.Id;

                _context.Comment.Update(commentToUpdate);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //// GET: Comments/Delete/5
        [HttpGet]
        [Route("Comments/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var blogPost = await _context.BlogPost.FirstOrDefaultAsync(b => b.Id == id);

            var user = await GetCurrentUserAsync();
            var comment = await _context.Comment
                .Include(c => c.User)
                   .ThenInclude(c => c.BlogPost)
                
                .Where(c => c.Id == id && c.BlogPostId == blogPost);
            if (user != null)

            {
                return View(comments);

            }

            if (id == null)
            {
                return NotFound();
            }


            //if (comment == null)
            //{
            //    return NotFound();
            //}

            //if (comment.UserId != user.Id)
            //{
            //    return NotFound();
            //}

            
           
                return RedirectToAction(nameof(Index));
            
        }



        //// POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();


            return RedirectToAction("Details", "BlogPosts");
        }


        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}