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
                .Where(p => p.UserId == user.Id)
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
        public async Task<ActionResult> Create()
        {
            
            {
                var user = await GetCurrentUserAsync();
                return View();
            }
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Text,Date,UserId")] Comment comment)
        {
            try
            {
                //gets the current user, uses custom method created at bottom
                //you will plug in the user.Id in the product
                var user = await GetCurrentUserAsync();

                //builds up our new product using the data submitted from the form, 
                //represented here as "productViewModel"
                var comments = new Comment
                {
                    Id = comment.Id,
                    Text = comment.Text,
                    Date = comment.Date,
                    UserId = user.Id

                };

                _context.Comment.Add(comments);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

       

        // GET: Books/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var user = await GetCurrentUserAsync();
            var comment = new Comment();
            var book = await _context.Comment.FirstOrDefaultAsync(c => c.Id == id);


            comment.Text = comment.Text;
            comment.Date = comment.Date;


           
            return View(comment);
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();
            var comment = await _context.Comment
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            if (comment.UserId != user.Id)
            {
                return NotFound();
            }

            return View(comment);

        }



        //// POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}